using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToxicPeopleWallet.Models
{
    public class GroupWallet
    {
        [Key]
        public int WalletId { get; set; }

        [Required]
        [StringLength(100)]
        public string WalletName { get; set; } = "Toxic People Wallet";

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalBalance { get; set; } = 0;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}