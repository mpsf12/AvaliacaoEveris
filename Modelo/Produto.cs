using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Produto
    {
        public string NomeProduto { get; set; }

        public Produto(string nomeProduto)
        {
            this.NomeProduto = nomeProduto;
        }

        public Produto() { }
    }
}
