using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankSystem
{
    public class BankSystemContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-PHQ2LBS;Database=BankSystem;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Credit> Credits { get; set; }
        public virtual DbSet<Borrower> Borrowers { get; set; }
    }

    public class Role
    {
        public int ID { get; set; }
        [Required]  public string Title { get; set; }
    }

    public class Gender
    {
        public int ID { get; set; }
        [Required] public string Title { get; set; }
    }

    public class User
    {
        public int ID { get; set; }
        [Required] public int RoleID { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Credit> Credits { get; set; }
    }

    public class Credit
    {
        public int ID { get; set; }
        [Required] public int UserID { get; set; }
        [Required] public string ContractNumber { get; set; }
        [Required] public int LoanTerm { get; set; }
        [Required] public decimal LoanAmount { get; set; }
        [Required] public decimal InterestRate { get; set; }
        [Required] public decimal PaidAmount { get; set; }

        public virtual User User { get; set; }
        public virtual Borrower Borrower { get; set; }
    }

    public class Borrower
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public int GenderID { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required] public string PassportData { get; set; }
        [Required] public string INN { get; set; }
        public int CreditId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Credit Credit { get; set; }
    }
}
