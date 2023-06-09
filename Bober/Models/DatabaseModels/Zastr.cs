﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.CodeAnalysis;

namespace Bober.Models.DatabaseModels
{
    public class Zastr
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Застройщик")]
        [Required(ErrorMessage = "Введите")]
        [StringLength(25, ErrorMessage = "Длинна не может быть более {1} символов")]
        public string Name { get; set; }

        [DisplayName("Специализация")]
        [Required(ErrorMessage = "Введите статус")]
        public string Status { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

        //public List<Building> Buildings { get; set; }
    }
}

