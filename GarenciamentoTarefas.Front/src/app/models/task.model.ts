export interface Task {
  id: number;
  titulo: string;
  descricao?: string;
  dataCriacao: Date;
  concluida: boolean;
}

export interface CreateTask {
  titulo: string;
  descricao?: string;
}

export interface UpdateTask {
  titulo: string;
  descricao?: string;
  concluida: boolean;
}
