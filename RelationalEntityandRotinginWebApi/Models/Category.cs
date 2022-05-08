using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalEntityandRotinginWebApi.Models
{
    public class Category
    {
        public Category()
        {
            Post = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public ICollection<Post> Post
        {
            get; set;
        }
    }
}
