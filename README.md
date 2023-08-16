# SampleSqlTrigger

O SampleSqlTrigger é um projeto desenvolvido demonstrando a utilização do atributo SqlTrigger em uma Azure Function.

## Tecnologias e Bibliotecas

- [.NET 7](https://dotnet.microsoft.com/pt-br/download)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/get-started/overview/install)
- [Bogus](https://github.com/bchavez/Bogus)
- [Microsoft.Azure.WebJobs.Extensions.Sql - Preview](https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-azure-sql?tabs=in-process%2Cextensionv4&pivots=programming-language-csharp)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)

## Qual é o problema resolvido?

Pense em um cenário que você precise fazer algo quando acontecer uma operação no banco de dados, seja um insert, update ou delete. Com esse Trigger habilitado é possível fazer o rastreio dessas operações no banco de dados SQL.

## Funcionalidades

**API**: Inclusão de um registro no banco de dados ou 10 registros dinamicamente, update no registro desejado e exclusão do registro

**Function**. Leitura do registro inserido, alterado ou excluido do banco de dados.

------------------------------------------

## Como Executar o projeto?
1. **Clone o repositório do GitHub:**
```
https://github.com/Allanhenriquee/SampleSqlTrigger.git
```
2. **Abra o projeto em sua IDE de prefêrencia.**

3. **Execute o docker desktop. Com o docker funcionando acesse a pasta onde contém o arquivo do docker compose e execute o seguinte comando:**
```
docker-compose up
```
![image](https://github.com/Allanhenriquee/SampleSqlTrigger/assets/52016301/97081b3a-c303-4c51-b466-74769dea68f4)

4. **Navegue até a pasta onde está o projeto Register.API e execute os comandos para execusão de migration:**
```
dotnet ef migrations add Initial
```
```
dotnet ef database update
```
![image](https://github.com/Allanhenriquee/SampleSqlTrigger/assets/52016301/e5e2238f-a0e8-4b21-800e-5e24e7460498)

4. **Acesse o SQL com os dados da connectionString no appsettings.Development.json**
   
![image](https://github.com/Allanhenriquee/SampleSqlTrigger/assets/52016301/1c7fc7b5-93cc-4051-94da-55ece3bb9f42)

![image](https://github.com/Allanhenriquee/SampleSqlTrigger/assets/52016301/faefd226-f7fa-4287-af54-c99dfe327ffe)

5. **Clique com o botão direito do mouse no banco de dados e selecione a opção new query.**

![image](https://github.com/Allanhenriquee/SampleSqlTrigger/assets/52016301/8f12d253-fb69-4488-9076-0abd1d7c34c3)

6. **Execute o seguinte comando no banco de dados:**
```
ALTER DATABASE [Registers]
SET CHANGE_TRACKING = ON
(CHANGE_RETENTION = 2 DAYS, AUTO_CLEANUP = ON);

ALTER TABLE [dbo].[Customers]
ENABLE CHANGE_TRACKING;
```
![image](https://github.com/Allanhenriquee/SampleSqlTrigger/assets/52016301/d33a7c49-2bd8-4584-8e4d-8e2c1f875d8c)

7. **Execute o projeto da Function e depois execute o projeto da API.**

8. **Faça as requisições através da interface do swagger e veja o console do projeto da function exibindo os dados e operações realizadas.** 

![image](https://github.com/Allanhenriquee/SampleSqlTrigger/assets/52016301/03565a0b-60eb-4e65-a158-0172354a440e)

------------------------------------------

## Interface do Swagger.
![image](https://github.com/Allanhenriquee/SampleSqlTrigger/assets/52016301/32566998-3b2e-4579-b4a7-7ba5a5e10739)

------------------------------------------

## Estrutura do Projeto
![image](https://github.com/Allanhenriquee/SampleSqlTrigger/assets/52016301/8ccd9252-6dfc-4692-947f-babd35487cd7)
