using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHub.Data.Models
{
    public class DataContent
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Uri file { get; set; }
        public int CategoryId { get; set; }
        //public Category Category { get; set; }
    }
}
