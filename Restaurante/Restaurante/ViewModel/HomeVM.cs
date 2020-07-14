using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Restaurante.View;

namespace Restaurante.ViewModel
{
    class HomeVM
    {
        public Command IrParaPaginaDeLogin   { get; set; }
        public Command IrParaPaginaDeCadastro { get; set; }
        public HomeVM()
        {
            IrParaPaginaDeLogin = new Command(GoPaginaLogin);
            IrParaPaginaDeCadastro = new Command(GoPaginaDeCadastro);
        }

        private void GoPaginaLogin()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new PaginadeLoginView());
        }

        private void GoPaginaDeCadastro()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new PaginaCadastroView());
        }
    }
}
