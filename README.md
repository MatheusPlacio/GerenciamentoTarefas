# 🎯 Gerenciamento de Tarefas

Sistema completo de gerenciamento de tarefas (To-Do App) desenvolvido com **Angular 16** (frontend) e **ASP.NET Core** (backend).

## 🚀 Como Executar

### Backend (ASP.NET Core)

1. **Execute a API**:
   ```bash
   dotnet run
   ```
   - A API estará disponível em: `https://localhost:7299`
   - Swagger UI: `https://localhost:7299/swagger/index.html`

   2. **Configure a string de conexão no appsettings** troque o 'MATHEUS\\SQLEXPRESS', para o nome que estiver em sua máquina no SqlServer.
     "DefaultConnection": "Server=MATHEUS\\SQLEXPRESS;Database=GerenciamentoProjetos;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
      A migration já está criada, vá em ferramentas no visual studio > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes > Em projeto padrão escolha: GarenciamentoTarefas.Infra
	  e execute o comando 'update-database'.

### Frontend (Angular)

1. **Navegue para o diretório do Angular**:
   ```bash
   cd GerenciamentoTarefas.Front
   ```

2. **Instale as dependências** (se necessário):
   ```bash
   npm install
   ```

3. **Execute o frontend**:
   ```bash
   npm start
   ```
   - O frontend estará disponível em: `http://localhost:4200`

## 🔐 Credenciais de Acesso

- **Usuário**: `admin`
- **Senha**: `123456`

> As credenciais já estão pré-preenchidas na tela de login para facilitar o teste.

## 📋 Funcionalidades

### ✅ Funcionalidades Obrigatórias
- [x] **CRUD Completo** de tarefas (Criar, Listar, Editar, Excluir)
- [x] **Autenticação JWT** com usuário fixo
- [x] **Interface responsiva** e moderna
- [x] **Validações** no frontend e backend
- [x] **Filtros** por status (Todas, Pendentes, Concluídas)
- [x] **Marcar tarefa como concluída**

### 🎉 Diferenciais Implementados
- [x] **Design moderno** com animações e boa UX
- [x] **Validações robustas** nos formulários
- [x] **Filtros de pesquisa** por status
- [x] **Documentação Swagger** completa
- [x] **Interceptor JWT** automático
- [x] **Guards de autenticação**
- [x] **Princípios Clean Code** aplicados
- [x] **Responsividade no mobile**

## 🛠️ Tecnologias Utilizadas

### Frontend
- **Angular 16.2.13**
- **TypeScript**
- **Reactive Forms**
- **RxJS**
- **CSS3** com animações

### Backend
- **ASP.NET Core 8**
- **Entity Framework Core 8.0.0**
- **SQL Server**
- **JWT Authentication**
- **Swagger/OpenAPI**

## 📁 Estrutura do Projeto

```
GerenciamentoTarefas/
├── GerenciamentoTarefas.Api/          # API ASP.NET Core
├── GerenciamentoTarefas.Application/   # Camada de aplicação
├── GerenciamentoTarefas.Domain/        # Entidades de domínio
├── GerenciamentoTarefas.Infra/         # Infraestrutura e dados
└── GerenciamentoTarefas.Front/         # Frontend Angular
```

## 🎨 Interface

A aplicação possui uma interface moderna e intuitiva com:
- **Tela de login** com credenciais pré-preenchidas
- **Dashboard** com lista de tarefas
- **Filtros** por status (Todas, Pendentes, Concluídas)
- **Formulários** para criar/editar tarefas
- **Animações** e feedback visual

## 📚 API Endpoints

- `POST /api/auth/login` - Autenticação
- `GET /api/tasks` - Listar tarefas
- `GET /api/tasks/{id}` - Buscar tarefa específica
- `POST /api/tasks` - Criar tarefa
- `PUT /api/tasks/{id}` - Atualizar tarefa
- `DELETE /api/tasks/{id}` - Excluir tarefa

## 🔧 Requisitos

- **.NET 8 SDK**
- **Node.js 18.20.4**
- **Angular CLI 16.2.13**
- **SQL Server**

## 📝 Notas

- A migration já está criada, vá em ferramentas no visual studio > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes > Em projeto padrão escolha: GarenciamentoTarefas.Infra
  e execute o comando 'update-database'.
- As credenciais de teste estão fixas no sistema
- A aplicação roda nas portas padrão (7299 para API, 4200 para frontend)
- O design prioriza usabilidade e experiência do usuário
