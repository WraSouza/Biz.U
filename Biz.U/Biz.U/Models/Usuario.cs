using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biz.U.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioSenha { get; set; }
    }
}
