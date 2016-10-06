using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models
{
    public class Parameters
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public int ParametreDegerId { get; set; }
        public string ParametreDegerString { get; set; }

        public bool DegistiMi { get; set; }

    }
}