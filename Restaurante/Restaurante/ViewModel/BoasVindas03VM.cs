using Restaurante.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Restaurante.ViewModel
{
    
    class BoasVindas03VM
    {
        public Command IrParatelaInicial { get; set; }

        public BoasVindas03VM()
        {

            IrParatelaInicial = new Command(GoTelaInicial);
        }

        private void GoTelaInicial(object obj)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new HomeView());
        }

    }
}
