# FinTrack - Backend

Este é o backend da aplicação **FinTrack**, desenvolvido em **.NET C#** utilizando **PostgreSQL** como banco de dados.

## 🚀 Tecnologias Utilizadas

- .NET 8
- C#
- PostgreSQL
- MediatR (Padrão Mediator)
- Entity Framework Core
- JWT para autenticação
- SOLID Principles

## 📂 Estrutura do Projeto

```
FinTrack/
│── FinTrack.API/           # Camada de API (Controllers)
│── FinTrack.Application/   # Camada de Aplicação (Casos de uso)
│── FinTrack.Domain/        # Camada de Domínio (Entidades, Interfaces, DTOs)
│── FinTrack.Infrastructure/ # Serviços, Segurança e Autenticação
```

## ⚙️ Configuração do Ambiente

1. **Clone o repositório**  
   ```bash
   git clone https://github.com/seu-usuario/FinTrack.git
   cd FinTrack
   ```

2. **Configurar o banco de dados PostgreSQL**  
   - Atualize o arquivo `appsettings.json` com a string de conexão.

3. **Aplicar as migrations**  
   ```bash
   dotnet ef database update
   ```

4. **Executar o projeto**  
   ```bash
   dotnet run --project FinTrack.API
   ```

## 🔑 Autenticação e Segurança

- A autenticação é baseada em **JWT**.
- As senhas são armazenadas como **hashes**.

## 📌 Endpoints
- **APLICACAOFINANCEIRA**

| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/AplicacaoFinanceira/create` | Cadastro de uma Aplicação Financeira |
| `POST` | `/api/AplicacaoFinanceira/gerar-historico` | Gera Histórico de uma Aplicação Financeira |
| `GET` | `/api/AplicacaoFinanceira/get-by-user/{usuarioId}` | Busca as aplicações financeiras do usuário |
| `GET` | `/api/AplicacaoFinanceira/get-by-id/{id}` | Busca a aplicação financeira pelo id |
| `GET` | `/api/AplicacaoFinanceira/get-by-nome/{nome}` | Busca a aplicação financeira pelo nome |
| `GET` | `/api/AplicacaoFinanceira/historico-by-id/{id}` | Busca o histórico pelo id |
| `GET` | `/api/AplicacaoFinanceira/historico-by-aplicacao-financeira/{aplicacaoFinanceiraId}` | Busca o histórico de determinada aplicação financeira |
| `GET` | `/api/AplicacaoFinanceira/aplicacao/{aplicacaoFinanceiraId}/creditos` | Busca os creditos feitos em determinada aplicação financeira |
| `GET` | `/api/AplicacaoFinanceira/aplicacao/{aplicacaoFinanceiraId}/debitos` | Busca os débitos feitos em determinada aplicação financeira |
| `GET` | `/api/AplicacaoFinanceira/{idUsuario}/{aplicacaoFinanceiraId}/resumo` | Resumo de determinada aplicação financeira por usuário |
| `PUT` | `/api/AplicacaoFinanceira/update` | Atualizar dados da aplicação financeira |
| `DELETE` | `/api/AplicacaoFinanceira/{id}` | Remover uma aplicação financeira |

- **AUTH**

| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/auth/login` | Autenticação do usuário |

- **CONTROLEMENSAL**

| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/ControleMensal/create` | Registrar o Controle Financeiro do Período (Mês) |
| `POST` | `/api/ControleMensal/registrar-credito` | Registrar o crédito do Controle Financeiro - relacionamento entre ControleMensal e Crédito (Fonte de Pagamento) |
| `POST` | `/api/ControleMensal/registrar-debito` | Registrar o Débito do Controle Financeiro - relacionamento entre ControleMensal e Débito |
| `GET` | `/api/ControleMensal/get-by-user{usuarioId}` | Busca os Controles Financeiros do usuário |
| `GET` | `/api/ControleMensal/get-by-id{id}` | Busca os dados do Controle Financeiro pelo Id |
| `GET` | `/api/ControleMensal/get-credito-by-id{id}` | Busca o total de crédito pelo id |
| `GET` | `/api/ControleMensal/get-debito-by-id{id}` | Busca o total de débito pelo id |
| `GET` | `/api/ControleMensal/getAll` | Busca todos os Controles Financeiros |
| `GET` | `/api/ControleMensal/get-credito-by-controle-mensal/{idControleMensal}` | Busca todos os créditos do Controle Mensal |
| `GET` | `/api/ControleMensal/get-debito-by-controle-mensal/{idControleMensal}` | Busca todos os débitos do Controle Mensal |
| `GET` | `/api/ControleMensal/resumo/{idUsuario}/{mes}/{ano}` | Resumo por um período informado do Controle Mensal de um usuário |
| `PUT` | `/api/ControleMensal/update` | Atualizar dados do Controle Financeiro (Mês) |
| `DELETE` | `/api/ControleMensal/delete/{id}` | Remover o Controle Financeiro (Mês) |

- **DEBITOMENSAL**

| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/DebitoMensal/create` | Cadastra um Débito |
| `GET` | `/api/DegitoMensal/get-by-user/{usuarioId}` | Débitos cadastrados pelo Usuário |
| `GET` | `/api/DegitoMensal/get-by-id/{usuarioId}` | Dados de um Débito pelo Id |
| `GET` | `/api/DegitoMensal/get-by-nome/{nome}` | Dados de um Débito pelo Nome |
| `PUT` | `/api/DegitoMensal/update` | Atualizar dados de um Débito |
| `DELETE` | `/api/DegitoMensal/delete/{id}` | Remover um Débito |

- **FONTEPAGAMENTO**

| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/FontePagamento/create` | Cadastra uma Fonte de Pagamento (Crédito) |
| `GET` | `/api/FontePagamento/get-by-user/{usuarioId}` | Fontes de Pagamento (Créditos) cadastrados pelo Usuário |
| `GET` | `/api/FontePagamento/get-by-id/{usuarioId}` | Dados de uma Fonte de Pagamento (Crédito) pelo Id |
| `GET` | `/api/FontePagamento/get-by-nome/{nome}` | Dados de uma Fonte de Pagamento (Crédito) pelo Nome |
| `PUT` | `/api/FontePagamento/update` | Atualizar dados de uma Fonte de Pagamento (Crédito) |
| `DELETE` | `/api/FontePagamento/delete/{id}` | Remover uma Fonte de Pagamento (Crédito) |

- **USUÁRIOS**

| Método | Rota | Descrição |
|--------|------|-----------|
| `POST` | `/api/Usuarios/create` | Cadastro de usuário |
| `GET` | `/api/Usuarios/get{email}` | Buscar Detalhes de um usuário pelo e-mail |
| `GET` | `/api/Usuarios/get{id}` | Buscar Detalhes de um usuário pelo id |
| `PUT` | `/api/Usuarios/update` | Atualizar dados do usuário |
| `DELETE` | `/api/Usuarios/delete/{id}` | Remover usuário |

---

📌 **Desenvolvido por [Maurício Dias de Carvalho Oliveira](https://github.com/mauridf)**  
