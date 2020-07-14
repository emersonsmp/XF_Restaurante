using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Restaurante.Model;

namespace Restaurante.ViewModel
{
    class PaginaCadastroVM
    {
        public Command ChamaMetodoCadastro { get; set; }
        ComunicacaoBanco _banco = new ComunicacaoBanco();
        public UsuarioModel usuario { get; set; }
        public string EntryPassWord { get; set; }
        public string EntryRePass { get; set; }

        public PaginaCadastroVM()
        {
            usuario = new UsuarioModel();           
            ChamaMetodoCadastro = new Command(CadastraUsuario);
        }

        private void CadastraUsuario()
        {
            if (EntryPassWord == EntryRePass)
            {
                usuario.senha = EntryPassWord;
                _banco.InsereUsuario(usuario);
                App.Current.MainPage.DisplayAlert("Atenção", "Usuario Registradado", "ok");
                App.Current.MainPage.Navigation.PopModalAsync();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Atenção","Senha não confere","ok");
            }      
        }
    }
}
