using Restaurante.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Restaurante.ViewModel
{
    class EditarProdutoVM
    {
        readonly private List<CategoriaModel> OpcoesDeCategorias = new List<CategoriaModel>() {
            new CategoriaModel() { Titulo = "Bebidas",   Imagem = "Bebidas.png" },
            new CategoriaModel() { Titulo = "Pratos",    Imagem = "Pratos.png"  },
            new CategoriaModel() { Titulo = "Fast Food", Imagem = "FastFood"    }
        };

        ComunicacaoBancoProdutos conexao = new ComunicacaoBancoProdutos();
        public ProdutoModel Produto { get; set; }
        public Command AdicionarProdutoCommand { get; set; }
        public Command RemoverProdutoCommand   { get; set; }
        public int Categoria { get; set; }

        public EditarProdutoVM(ProdutoModel produto)
        {
            Produto = produto;
            AdicionarProdutoCommand = new Command(AdicionarProduto);
            RemoverProdutoCommand   = new Command(RemoverProduto);
        }

        private void AdicionarProduto()
        {
            Produto.Categoria = OpcoesDeCategorias[Categoria].Titulo;
            conexao.EditaProduto(Produto);
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        private void RemoverProduto()
        {
            conexao.RemoveProduto(Produto);
            App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
