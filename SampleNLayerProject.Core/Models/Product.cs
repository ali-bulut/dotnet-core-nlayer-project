using System;
namespace SampleNLayerProject.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarcode { get; set; }
        // marking a property as virtual allows EF to use lazy loading.
        // It allows the Entity Framework to create a proxy around the virtual property so that
        // the property can support lazy loading and more efficient change tracking.
        //  For lazy loading to work, EF has to create a proxy object that overrides
        //  your virtual properties with an implementation that loads the referenced entity when it is first accessed.
        public virtual Category Category { get; set; }
    }   
}
