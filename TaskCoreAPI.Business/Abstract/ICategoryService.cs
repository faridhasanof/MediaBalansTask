using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCoreAPI.Entity.Models;

namespace TaskCoreAPI.Business.Abstract
{
    public interface ICategoryService
    {
        void Create(Category entity);
        void Update(Category entity);
        void Delete(int id);
        List<Category> GetAll();
        Category GetById(int Id);
    }
}
