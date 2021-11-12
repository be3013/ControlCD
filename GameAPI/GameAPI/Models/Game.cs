using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameAPI.Models
{
    public class Game
    {
        //GAME: internalName, title, metalink, dealID, normalPrice, isOnSale, metascore, steamRating, steamRatingPercent, RatingCount, steamappid, realeasedate, last change, thumb

        [Key]
        public int ID_GAME { get; set; }
        public string INTERNAL_NAME { get; set; }
        public string TITLE { get; set; }
        public string METALINK { get; set; }
        public float PRICE { get; set; }
        public bool IS_ON_SALE { get; set; }
        public float METASCORE { get; set; }
        public string STEAM_RATING { get; set; }
        public int STEAM_RATING_PERCENT { get; set; }
        public int RATING_COUNT { get; set; }
        public int? STEAMAPP_ID { get; set; }
        public int OLD_GAME_ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime RELEASE_DATE { get; set; }

        [DataType(DataType.Date)]
        public DateTime LAST_CHANGE { get; set; }

        public string THUMBNAIL_LINK { get; set; }

        public virtual List<Deal> DEALS { get; set; }
    }
}
