using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ProductName { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "{0} is required")]
        //[RegularExpression(@"[0-9]+\.[0-9]{2}$", ErrorMessage = "Invalid price value")]
        public decimal Price { get; set; }
        
        /// <summary>
        /// Clone the current object
        /// </summary>
        /// <returns>Create a shallow copy from current object</returns>
        public Product ShallowCopy()
        {
            return (Product)this.MemberwiseClone();
        }
        
        #region Equality
        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return product != null &&
                   Id == product.Id &&
                   ProductName == product.ProductName &&
                   Price == product.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ProductName, Price);
        }

        #endregion 
    }
}