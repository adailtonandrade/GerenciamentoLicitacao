
# Sistema de Gerenciamento de Licitações

Apenas um CRUD de Licitações, utilizando Aspnet Core MVC, com paginação, ordenação e filtragem server-side.

## Stack utilizada

**Front-end:** Razor Pages, HTML5, CSS, JavaScript, JQuery, Bootstrap, Boostrap-Table, ToastR

**Back-end:** C#, .Net 8, Entity Framework Core, DDD, Repository, Unit of Work

**Banco de dados:** SQL Server

## Instalação

### Atenção: O projeto esta utilizando o .Net 8, versão mais recente e de longo prazo lançada, porem ela foi lançada há algumas semanas, então certifique-se de ter a sdk instalada

[Clique Aqui para acessar a página de download](https://dotnet.microsoft.com/pt-br/download)

#
Baixe ou clone o projeto, verifique o arquivo appsettings.Development.json e altere a connection string caso necessário, a que está no projeto, esta utilizando o LocalDB do SQL Server Express, o projeto possui docker, mas docker não funciona com o LocalDB, então se for utilizar o docker, você pode criar um container do SQL Server no docker, não use o LocalDB ou o projeto não irá funcionar como esperado.

Vamos lá então, com tudo configurado, chegou a hora de rodar a aplicação:

Compile projeto e depois execute as migrações usando o comando abaixo no console do gerenciador de pacotes do Visual Studio 2022, lembre de selecionar o projeto padrão para 4 - Infra\4.1 - Data\Data antes de executar o comando abaixo.
![Console do Gerenciador de Pacote](https://github.com/adailtonandrade/GerenciamentoLicitacao/assets/10591381/8e84c84e-8b33-49be-aa9d-509c1f6a3771)

```bash
  update-database
```

Depois das migrations aplicadas, você pode executar o projeto clicando no play do Visual Studio, após isso o sistema deve carregar na tela de Home

![Deploy](https://github.com/adailtonandrade/GerenciamentoLicitacao/assets/10591381/a1c65879-6598-4409-92fa-5abe93bbb498)

## Screenshots
![Home Page](https://github.com/adailtonandrade/GerenciamentoLicitacao/assets/10591381/3cb13982-61b0-4975-bc1f-0d71e6b5eb51)

![Tela de Listagem de Licitações - Vazia](https://github.com/adailtonandrade/GerenciamentoLicitacao/assets/10591381/4dbc0037-f869-4ca3-af58-e6c36c84202c)

![Tela de Cadastro de Licitação](https://github.com/adailtonandrade/GerenciamentoLicitacao/assets/10591381/e191dac5-725d-4dc0-9a4a-89f5e0f66ff0)

Para cadastrar uma nova licitação, basta inserir o número da mesma e a descrição, a data de abertura será cadastrada pelo sistema de forma automática, se a licitação for cadastrada com sucesso, você verá a tela abaixo com o Toast Notification confirmando o cadastro da licitação

![Licitação Cadastrada](https://github.com/adailtonandrade/GerenciamentoLicitacao/assets/10591381/e4e609d6-1321-4ecd-a014-eb830328f4a9)

A tela de Listagem possui paginação, ordenação e filtragem pelo lado do servidor, ou seja, se você clicar em coluna para ordernar por ela, será feita uma requisição para o servidor e ele irá executar a filtragem, ordenação e paginação direto no banco, trazendo para tela apenas os itens necessários.

![Tela de Listagem de Licitações com a Paginação](https://github.com/adailtonandrade/GerenciamentoLicitacao/assets/10591381/89352eb9-9300-4078-805d-8b4aba4c20e6)

Aqui um exemplo de como fica a tela de listagem com a paginação ativada, se quiser desativar uma licitação, basta clicar no botão desativar e aguardar a notificação de confirmação, ela também será atualizada na tabela e ficará com a opção de Reativar disponível,
Se você clicar em Reativar, a licitação será reativada.

![Tela de Edição de Licitação](https://github.com/adailtonandrade/GerenciamentoLicitacao/assets/10591381/0062456d-b362-496e-b2fd-6169fe978909)

Acho que é isso por enquanto.
