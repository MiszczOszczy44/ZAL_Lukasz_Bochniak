using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZAL_Lukasz_Bochniak.Models
{
    public class Lista_ToDo
    {
        public int ID { get; set; }
        public string Opis { get; set; }
        public bool Gotowe { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}