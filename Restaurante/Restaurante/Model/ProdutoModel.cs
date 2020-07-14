using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Model
{
    [Table("UsuarioModel")]
    public class ProdutoModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome {get; set;}
        public string Categoria { get; set; }
        public string Imagem {get; set;}
        public string Descricao {get; set;}
    }
}
