using CatalogueApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CatalogueApp.Controllers{
    [Route("/api/categories")]
    public class CategoryRestController:Controller{

        public CatalogueRepository catalogueRepository {get;set;}

        public CategoryRestController(CatalogueRepository repository){
            this.catalogueRepository= repository;
        }
        [HttpGet]
        public IEnumerable<Category> listCats(){
                 return catalogueRepository.Categories;
        }
         [HttpGet("{Id}")]
        public Category getCat(int Id){
                 return catalogueRepository.Categories.FirstOrDefault(c => c.CategoryId==Id);
        }
         [HttpGet("{Id}/products")]
        public IEnumerable<Product> products(int Id){
                 Category category = catalogueRepository.Categories.Include(c => c.products).FirstOrDefault(c => c.CategoryId == Id );
                 return category.products;
        }
       
         [HttpPut("{Id}")]
        public Category update([FromBody] Category category, int Id ){
                category.CategoryId = Id;
                catalogueRepository.Categories.Update(category);
                catalogueRepository.SaveChanges();
                return category;
        }
        [HttpPost]
        public Category Save([FromBody] Category category){
            catalogueRepository.Categories.Add(category);
            catalogueRepository.SaveChanges();
            return category;
        }
          [HttpDelete("{Id}")]
        public void  Delete(int Id){
           Category  category = catalogueRepository.Categories.FirstOrDefault(c => c.CategoryId == Id);
            catalogueRepository.Remove(category);
            
       
        }
    }
    
        
    
}