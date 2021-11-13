using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace GameAPI.Models
{
    public class Promocao
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double ValorOriginal { get; set; }
        public double ValorDesconto { get; set; }
        public Blob ImagemCapa { get; set; }
    }
}
