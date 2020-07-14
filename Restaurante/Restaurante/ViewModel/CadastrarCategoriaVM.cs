using Plugin.Media;
using Plugin.Media.Abstractions;
using Restaurante.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Restaurante.ViewModel
{
    class CadastrarCategoriaVM
    {
        ComunicacaoBancoCategorias conexao = new ComunicacaoBancoCategorias();
        public Command AdicionarCategoriaCommand { get; set; }
        public List<CategoriaModel> OpcoesDeCategorias { get; set; }

        public CadastrarCategoriaVM()
        {
            AdicionarCategoriaCommand = new Command<object>(AdicionarCategoria);            
            PovoaListaDeOpcoes();
        }

        private void PovoaListaDeOpcoes()
        {

            OpcoesDeCategorias = new List<CategoriaModel>(){
                new CategoriaModel() { Titulo = "Bebidas",   Imagem = "Bebidas.png",  Descricao = "Refrigerantes, Drinks, Sucos"   },
                new CategoriaModel() { Titulo = "Pratos",    Imagem = "Pratos.png",   Descricao = "Massas, Carnes e Frutos do mar" },
                new CategoriaModel() { Titulo = "Fast Food", Imagem = "FastFood.png", Descricao = "Hamburguer, Batatas, Salgados"  },
                new CategoriaModel() { Titulo = "Saladas",   Imagem = "Saladas.png",  Descricao = "Folhas verdes, saladas Mistas"  }
            };
        }

        private void AdicionarCategoria(object obj)
        {
            CategoriaModel CategoriaEscolhida = obj as CategoriaModel;
            bool resp = conexao.InsereCategoria(CategoriaEscolhida);

            if (resp)
                App.Current.MainPage.DisplayAlert("Atenção", "Categoria Adicionada", "ok");
            else
                App.Current.MainPage.DisplayAlert("Atenção", "Categoria Ja existe", "ok");

            App.Current.MainPage.Navigation.PopModalAsync();
        }   
    }
}
