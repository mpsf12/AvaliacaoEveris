using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle
{
    public interface IGeral<T> where T : class
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        void Delete(T entity);
    }
}
