using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Model.JsonLD
{
   public class StructuredData
    {
        public string @context { get;  } = "https://schema.org";//@context
        public string @type { get; } = "ItemList";
        public List<ItemListElement> itemListElement { get; set; } 
       
    }
}
