# FioTec Challenge - Epidemiological Reports API

Este projeto é uma Web API construída em ASP.NET Core que integra a API do Infodengue para obter dados epidemiológicos, registra as solicitações e relatórios em um banco de dados SQL Server e expõe diversos endpoints para listar e filtrar esses dados. 

A arquitetura do projeto segue os princípios do **Domain-Driven Design (DDD)**, organizando o sistema em camadas bem definidas, onde: 

- **Domain:** Contém as entidades de domínio (como `Report` e `User`) e regras de negócio, sem dependências de infraestrutura.
- **Infrastructure:** Responsável pelo acesso a dados, implementação dos repositórios e integração com serviços externos (por exemplo, o adapter para a API do Infodengue).
- **Application/Presentation:** Expõe a API via controllers e orquestra a lógica de negócio por meio dos serviços.

> **Exemplo de DDD:**  
> A entidade `Report` está definida no domínio, com propriedades como `RequestDate`, `Arbovirus`, `ReportedCases`, etc.  
> Essa entidade é manipulada pelos repositórios (definidos na camada de infraestrutura) e pelos serviços de aplicação, garantindo que as regras de negócio fiquem centralizadas no domínio e que a camada de apresentação permaneça desacoplada das implementações de persistência e integração externa.

---

## Tecnologias e Padrões Utilizados

- **C# e .NET Core:** Base para o desenvolvimento da API.
- **ASP.NET Core Web API:** Para criação dos endpoints REST.
- **Entity Framework Core:** ORM para acesso e persistência dos dados.
- **SQL Server:** Banco de dados utilizado (recomendado rodar via Docker).
- **Docker:** Para execução local do SQL Server.
- **HttpClient:** Para comunicação com a API externa do Infodengue.
- **Dependency Injection:** Para promover o desacoplamento entre as camadas.
- **Padrões de Projeto:**  
  - **Repository Pattern:** Abstrai o acesso aos dados.
  - **Service Layer:** Centraliza a lógica de negócio.
  - **Adapter Pattern:** Integra com serviços externos.
  - **DTOs (Data Transfer Objects):** Facilita a comunicação entre camadas.

---

## Endpoints

### Relatórios

- **POST `/api/reports`**  
  **Descrição:** Gera um novo relatório consultando a API do Infodengue, salvando os dados da consulta e do solicitante no banco de dados. Caso o usuário (identificado pelo CPF) não exista, ele é criado.  
  **Exemplo de Request:**
  ```json
  {
    "arbovirus": "Dengue",
    "startWeek": 10,
    "endWeek": 15,
    "ibgeCode": "3304557",
    "city": "Rio de Janeiro",
    "disease": "Dengue",
    "cpf": "12345678901",
    "userName": "John Doe"
  }

### Response
Retorna os detalhes do relatório criado (ID, data da solicitação, dados epidemiológicos, etc.).

### Endpoints

#### GET /api/reports
**Descrição:** Lista todos os relatórios salvos no banco de dados.

#### GET /api/reports/cities?cities=Rio de Janeiro,São Paulo
**Descrição:** Lista os dados epidemiológicos dos municípios do Rio de Janeiro e São Paulo.

#### GET /api/reports/ibge/{ibgeCode}
**Descrição:** Lista os dados epidemiológicos dos municípios filtrados pelo código IBGE informado.

#### GET /api/reports/total/cities?cities=Rio de Janeiro,São Paulo
**Descrição:** Retorna o total de casos epidemiológicos (campo ReportedCases) dos municípios do Rio de Janeiro e São Paulo.

#### GET /api/reports/total/arbovirus/{arbovirus}
**Descrição:** Retorna o total de casos epidemiológicos dos municípios filtrados pela arbovirose.

#### GET /api/reports/filter?ibgeCode=3304557&startWeek=10&endWeek=15&arbovirus=Dengue
**Descrição:** Lista os dados epidemiológicos dos municípios filtrados pelo código IBGE, semana de início, semana fim e arbovirose.

### Solicitantes (Users)

#### GET /api/users
**Descrição:** Lista todos os solicitantes cadastrados (usuários que realizaram solicitações de relatórios).

---

### Configuração

#### Connection String

No arquivo `appsettings.Development.json`, ajuste a connection string conforme sua configuração:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost,1433;Database=FioTecChallenge;User Id=sa;    Password=!Passw0rd;TrustServerCertificate=True;"
      }
    }


## Executando as Migrations

Certifique-se de estar na pasta `src` da solução e execute o seguinte comando para aplicar as migrations:

```bash
dotnet ef database update --project ./Infrastructure.Data/Infrastructure.Data.csproj --startup-project ./Presentation.Application/Presentation.Application.csproj --context AppDbContext
