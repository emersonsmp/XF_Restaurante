using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace Restaurante.Model
{
    public class ComunicacaoBanco
    {
        private SQLiteConnection Conexao;

        public ComunicacaoBanco()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            Conexao = new SQLiteConnection(caminho);
            Conexao.CreateTable<UsuarioModel>();
        }

        public void InsereUsuario(UsuarioModel usuario)
        {
            Conexao.Insert(usuario);
        }

        public UsuarioModel ObterUsuario(string email, string pass)
        {
            return Conexao.Table<UsuarioModel>().Where(a => a.email == email && a.senha == pass).FirstOrDefault();
        }

        public void RemoveUsuario(int user_id)
        {
            UsuarioModel usuario = Conexao.Table<UsuarioModel>().Where(a => a.Id == user_id).FirstOrDefault();
            Conexao.Delete(usuario);
        }

        public void UpdateUsuario(UsuarioModel usuario)
        {
            Conexao.Update(usuario);
        }
    }
}
