using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Limpex
{
    interface IAutenticar
    {
        string login { get; set; }
        string senha { get; set; }
        
        bool Autenticar(string login, string senha);
        void ValidarLogin(string login);
        void Excluir(string login, string senha );
    }
}
