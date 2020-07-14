using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Restaurante.Model
{
    class ComunicacaoBancoProdutos
    {
        private SQLiteConnection Conexao;

        public ComunicacaoBancoProdutos()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            Conexao = new SQLiteConnection(caminho);
            Conexao.CreateTable<ProdutoModel>();
        }

        public bool InsereProduto(ProdutoModel produto)
        {
            Conexao.Insert(produto);
            return true;
        }

        public bool EditaProduto(ProdutoModel produto)
        {
            Conexao.Update(produto);
            return true;
        }

        public void RemoveProduto(ProdutoModel produto)
        {
            Conexao.Delete(produto);
        }

        public List<ProdutoModel> ObterProdutos(string categoria)
        {
            List<ProdutoModel> produtos = Conexao.Table<ProdutoModel>().Where(a => a.Categoria == categoria).ToList();
            return produtos;
        }
    }
}
