using CatalogueApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CatalogueApp.Controllers{
    [Route("/api/products")]
    public class ProductRestController:Controller{

        public CatalogueRepository catalogueRepository {get;set;}

        public ProductRestController(CatalogueRepository repository){
            this.catalogueRepository= repository;
        }
        [HttpGet]
        public IEnumerable<Product> listProdsucts(){
                 return catalogueRepository.Products.Include(p => p.category);
        }
         [HttpGet("{Id}")]
        public Product getOne(int Id){
                 return catalogueRepository.Products.Include(p => p.category).FirstOrDefault(p => p.ProductId==Id);
        }
         [HttpGet("search")]
        public IEnumerable<Product> search(string kw){
                 return catalogueRepository
                 .Products
                 .Include(p => p.category)
                 .Where(p =>  p.Name.Contains(kw));
        }
          [HttpGet("paginate")]
        public IEnumerable<Product> page(int page=0, int size=1){
                 int skipeValue =(page-1)*size;
                 return catalogueRepository.Products
                 .Include(p => p.CategoryId)
                 .Skip(skipeValue)
                 .Take(size);
        }
         [HttpPut("{Id}")]
        public Product update(int Id ,[FromBody] Product product){
                product.ProductId = Id;
                catalogueRepository.Products.Update(product);
                catalogueRepository.SaveChanges();
                return product;
        }
        [HttpPost]
        public Product Save([FromBody] Product product){
            catalogueRepository.Products.Add(product);
            catalogueRepository.SaveChanges();
            return product;
        }
          [HttpDelete("{Id}")]
        public void  Delete(int Id){
           Product  product = catalogueRepository.Products.FirstOrDefault(c => c.ProductId == Id);
            catalogueRepository.Remove(product);
            
       
        }
    }
    
        
    
}