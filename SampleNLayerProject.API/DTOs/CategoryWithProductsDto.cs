using System;
using System.Collections.Generic;

namespace SampleNLayerProject.API.DTOs
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }       
}
