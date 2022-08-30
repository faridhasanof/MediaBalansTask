using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCoreAPI.Data.Abstract
{
    public interface IGenericRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        T GetById(int Id);
    }
}
