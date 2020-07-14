using Restaurante.Model;
using Restaurante.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Restaurante.ViewModel
{
    class PaginadeLoginVM
    {
        public Command ChamaMetodoFazerLogin { get; set; }
        public string EntryEmail {get; set;}
        public string EntryPassWord { get; set; }
        ComunicacaoBanco _banco = new ComunicacaoBanco();

        public PaginadeLoginVM()
        {
            ChamaMetodoFazerLogin = new Command(FazerLogin);
        }

        private void FazerLogin()
        {
            try
            {
                //FAZER LOGIN NO SERVIDOR
                //IR PARA PAGINA
                if(EntryEmail != null && EntryPassWord != null)
                {
                   UsuarioModel usuario = _banco.ObterUsuario(EntryEmail, EntryPassWord);

                    if (usuario.Id != null)
                    {
                        //App.Current.Properties["IsLoggedIn"] = true;
                        //App.Current.MainPage.Navigation.PushAsync(new PerfilView());
                        Setting.UserName = usuario.email;
                        Setting.UserPassword = usuario.senha;
                        App.Current.MainPage = new NavigationPage(new PerfilView());
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Ops", "Usuario inexistente", "OK");
                    }
                
                }

                int x = 0;

            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Ops","Erro","OK");
            }
        }
      
    }
}
