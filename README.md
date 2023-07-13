# PRJ-ProdamII

Projeto feito para o teste técnico para minha segunda tentativa de ingresso na PRODAM-SP. 

## O teste

O teste consiste numa prova téorica e um uma web api desenvolvida a partir da ideia de negócios escolhida das opções diposnibilizadas no arquivo: `prova.pdf`

## Stack utilizada

**Back-end:** .NET, Entity Framework Core

**Banco de dados:** Microsoft SQL server



## Rodando localmente

Clone o projeto

```bash
  git clone https://github.com/LucasMend0n/PRJ-ProdamII.git
```

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

Daí é só testar! 




