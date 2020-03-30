using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Model.JsonLD
{
    public class ItemListElement
    {
        public string @type { get; set; } = "ListItem";// @type
        public string position { get; set; }
        public Item item { get; set; }

    }

    public class ItemElement
    {
        
    }
    
}
