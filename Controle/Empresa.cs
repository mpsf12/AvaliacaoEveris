using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle
{
    public class Empresa : Geral<Modelo.Empresa>, IGeral<Modelo.Empresa>
    {
        public new Modelo.Empresa GetById(int id)
        {
            return _dbContext.Empresa.FirstOrDefault(e => e.Id == id);
        }

        public void Salvar(Modelo.Empresa empresa)
        {
            if (empresa.Id == 0)
                Create(empresa);
            else Update(empresa);
        }
    }
}
