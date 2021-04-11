using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioRDI.Models
{
    public class CardModel
    {
        [Key]
        [Required(ErrorMessage = "This field is mandatory")]
        public int CardId { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        public long CardNumber { get; set; }

        [NotMapped]
        public int CVV { get; set; }

        [Required(ErrorMessage = "This field is mandatory")]
        public DateTime RegistrationDate { get; set; }
    }
    public class CardContext : DbContext
    {
        public DbSet<CardModel> cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Users\Ricardo\source\repos\DesafioRDI\Database\rdi.db");
    }
}