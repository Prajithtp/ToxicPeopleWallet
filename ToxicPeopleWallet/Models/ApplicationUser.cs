using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToxicPeopleWallet.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentBalance { get; set; } = 0;

        public ICollection<WalletTransaction> Transactions { get; set; }
            = new List<WalletTransaction>();
    }
}