WebCashback (desafio back-end)
Desenvolvido por Ariclines Massissa Antonio (ari.macissa@gmail.com)
  

Dados gerais do projeto:

1.0 Banco de dados utilizado: MySQL;
1.1 Nome do banco: webcashback;
1.2 Usuário / senha: desenvolvedor / 1234567.

2.0 Framework utilizado: Asp.Net Core 3.1;
2.1 ORM: Entity Framework 3.1;
2.2 Driver de banco: Pomelo.EntityFrameworkCore.MySql 3.1;

Rotas:

1.0 Rota para cadastrar novo revendedor: https://localhost:5001/api/revendedor/cadastrar
1.1 Método: POST
1.2 Modelo JSON para envio no corpo da requisição: 
{
"Nome":"Ari",
"CPF":00009990912,
"Email":"ari.macissa@gmail.com",
"Senha":"abcd1234"
}

2.0 Rota para fazer login: https://localhost:5001/api/revendedor/login
2.1 Método: POST
2.2 JSON modelo no corpo da requisição:
{
"Email":"ari.macissa@gmail.com",
"Senha":"abcd1234"
}

3.0 Rota para cadastrar nova compra: https://localhost:5001/api/compras/cadastrar
3.1 Método: POST
3.2 JSON modelo no corpo da requisição:
{
"DataCompra":"2020-08-16",
"ValorCompra":300.00,
"RevendedorId":1
}
3.3 Formato da autenticação (token)  no cabeçalho (headers) da requisição:
"Authorization":"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFyaS5tYXN0aWlhQGdtYWlsLmNvbSIsInJvbGUiOiJhYmNkZWZnaDEyMyIsIm5iZiI6MTU5NzcwNTU5NywiZXhwIjoxNTk3NzEyNzk3LCJpYXQiOjE1OTc3MDU1OTd9._dh_LUwatDofg6lLYZcPb1DCjG1BdlTu-sasV856-Yw"
Obs.: é sempre Bearer + espaço em branco + token.

4.0 URL para lista de compras do revendedor: https://localhost:5001/api/compras/lista/<codigorevendedor>
Obs.: o código seria o Id, que retorna quando é feito o login.
4.1 Método: GET

5.0 Rota para exibir cashback acumulado: https://localhost:5001/api/compras/cashback/<cpf>
5.1 Método: GET



Importante: Para criar e setar dados na base precisa criar no MySQL o usuário e senha especificados acima, ou configurar com um usuário próprio já existente; depois é só  sincronizar a migration que já vem pronta: dotnet ef database update; e por fim rodar a aplicação: dotnet run

O usuário / revendedor e compra utilizados nos modelos serão setados ao rodar a migration.

Dúvidas estou à disposição.
