using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controle
{
    class Produto : Geral<Modelo.Empresa>, IGeral<Modelo.Empresa>
    {
        public new Modelo.Produto GetById(int id)
        {
            return _dbContext.Produto.FirstOrDefault(e => e.Id == id);
        }
    }
}
