using Restaurante.Model;
using Restaurante.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Restaurante.ViewModel
{
    class PaginaDeProdutosVM: INotifyPropertyChanged
    {
        public Command EditarProdutoCommand {get; set;}
        public Command AdicionarNovaProdutoCommand { get; set; }

        public ObservableCollection<ProdutoModel> _ProdutosAtivosDoMercado { get; set; }
        public ObservableCollection<ProdutoModel> ProdutosAtivosDoMercado { 
            get { return _ProdutosAtivosDoMercado; } 
            set { _ProdutosAtivosDoMercado = value; OnPropertyChanged("ProdutosAtivosDoMercado"); 
            } 
        }

        ComunicacaoBancoProdutos conexao = new ComunicacaoBancoProdutos();

        public bool _isVisibleListaDeProdutos { get; set; }
        public bool isVisibleListaDeProdutos { 
            get { 
                return _isVisibleListaDeProdutos; 
            } 
            set { 
                _isVisibleListaDeProdutos = value; 
                OnPropertyChanged("isVisibleListaDeCategorias"); 
            } 
        }

        public bool _isVisibleAviso { get; set; }
        public bool isVisibleAviso { 
            get { 
                return _isVisibleAviso; 
            } 
            set { 
                _isVisibleAviso = value; OnPropertyChanged("isVisibleAviso"); 
            } 
        }

        public string _categoria { get; set; }

        public PaginaDeProdutosVM(string categoria)
        {
            _categoria = categoria;
            EditarProdutoCommand = new Command<object>(EditarProduto);
            AdicionarNovaProdutoCommand = new Command(AdicionarNovoProduto);
            PovoarTelaDeProdutos();
        }

        private void PovoarTelaDeProdutos()
        {

            List<ProdutoModel> _produtos = conexao.ObterProdutos(_categoria);
            ProdutosAtivosDoMercado = new ObservableCollection<ProdutoModel>(_produtos);

            if (ProdutosAtivosDoMercado != null)
            {
                isVisibleListaDeProdutos = true;
            }
            else
            {
                isVisibleAviso = true;
            }

        }

        private void AdicionarNovoProduto()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new CadastrarProdutoView(_categoria));
        }

        private void EditarProduto(object obj)
        {
            ProdutoModel produto = obj as ProdutoModel;
            App.Current.MainPage.Navigation.PushModalAsync(new EditarProdutoView(produto));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }

        public async Task InitializeAsync()
        {
            List<ProdutoModel> _produtos = conexao.ObterProdutos(_categoria);
            ProdutosAtivosDoMercado = new ObservableCollection<ProdutoModel>(_produtos);
        }

    }
}
