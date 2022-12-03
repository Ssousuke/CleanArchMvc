using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Dtos;

public class ProductDto
{
    public int Id { get; set; }
 
    [Required(ErrorMessage = "Name is required")]
    [MinLength(5)]
    [MaxLength(100)]
    [DisplayName("Nome")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Descrição")]
    public string Description { get; set; }
    
    [Required(ErrorMessage= "Price is required")]
    [Column(TypeName = "decimal (18, 2)")]
    [DisplayFormat(DataFormatString = "{0:c2}")]
    [DisplayName("Preço")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "Stock is required")]
    [Range(1, 9999)]
    [DisplayName("Estoque")]
    public int Stock { get; set; }
    
    [MaxLength(250)]
    [DisplayName("Image do produto")]
    public string Image { get; set; }
    
    public Category Category { get; set; }
    
    [DisplayName("Categoria")]
    public int CategoryId { get; set; }
}