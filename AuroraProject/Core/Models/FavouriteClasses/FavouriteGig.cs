using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AuroraProject.Core.Models
{
    public class FavouriteGig
    {
        [Key]
        [Column(Order = 1)]
        public string ActionerID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int GigID { get; set; }

        public ApplicationUser Actioner { get; set; }
        public Gig Gig { get; set; }
    }
}