using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Restaurante.Model
{

    [Table("UsuarioModel")]
    public class UsuarioModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
