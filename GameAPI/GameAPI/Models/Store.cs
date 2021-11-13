using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameAPI.Models
{
    public class Store
    {
        [Key]
        public int ID_STORE { get; set; }
        public string NOME { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string BANNER { get; set; }
        public string LOGO { get; set; }
        public string ICON { get; set; }

        public virtual List<Deal> DEALS { get; set; }
        
        [NotMapped]
        public virtual int GAMES { get; set; } 
    }
}
