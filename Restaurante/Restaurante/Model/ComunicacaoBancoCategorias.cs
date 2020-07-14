using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Restaurante.Model;

namespace Restaurante.Model
{
    class ComunicacaoBancoCategorias
    {
        private SQLiteConnection Conexao;

        public ComunicacaoBancoCategorias()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            Conexao = new SQLiteConnection(caminho);
            Conexao.CreateTable<CategoriaModel>();
        }

        public bool InsereCategoria(CategoriaModel categoria)
        {
            CategoriaModel Categ = Conexao.Table<CategoriaModel>().Where(a => a.Titulo == categoria.Titulo).FirstOrDefault();

            if (Categ != null) return false;

            Conexao.Insert(categoria);
            return true;
        }

        public void RemoveCategoria(CategoriaModel categoria)
        {
            Conexao.Delete(categoria);
        }

        public List<CategoriaModel> ObterCategorias()
        {
            List<CategoriaModel> categorias = Conexao.Table<CategoriaModel>().Where(a => a.Titulo != null).ToList();
            //List<CategoriaModel> categorias = Conexao.Table<CategoriaModel>().ToList();
            return categorias;
        }
    }
}
