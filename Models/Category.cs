using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CatalogueApp.Models{
    [Table("Categorie")]
    public class Category{
          [Key]
          public int CategoryId { get; set; }

          public string Name { get; set; }
          [JsonIgnore]
          public ICollection<Product> products {get;set;}


    }
}