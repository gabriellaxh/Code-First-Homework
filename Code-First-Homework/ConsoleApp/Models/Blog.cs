﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
   public class Blog
    {
        public Blog()
        {
            Posts = new List<Post>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
