using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GrupineUzduotisPostai.Core.Models
{
    public class Posts
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateOnly Date {  get; set; }

        public Posts(int id, string name, string content, DateOnly date ) 
        { 
            Id = id;
            Name = name;
            Content = content;
            Date = date;
        
        }


    }
}
