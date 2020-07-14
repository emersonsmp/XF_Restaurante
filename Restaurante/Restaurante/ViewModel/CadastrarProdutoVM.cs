using Plugin.Media;
using Plugin.Media.Abstractions;
using Restaurante.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Restaurante.ViewModel
{
    class CadastrarProdutoVM : INotifyPropertyChanged
    {
        ComunicacaoBancoProdutos conexao = new ComunicacaoBancoProdutos();
        public Command AdicionarProdutoCommand { get; set; }
        public Command btnSelecionarImagemCommand { get; set; }

        public bool _isVisiblePlaceHolder { get; set; }
        public bool isVisiblePlaceHolder { 
            get 
            { 
                return _isVisiblePlaceHolder; 
            } 
            set 
            { 
                _isVisiblePlaceHolder = value; 
                OnPropertyChanged("isVisiblePlaceHolder"); 
            } 
        }

        public string _imgFoto { get; set; }
        public string imgFoto
        {
            get { return _imgFoto; }
            set
            {
                _imgFoto = value; OnPropertyChanged("imgFoto");
            }
        }
        public ProdutoModel produto { get; set; }

        public CadastrarProdutoVM(String categoria)
        {
            isVisiblePlaceHolder = true;
            produto = new ProdutoModel();
            produto.Categoria = categoria;
            AdicionarProdutoCommand = new Command(AdicionarProduto);
            btnSelecionarImagemCommand = new Command(btnSelecionarImagemAsync);
        }

        private void AdicionarProduto()
        {
            conexao.InsereProduto(produto);
            App.Current.MainPage.DisplayAlert("Aviso","Produto Cadastrado","OK");
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        private async void btnSelecionarImagemAsync()
        {
            if (CrossMedia.Current.IsTakePhotoSupported)
            {
                MediaFile imagem = await CrossMedia.Current.PickPhotoAsync();

                produto.Imagem = imagem.Path.ToString();

                if (imagem != null)
                {
                    isVisiblePlaceHolder = false;
                    imgFoto = produto.Imagem;
                }
            }

        }
                       
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }

    }
}
