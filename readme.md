# API de Tarefas

Esta é uma API desenvolvida em C# com ASP.NET e utiliza o banco de dados PostgreSQL para gerenciar tarefas de usuários. A API segue o padrão de design Repository Pattern para interagir com o banco de dados. Abaixo estão detalhadas as funcionalidades da API, suas rotas e como utilizá-la.

## Funcionalidades

1. Cadastro de Usuário: Permite aos usuários se cadastrarem fornecendo um nome, e-mail e senha.
2. Autenticação: Permite aos usuários autenticarem-se na aplicação através de um e-mail e senha, gerando um token JWT.
3. Edição de Usuário: Usuários autenticados podem editar suas informações fornecendo o token JWT como autenticação e o ID do usuário para atualização.
4. Exclusão de Usuário: Usuários autenticados podem excluir suas contas fornecendo o token JWT como autenticação e o ID do usuário para exclusão.
5. Listagem de Tarefas: Permite listar as tarefas disponíveis.
6. Criação de Tarefa: Usuários autenticados podem criar novas tarefas fornecendo o token JWT como autenticação e informações da tarefa, como nome, descrição e status.
7. Edição de Tarefa: Usuários autenticados podem editar tarefas existentes fornecendo o token JWT como autenticação e o ID da tarefa para atualização.
8. Exclusão de Tarefa: Usuários autenticados podem excluir tarefas existentes fornecendo o token JWT como autenticação e o ID da tarefa para exclusão.

## Rotas

Abaixo estão as rotas disponíveis na API:

1. **Cadastrar Novo Usuário**
   - Rota: `POST /api/newUser`
   - Parâmetros de entrada (JSON):
     ```
     {
       "name": "Nome do Usuário",
       "email": "exemplo@email.com",
       "password": "senha123"
     }
     ```
   - Resposta (JSON): O usuário cadastrado com sucesso ou uma mensagem de erro.

2. **Autenticar Usuário**
   - Rota: `POST /api/auth`
   - Parâmetros de entrada (JSON):
     ```
     {
       "email": "exemplo@email.com",
       "password": "senha123"
     }
     ```
   - Resposta (JSON): Token JWT para autenticação ou mensagem de erro em caso de credenciais inválidas.

3. **Editar Usuário**
   - Rota: `PUT /api/user/:id`
   - Cabeçalho (Header):
     ```
     Authorization: Bearer [token JWT]
     ```
   - Parâmetros de entrada (JSON):
     ```
     {
       "name": "Novo Nome do Usuário",
       "email": "novoemail@email.com",
       "password": "novasenha123"
     }
     ```
   - Resposta (JSON): Usuário atualizado com sucesso ou mensagem de erro se não autorizado ou ID inválido.

4. **Excluir Usuário**
   - Rota: `DELETE /api/user/:id`
   - Cabeçalho (Header):
     ```
     Authorization: Bearer [token JWT]
     ```
   - Resposta (JSON): Usuário excluído com sucesso ou mensagem de erro se não autorizado ou ID inválido.

5. **Listar Tarefas**
   - Rota: `GET /api/tasks`
   - Cabeçalho (Header):
     ```
     Authorization: Bearer [token JWT]
     ```
   - Resposta (JSON): Lista de tarefas disponíveis para o usuário autenticado.

6. **Criar Nova Tarefa**
   - Rota: `POST /api/newTask`
   - Cabeçalho (Header):
     ```
     Authorization: Bearer [token JWT]
     ```
   - Parâmetros de entrada (JSON):
     ```
     {
       "name": "Nome da Tarefa",
       "description": "Descrição da Tarefa",
       "status": 1
     }
     ```
     - Status 1: Para Fazer
     - Status 2: Fazendo
     - Status 3: Finalizado
   - Resposta (JSON): Tarefa criada com sucesso ou mensagem de erro se não autorizado ou dados inválidos.

7. **Editar Tarefa**
   - Rota: `PUT /api/task/:id`
   - Cabeçalho (Header):
     ```
     Authorization: Bearer [token JWT]
     ```
   - Parâmetros de entrada (JSON):
     ```
     {
       "name": "Novo Nome da Tarefa",
       "description": "Nova Descrição da Tarefa",
       "status": 2
     }
     ```
     - Status 1: Para Fazer
     - Status 2: Fazendo
     - Status 3: Finalizado
   - Resposta (JSON): Tarefa atualizada com sucesso ou mensagem de erro se não autorizado ou ID inválido.

8. **Excluir Tarefa**
   - Rota: `DELETE /api/task/:id`
   - Cabeçalho (Header):
     ```
     Authorization: Bearer [token JWT]
     ```
   - Resposta (JSON): Tarefa excluída com sucesso ou mensagem de erro se não autorizado ou ID inválido.

## Uso

1. Certifique-se de ter o ambiente configurado com o .NET SDK e o PostgreSQL instalado.
2. Clone o repositório da API e acesse a pasta do projeto.
3. Configure a string de conexão com o banco de dados PostgreSQL no arquivo `appsettings.json`.
4. Execute as migrações para criar o banco de dados e as tabelas:
