import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TaskService } from '../../services/task.service';
import { AuthService } from '../../services/auth.service';
import { Task } from '../../models/task.model';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {
  tasks: Task[] = [];
  filteredTasks: Task[] = [];
  loading = false;
  filter: 'all' | 'pending' | 'completed' = 'all';

  constructor(
    private taskService: TaskService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.carregarTarefas();
  }

  carregarTarefas(): void {
    this.loading = true;
    this.taskService.obterTarefas().subscribe({
      next: (tarefas) => {
        this.tasks = tarefas.map(tarefa => ({
          ...tarefa,
          dataCriacao: new Date(tarefa.dataCriacao)
        }));
        this.aplicarFiltro();
        this.loading = false;
      },
      error: (error) => {
        console.error('Erro ao carregar tarefas:', error);
        this.loading = false;
      }
    });
  }

  aplicarFiltro(): void {
    switch (this.filter) {
      case 'pending':
        this.filteredTasks = this.tasks.filter(task => !task.concluida);
        break;
      case 'completed':
        this.filteredTasks = this.tasks.filter(task => task.concluida);
        break;
      default:
        this.filteredTasks = [...this.tasks];
    }
  }

  aoMudarFiltro(filter: 'all' | 'pending' | 'completed'): void {
    this.filter = filter;
    this.aplicarFiltro();
  }

  alternarConclusaoTarefa(task: Task): void {
    const tarefaAtualizada = {
      titulo: task.titulo,
      descricao: task.descricao,
      concluida: !task.concluida
    };

    this.taskService.atualizarTarefa(task.id, tarefaAtualizada).subscribe({
      next: () => {
        this.carregarTarefas();
      },
      error: (error) => {
        console.error('Erro ao atualizar tarefa:', error);
      }
    });
  }

  excluirTarefa(task: Task): void {
    if (confirm(`Tem certeza que deseja excluir a tarefa "${task.titulo}"?`)) {
      this.taskService.excluirTarefa(task.id).subscribe({
        next: () => {
          this.carregarTarefas();
        },
        error: (error) => {
          console.error('Erro ao excluir tarefa:', error);
        }
      });
    }
  }

  editarTarefa(task: Task): void {
    this.router.navigate(['/tasks/edit', task.id]);
  }

  criarNovaTarefa(): void {
    this.router.navigate(['/tasks/new']);
  }

  fazerLogout(): void {
    this.authService.fazerLogout();
    this.router.navigate(['/login']);
  }

  rastrearPorId(index: number, task: Task): number {
    return task.id;
  }

  obterContadorTarefasPorStatus(concluida: boolean): number {
    return this.tasks.filter(task => task.concluida === concluida).length;
  }
}
