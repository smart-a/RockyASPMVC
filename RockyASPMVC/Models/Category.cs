﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RockyASPMVC.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = 
            "Display Order must be greater than zero")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}