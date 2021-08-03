﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModels
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string Type { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreateDate { get; set; }
    }
}
