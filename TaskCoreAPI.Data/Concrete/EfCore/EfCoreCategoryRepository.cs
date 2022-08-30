using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCoreAPI.Data.Abstract;
using TaskCoreAPI.Data.Concrete.TaskCoreAPIContext;
using TaskCoreAPI.Entity.Models;

namespace TaskCoreAPI.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, AppDbContext>, ICategoryRepository
    {
    }
}
