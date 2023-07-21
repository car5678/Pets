using System;
using System.Collections.Generic;
using System.Text;

namespace Pets
{
    public class Usuario
    {

        public Usuario(string _usuario, string _passowrd)
        {
            username = _usuario;
            password = _passowrd;
        }
        public string username { get; set; }

        public string password { get; set; }
    }
}
