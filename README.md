# Api-Ploomes

## Comando para rodar o migrations

```dotnet ef database update --project ApiPloomes.Infrastructure   --startup-project ApiPloomes.API```

## Exemplo de json Cadastro de categoria
```json
    {
    "name": "Bebidas",
    "imageUrl": "bebidas.jpg"
    }
 ```
 ## Exemplo de json Atualizar categoria
 ```json
  {
  	"id": 1,
    "name": "Bebidas",
    "imageUrl": "bebidas.jpg"
  }
  ```
   
 ## Exemplo de json Cadastro de produto
 ```json
  {
    "name": "Coca-Cola",
    "description": "Refrigerante de cola",
    "price": 9.56,
    "imageUrl": "coca.jpg",
    "stock": 70,
    "categoryId": 1
  }
 ```
 ## Exemplo de json Atualizar produto
 ```json
  {
  	"id": 1,
    "name": "Coca-Cola",
    "description": "Refrigerante de cola",
    "price": 9.56,
    "imageUrl": "coca.jpg",
    "stock": 70,
    "categoryId": 1
  } 
```