using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupineUzduotisPostai.Core.Enums;

namespace GrupineUzduotisPostai.Core.Models
{
    public class PostCreateRequest
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public PostCategories Category { get; set; }
        public int Views { get; set; }
    }
}
