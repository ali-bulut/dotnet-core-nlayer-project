using System;
using System.ComponentModel.DataAnnotations;

namespace SampleNLayerProject.API.DTOs
{
    public class CategoryDto
    {
        public CategoryDto()
        {
        }

        public int Id { get; set; }

        // for the requests that come from client (update/create). We need that field to be required.
        [Required]
        public string Name { get; set; }
    }
}
