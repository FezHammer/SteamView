using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SteamView.Models
{
    public class UserAcount
    {
        [Key]
        [Required]
        public int UserID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Acount Name")]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        public int Age { get; set; }

        public int Phone { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ICollection<GameStats> GameStats { get; set; }
    }
}