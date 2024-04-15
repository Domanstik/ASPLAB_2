﻿using System.ComponentModel.DataAnnotations;

namespace ASPLAB_2.Models
{
    public class User
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
