using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitect.Core.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string brief { get; set; }
        public string Desc { get; set; }

        public int AuthorId { get; set; }
        public Author author { get; set; }
    }
}
