# PRJ-ProdamII

Projeto feito para o teste técnico para minha segunda tentativa de ingresso na PRODAM-SP. O teste da primeira tentativa está anexado no documento da prova :) 

## O teste

O teste consiste numa prova téorica, uma web api desenvolvida a partir da ideia de negócios escolhida das opções diposnibilizadas no arquivo: `prova.pdf` e um frontend bem básico para consumir a api. 

>Lembrando que a api pode ser consumida somente com Swagger, caso não queira testar com o frontend!

## Stack utilizada

**Back-end:** .NET, Entity Framework Core

**Frontend:** Javascript, ReactJS

**Banco de dados:** Microsoft SQL server



## Rodando localmente

Clone o projeto

```bash
  git clone https://github.com/LucasMend0n/PRJ-ProdamII.git
```

### Backend

Após isso, altere a string de conexão no arquivo `appsetings.json` na propriedade  `ConnectionStrings` para a string de conexão da sua instância local do SQL Server

```json
  
  "ConnectionStrings": {
    "Default": "INSIRA SUA STRING DE CONEXÃO DO SQL SERVER"
  },

```
Instale as dependências e inicie o projeto
```bash
  dotnet run
```

Depois, vamos configurar o frontend

### FrontEnd

acesse a pasta `frontend`

Instale as dependências 
```bash
  npm install
```

configure a url de onde estiver rodando o backend no arquivo `api.js` para que ele econtre e possa fazer as requisições para o servidor certo!

Execute a aplicação web em modo dev
```bash
  npm run dev
```

Daí é só testar! 




