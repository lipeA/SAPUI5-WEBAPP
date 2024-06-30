# SAPUI5 NotaFiscal Application

Este projeto é um aplicativo web construído usando SAPUI5 para exibir dados de notas fiscais e informações relacionadas a clientes e fornecedores. O backend foi desenvolvido com ASP.NET Core e PostgreSQL.

## Visão Geral

O aplicativo tem como objetivo listar as notas fiscais, exibindo a descrição, valor, e o nome do cliente associado à nota fiscal. A estrutura do projeto inclui:

- Frontend desenvolvido com SAPUI5
- Backend desenvolvido com ASP.NET Core
- Banco de dados PostgreSQL

## Estrutura do Projeto

### Backend

- **Controllers**: Contém os controladores que gerenciam as solicitações HTTP.
- **Data**: Contém as classes de contexto do banco de dados.
- **Migrations**: Contém as migrações do Entity Framework Core.
- **Models**: Contém os modelos de dados usados pelo Entity Framework Core.

### Frontend

- **view**: Contém as views SAPUI5.
- **controller**: Contém os controladores SAPUI5.
- **i18n**: Contém os arquivos de internacionalização.
- **localService**: Contém arquivos de metadados locais para serviços OData.

## Configuração do Projeto

### Backend

1. **Clone o repositório**
    ```bash
    git clone https://github.com/lipeA/SAPUI5-WEBAPP.git
    cd seu-repositorio/backend
    ```

2. **Instale as dependências**
    ```bash
    dotnet restore
    ```

3. **Configure o banco de dados**
    Atualize a string de conexão no arquivo `appsettings.json` para apontar para seu banco de dados PostgreSQL.

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=SuaBaseDeDados;Username=SeuUsuario;Password=SuaSenha"
    }
    ```

4. **Execute as migrações**
    ```bash
    dotnet ef database update
    ```

5. **Execute o aplicativo**
    ```bash
    dotnet run
    ```

### Frontend

1. **Clone o repositório**
    ```bash
    git clone https://github.com/lipeA/SAPUI5-WEBAPP.git
    cd seu-repositorio/frontend
    ```

2. **Abra o projeto no VSCode**
    ```bash
    code .
    ```

3. **Configure o `manifest.json`**
    Atualize a URI do serviço OData para apontar para seu backend local.
    ```json
    "dataSources": {
      "mainService": {
        "uri": "http://localhost:5240/odata",
        "type": "OData",
        "settings": {
          "annotations": [
            "annotation"
          ],
          "localUri": "localService/metadata.xml",
          "odataVersion": "4.0"
        }
      }
    }
    ```

4. **Execute o aplicativo**
    Utilize o Live Server do VSCode ou um servidor web de sua preferência para servir o frontend.

## Endpoints da API

### Cliente

- `GET /api/Cliente`: Obtém a lista de clientes.
- `GET /api/Cliente/{id}`: Obtém um cliente específico pelo ID.

### Fornecedor

- `GET /api/Fornecedor`: Obtém a lista de fornecedores.
- `GET /api/Fornecedor/{id}`: Obtém um fornecedor específico pelo ID.

### Nota Fiscal

- `GET /api/NotaFiscal`: Obtém a lista de notas fiscais.
- `GET /api/NotaFiscal/{id}`: Obtém uma nota fiscal específica pelo ID.

## Estrutura das Tabelas

### Cliente

- `id`: UUID do cliente.
- `nome`: Nome do cliente.

### Fornecedor

- `id`: UUID do fornecedor.
- `nome`: Nome do fornecedor.

### Nota Fiscal

- `id`: UUID da nota fiscal.
- `ClienteId`: UUID do cliente associado.
- `FornecedorId`: UUID do fornecedor associado.
- `descricao`: Descrição da nota fiscal.
- `valor`: Valor da nota fiscal.

## Funcionamento

Ao iniciar o aplicativo, a view inicial carregará a lista de notas fiscais. Cada nota fiscal exibirá a descrição, o valor e o nome do cliente correspondente. A integração é feita via fetch API para garantir que os dados sejam obtidos corretamente do backend.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
