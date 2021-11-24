using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameAPI.Models
{
    public class Deal
    {
        //DEAL: gameID, storeID, salePrice, savings, dealrating
        
        [Key]
        public int ID_DEAL { get; set; }
        public int ID_GAME { get; set; }
        public int ID_STORE { get; set; }
        public double SALE_PRICE { get; set; }
        public double SAVINGS { get; set; }
        public float DEAL_RATING { get; set; }

        public virtual Game Game { get; set; }
        public virtual Store Store { get; set; }
    }
}
