using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace GameAPI.Models
{
    public class Loja
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public Blob Logo { get; set; }
        public int PromocaoVigor { get; set; }
        public int PromocaoTotal { get; set; }
        public bool Ativa { get; set; }
    }
}
