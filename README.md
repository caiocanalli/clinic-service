# clinic-service

### Visão geral

clinic-service é uma API desenvolvida em ASP.NET Core Web.API 5.0 que funciona para o cadastro
de laboratórios e exames.

 - Estruturado em camadas.
 - Aplica conceitos de DDD (Domain Driven Design) para modelar entidades.
 - Uitliza SQL Server como banco de dados.

### Organização

A estrutura do projeto é dividida nas seguintes camadas:

 - Application: camada responsável pelos casos de uso.
 - Domain: camada responsável pelo domínio da aplicação.
 - Infra: contêm toda a infraestrutura necessária para auxiliar os casos de uso. Busca de informações externas, injeção de dependência etc.
 - Services: camada onde reside o serviço que expõe as funcionalidades do projeto.

### Padrões e boas práticas

O projeto foi desenvolvido sempre levando em consideração os princípios: SOLID, KISS, DRY etc.  
Utilização de Repository Pattern, DDD e Fluent Validation.

### Execução

Para executar o projeto, é necessário o docker-compose instalado na máquina.  
Neste [repositório](https://github.com/caiocanalli/clinic-stack), é possível baixar os arquivos do docker-compose para executar o projeto.  
Baixe os projetos clinic-stack, clinic-app e clinic-service no mesmo diretório. Entre no projeto clinic-stack, na pasta docker-compose e execute o comando:

A senha do banco de dados pode ser alterada nos arquivos dos projetos clinic-stack e clinic-service, em docker-compose.yml e appsettings.Docker.json, respectivamente.
Pesquise por Y0urP@sswordHere.

```sh
docker-compose up
```

O projeto será executado na porta 5000.

