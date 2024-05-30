using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_mobile2
{
    public class Book
    {
        public Book()
        {
        }

        // Propiedades del modelo con get y set para cada uno
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public int Length { get; set; }
        public string Content { get; set; }



    }
}
