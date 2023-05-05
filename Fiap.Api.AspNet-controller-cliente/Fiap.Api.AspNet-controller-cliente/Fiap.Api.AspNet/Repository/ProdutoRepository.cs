using Fiap.Api.AspNet.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fiap.Api.AspNet.Repository
{



    public class ProdutoRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public ProdutoRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }
        public IList<ProdutoModel> Listar()
        {
            var lista = new List<ProdutoModel>();

            lista = dataBaseContext.Produto
                .ToList<ProdutoModel>();


            return lista;
        }

        public IList<ProdutoModel> ListarOrdenadoPorNome()
        {
            var lista = new List<ProdutoModel>();

            lista = dataBaseContext
                .Produto
                .OrderBy(p => p.Nome).ToList<ProdutoModel>();

            return lista;
        }

        public IList<ProdutoModel> ListarOrdenadoPorNomeDescendente()
        {
            var lista = new List<ProdutoModel>();

            lista = dataBaseContext
                .Produto
                .OrderByDescending(p => p.Nome).ToList<ProdutoModel>();

            return lista;
        }


        public IList<ProdutoModel> ConsultarPorPreco(string nome)
        {
            var lista = new List<ProdutoModel>();

            lista = dataBaseContext.Produto
                .Where (n => n.Nome == nome)
                .OrderBy (p => p.Preco)
                    .ToList<ProdutoModel>();
                   
            return lista;
        }

        public ProdutoModel ConsultarPorParteNome(String nomeParcial)
        {
            var produto = dataBaseContext.Produto.
                    Where(p => p.Nome.Contains(nomeParcial)).AsNoTracking().
                        FirstOrDefault<ProdutoModel>();

            return produto;
        }

        public ProdutoModel Consultar(int id)
        {
            var produto = new ProdutoModel();

            produto = dataBaseContext.Produto
                .Include(p => p.Mercado)
                    .Where(p => p.ProdutoId == id)
                        .FirstOrDefault();

            return produto;
        }

        public void Inserir(ProdutoModel produto)
        {
            dataBaseContext.Produto.Add(produto);
            dataBaseContext.SaveChanges();
        }

        public void Alterar(ProdutoModel produto)
        {
            dataBaseContext.Produto.Update(produto);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var produto = new ProdutoModel { ProdutoId = id };

                dataBaseContext.Produto.Remove(produto);
                dataBaseContext.SaveChanges();
            
        }

    }
}