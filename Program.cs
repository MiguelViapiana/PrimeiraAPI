
using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//Produto produto = new Produto();
//produto.Nome = "Bolacha";
//Console.WriteLine(produto.Nome);
// produto.setNome("Bolacha");
// Console.WriteLine(produto.getNome());

var produtos = new List<Produto>
{
    new Produto("Celular", "IOS", 45),
    new Produto("Celular", "Android", 56.8),
    new Produto("Televisão", "LG", 240),
    new Produto("Placa de vídeo", "NVIDIA", 1200)
};


//Funcionalidades da aplicação - EndPoints
// GET: http://localhost:5169/
app.MapGet("/", () => "API de produtos");

// GET: http://localhost:5169/produtos/listar
app.MapGet("/produtos/listar", () => produtos);

// GET: http://localhost:5169/produtos/buscar/nomedoproduto
app.MapGet("/produtos/buscar/{nome}", ([FromRoute]string nome) =>
    {
        for (int i = 0; i < produtos.Count; i++)
        {
            if(produtos[i].Nome == nome)
            {
                //retronar o produto encontrado
                return Results.Ok(produtos[i]);
            }
        }
        return Results.NotFound("Produto não encontrado");
    }
);


// GET: http://localhost:5169/produtos/cadastrar
app.MapPost("/produtos/cadastrar", () => "Cadastro de produtos");

//Exercicio 
//1)Cadastar um produto
//A) Pelo URL
//B) Pelo corpo
//2) Remeção do produto
//3) Alteração do produto
app.Run();

