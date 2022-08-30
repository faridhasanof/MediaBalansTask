using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCoreAPI.Entity.Models;

namespace TaskCoreAPI.Data.Abstract
{
    public interface IProductRepository: IGenericRepository<Product>
    {
    }
}
