using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCoreAPI.Business.Abstract;
using TaskCoreAPI.Data.Abstract;
using TaskCoreAPI.Entity.Models;

namespace TaskCoreAPI.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(Product entity)
        {
            _productRepository.Create(entity);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int Id)
        {
            return _productRepository.GetById(Id);
        }

        public void Update(Product entity)
        {
           _productRepository.Update(entity);
        }
    }
}
