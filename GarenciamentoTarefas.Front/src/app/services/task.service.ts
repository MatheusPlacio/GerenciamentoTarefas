import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Task, CreateTask, UpdateTask } from '../models/task.model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private readonly API_URL = `${environment.apiUrl}/tasks`;

  constructor(private http: HttpClient) {}

  obterTarefas(concluida?: boolean): Observable<Task[]> {
    let params = new HttpParams();
    if (concluida !== undefined) {
      params = params.set('concluida', concluida.toString());
    }
    return this.http.get<Task[]>(this.API_URL, { params });
  }

  obterTarefa(id: number): Observable<Task> {
    return this.http.get<Task>(`${this.API_URL}/${id}`);
  }

  criarTarefa(tarefa: CreateTask): Observable<Task> {
    return this.http.post<Task>(this.API_URL, tarefa);
  }

  atualizarTarefa(id: number, tarefa: UpdateTask): Observable<Task> {
    return this.http.put<Task>(`${this.API_URL}/${id}`, tarefa);
  }

  excluirTarefa(id: number): Observable<void> {
    return this.http.delete<void>(`${this.API_URL}/${id}`);
  }
}
