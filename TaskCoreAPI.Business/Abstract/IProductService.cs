using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCoreAPI.Entity.Models;

namespace TaskCoreAPI.Business.Abstract
{
    public interface IProductService
    {
        void Create(Product entity);
        void Update(Product entity);
        void Delete(int id);
        List<Product> GetAll();
        Product GetById(int Id);
    }
}
