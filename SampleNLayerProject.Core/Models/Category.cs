using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleNLayerProject.Core.Models
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        /*
        All of those below inherits from IEnumerable => supports filtering elements using where clause. It is the most basic type of list container.

        ICollection =>
        which derives from IEnumerable and extends it’s functionality to add, remove, update element in the list.
        ICollection also holds the count of elements in it and we does not need to iterate over all elements to get total number of elements.
        ICollection supports enumerating over the elements, filtering elements, adding new elements, deleting existing elements,
        updating existing elements and getting the count of available items in the list.

        IList =>
        IList extends ICollection. An IList can perform all operations combined from IEnumerable and ICollection,
        and some more operations like inserting or removing an element in the middle of a list.
        is everything that ICollection is, but it also supports adding and removing items, retrieving items by index, etc.

        IQueryable => 
        IQueryable extends IEnumerable. An IQueryable generates a LINQ to SQL expression that is executed over the database layer.
        */
        public ICollection<Product> Products { get; set; }  
    }
}
