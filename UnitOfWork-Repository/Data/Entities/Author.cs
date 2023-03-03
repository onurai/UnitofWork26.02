using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using Task.Data.Entities;

namespace Task.Data.Entities
{
    public class Author : BaseEntity<int>
    {
        [Key]
        public override int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string AuthorName { get; set; }
        [MinLength(10)]
        public string Surname { get; set; }
        public int Age { get; set; }

        public string Email { get; set; }


        public ICollection<Book>? Books { get; set; }
    }


}