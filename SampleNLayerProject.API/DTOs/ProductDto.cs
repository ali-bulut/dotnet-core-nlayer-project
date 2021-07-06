using System;
using System.ComponentModel.DataAnnotations;

namespace SampleNLayerProject.API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} field must be upper than 1")]
        // We don't need to write Required. Because int/decimal/float values' default value is 0.
        public int Stock { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "{0} field must be upper than 1")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
