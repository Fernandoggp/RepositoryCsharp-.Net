using Fiap.Api.AspNet.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fiap.Api.AspNet.Repository
{



    public class MercadoRepository
    {
        private readonly DataBaseContext dataBaseContext;

        public MercadoRepository(DataBaseContext ctx)
        {
            dataBaseContext = ctx;
        }

        public IList<MercadoModel> Listar()
        {
            var lista = new List<MercadoModel>();

            lista = dataBaseContext.Mercado
                  .ToList<MercadoModel>();

            return lista;

        }


        public MercadoModel Consultar(int id)
        {
            var mercado = dataBaseContext.Mercado.Find(id);

            return mercado;
        }

        public void Inserir(MercadoModel mercado)
        {
            dataBaseContext.Mercado.Add(mercado);
            dataBaseContext.SaveChanges();
        }


        public void Alterar(MercadoModel mercado)
        {
            dataBaseContext.Mercado.Update(mercado);
            dataBaseContext.SaveChanges();
        }

        public void Excluir(int id)
        {
            var mercado = new MercadoModel(id, "", "");

            dataBaseContext.Mercado.Remove(mercado);
            dataBaseContext.SaveChanges();

        }

    }
}
