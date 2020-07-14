using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Restaurante.Model;
using Restaurante.View;
using Xamarin.Forms;

namespace Restaurante.ViewModel
{
    class PerfilVM : INotifyPropertyChanged
    {
        public ObservableCollection<CategoriaModel> _CategoriasAtivasDoMercado { get; set; }
        public ObservableCollection<CategoriaModel> CategoriasAtivasDoMercado
        {
            get
            {
                return _CategoriasAtivasDoMercado;
            }
            set
            {
                _CategoriasAtivasDoMercado = value;
                OnPropertyChanged("CategoriasAtivasDoMercado");
            }
        }

        public Command AdicionarNovaCategoria { get; set; }
        public Command GoCategoriaCommand { get; set; }
        public Command FazerLogoutCommand { get; set; }

        public bool _isVisibleListaDeCategorias { get; set; }
        public bool isVisibleListaDeCategorias
        {
            get
            {
                return _isVisibleListaDeCategorias;
            }
            set
            {
                _isVisibleListaDeCategorias = value;
                OnPropertyChanged("isVisibleListaDeCategorias");
            }
        }

        public bool _isVisibleAviso { get; set; }
        public bool isVisibleAviso
        {
            get
            {
                return _isVisibleAviso;
            }
            set
            {
                _isVisibleAviso = value;
                OnPropertyChanged("isVisibleAviso");
            }
        }

        ComunicacaoBancoCategorias conexao = new ComunicacaoBancoCategorias();


        public PerfilVM()
        {

            CategoriasAtivasDoMercado = new ObservableCollection<CategoriaModel>();
            PovoarListaDeCategorias();
            AdicionarNovaCategoria = new Command(NovaCategoria);
            GoCategoriaCommand = new Command<object>(VerPaginaDeCategoria);
            FazerLogoutCommand = new Command(FazerLogout);
        }

        public void PovoarListaDeCategorias()
        {

            List<CategoriaModel> _categorias = conexao.ObterCategorias();
            CategoriasAtivasDoMercado = new ObservableCollection<CategoriaModel>(_categorias);

            if (CategoriasAtivasDoMercado.Count > 0)
            {
                isVisibleListaDeCategorias = true;
            }
            else
            {
                isVisibleAviso = true;
            }
        }

        public void FazerLogout()
        {
            Setting.UserName = "";
            Setting.UserPassword = "";
            App.Current.MainPage = new HomeView();
        }

        private void NovaCategoria()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new CadastrarCategoriaView());
        }

        private void VerPaginaDeCategoria(object obj)
        {
            CategoriaModel categoria = obj as CategoriaModel;
            App.Current.MainPage.Navigation.PushAsync(new PaginaDeProdutosView(categoria.Titulo));
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
            List<CategoriaModel> _categoriass = conexao.ObterCategorias();
            CategoriasAtivasDoMercado = new ObservableCollection<CategoriaModel>(_categoriass);
            
            if (CategoriasAtivasDoMercado.Count > 0)
            {
                isVisibleListaDeCategorias = true;
                isVisibleAviso = false;
            }
        }
    }
}
