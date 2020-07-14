using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.Model
{
    [Table("UsuarioModel")]
    public class CategoriaModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
    }
}
