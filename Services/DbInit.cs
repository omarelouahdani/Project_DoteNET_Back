using CatalogueApp.Models;
using System;
namespace CatalogueApp.Services{
    public static class     DbInit{
          public static void initData(CatalogueRepository catalogueRepository){
                Console.WriteLine("Data Initialization ...");
                catalogueRepository.Categories.Add(new Category{Name="Ordinateurs"});
                catalogueRepository.Categories.Add(new Category{Name="Imprimantes"});
                catalogueRepository.Products.Add(new Product{Name="Ord HP 540",Price=650.08, CategoryId=1});
               catalogueRepository.Products.Add(new Product{Name="Ord Com 111",Price=128.70, CategoryId=1});
               catalogueRepository.Products.Add(new Product{Name="Mac Book Pro",Price=1200.08, CategoryId=1});
               catalogueRepository.Products.Add(new Product{Name="Imprimante Epson 7654 ",Price=3000.09, CategoryId=2});
                catalogueRepository.SaveChanges();
             


          }
    }
}