import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from '../../services/task.service';
import { Task } from '../../models/task.model';

@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css']
})
export class TaskFormComponent implements OnInit {
  taskForm: FormGroup;
  loading = false;
  isEditMode = false;
  taskId?: number;
  error = '';

  constructor(
    private fb: FormBuilder,
    private taskService: TaskService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.taskForm = this.fb.group({
      titulo: ['', [Validators.required, Validators.maxLength(200)]],
      descricao: ['', [Validators.maxLength(1000)]],
      concluida: [false]
    });
  }

  ngOnInit(): void {
    this.taskId = Number(this.route.snapshot.paramMap.get('id'));
    this.isEditMode = !!this.taskId;

    if (this.isEditMode) {
      this.carregarTarefa();
    }
  }

  carregarTarefa(): void {
    if (!this.taskId) return;

    this.loading = true;
    this.taskService.obterTarefa(this.taskId).subscribe({
      next: (tarefa) => {
        this.taskForm.patchValue({
          titulo: tarefa.titulo,
          descricao: tarefa.descricao,
          concluida: tarefa.concluida
        });
        this.loading = false;
      },
      error: (error) => {
        this.error = 'Erro ao carregar tarefa';
        this.loading = false;
        console.error('Erro ao carregar tarefa:', error);
      }
    });
  }

  aoEnviar(): void {
    if (this.taskForm.valid) {
      this.loading = true;
      this.error = '';

      const valorFormulario = this.taskForm.value;

      if (this.isEditMode && this.taskId) {
        this.taskService.atualizarTarefa(this.taskId, valorFormulario).subscribe({
          next: () => {
            this.router.navigate(['/tasks']);
          },
          error: (error) => {
            this.error = 'Erro ao atualizar tarefa';
            this.loading = false;
            console.error('Erro ao atualizar tarefa:', error);
          }
        });
      } else {
        const criarTarefa = {
          titulo: valorFormulario.titulo,
          descricao: valorFormulario.descricao
        };

        this.taskService.criarTarefa(criarTarefa).subscribe({
          next: () => {
            this.router.navigate(['/tasks']);
          },
          error: (error) => {
            this.error = 'Erro ao criar tarefa';
            this.loading = false;
            console.error('Erro ao criar tarefa:', error);
          }
        });
      }
    }
  }

  aoCancelar(): void {
    this.router.navigate(['/tasks']);
  }

  get titulo() { return this.taskForm.get('titulo'); }
  get descricao() { return this.taskForm.get('descricao'); }
}
