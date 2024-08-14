using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GrupineUzduotisPostai.Core.Models
{
    public class Post
    {
        [Key]
        public int Id {  get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Date {  get; set; }

        public Post(int id, string name, string content) 
        { 
            Id = id;
            Name = name;
            Content = content;
            Date = DateTime.Now;
        
        }


    }
}
