using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SteamView.Models
{
    public class GameStats
    {
        [Key]
        [Required]
        public int GaneStatID { get; set; }

        
        [Required]
        public int UserID { get; set; }
        public virtual UserAcount UserAcount { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "NAME")]
        [Column(TypeName = "varchar")]
        public string GameName { get; set; }

        [StringLength(20)]
        [Display(Name = "STATUS")]
        [Column(TypeName = "varchar")]
        public String Status { get; set; }

        [StringLength(15)]
        [Display(Name = "METASCORE")]
        [Column(TypeName = "varchar")]
        public String MetaScore { get; set; }

        [StringLength(15)]
        [Display(Name = "LAST PLAYED")]
        [DataType(DataType.Date)]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public String LastPalayed { get; set; }

        [StringLength(10)]
        [Display(Name = "HOURS PLAYED")]
        [Column(TypeName = "varchar")]
        public String PlayTime { get; set; }

        public string GameImmage { get; set; }

    }
}