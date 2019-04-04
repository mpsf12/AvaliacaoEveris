using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Empresa
    {
        public string NomeEmpresa { get; set; }

        public Empresa(string nomeEmpresa)
        {
            this.NomeEmpresa = nomeEmpresa;
        }

        public Empresa() { }
    }
}
