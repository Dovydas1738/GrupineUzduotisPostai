﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GrupineUzduotisPostai.Core.Enums;


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
        public PostCategories Category { get; set; }
        public int Views { get; set; }

        public void SetDate()
        {
            Date = DateTime.Now;
        }
        public Post(User user, string name, string content, PostCategories category) 
        {
            User = user;
            Name = name;
            Content = content;
            Date = DateTime.Now;
            Category = category;
            Views = 0;
        
        }



        public Post() {
            
        }


    }
}
