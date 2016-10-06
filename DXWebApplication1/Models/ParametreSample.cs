using DXWebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models
{
    public static class ParametreSample
    {
        public static List<Parameters> ParametreleriOlustur()
        {
            List<Parameters> parameters =  new List<Parameters>()
            {
                new Parameters {Id=1,Adi="Voltaj",ParametreDegerId=100 },
                new Parameters {Id=2,Adi="Dönme Hızı",ParametreDegerId=200 },
                new Parameters {Id=3,Adi="Param3",ParametreDegerId=300 },
                new Parameters {Id=4,Adi="Param3",ParametreDegerId=400 },
                new Parameters {Id=5,Adi="Param3",ParametreDegerId=500 },
                new Parameters {Id=6,Adi="Param3",ParametreDegerId=600 },
                new Parameters {Id=7,Adi="Param3",ParametreDegerId=700 }
            };


            var query = from p in parameters
                        join d in GetParametreDegerleri() on p.ParametreDegerId equals d.Id
                        select new Parameters { Adi=p.Adi,Id=p.Id,ParametreDegerId=p.ParametreDegerId,ParametreDegerString=d.Max + " - " + d.Min };

            return query.ToList();
        }
        public static List<ParametreDegerleri> GetParametreDegerleri()
        {
            return new List<ParametreDegerleri>()
            {
                new ParametreDegerleri {Id=100,Max="120",Min="99",ParametreId=1},
                new ParametreDegerleri {Id=200,Max="1000",Min="50",ParametreId=2},
                new ParametreDegerleri {Id=300,Max="130",Min="30",ParametreId=3},
                new ParametreDegerleri {Id=400,Max="140",Min="40",ParametreId=4},
                new ParametreDegerleri {Id=500,Max="150",Min="50",ParametreId=5},
                new ParametreDegerleri {Id=600,Max="160",Min="60",ParametreId=6},
                new ParametreDegerleri {Id=700,Max="170",Min="70",ParametreId=7},

                new ParametreDegerleri {Id=101,Max="121",Min="99",ParametreId=1},
                new ParametreDegerleri {Id=201,Max="1000",Min="50",ParametreId=2},
                new ParametreDegerleri {Id=301,Max="130",Min="30",ParametreId=3},
                new ParametreDegerleri {Id=401,Max="140",Min="40",ParametreId=4},
                new ParametreDegerleri {Id=501,Max="150",Min="50",ParametreId=5},
                new ParametreDegerleri {Id=601,Max="160",Min="60",ParametreId=6},
                new ParametreDegerleri {Id=701,Max="170",Min="70",ParametreId=7},



                new ParametreDegerleri {Id=102,Max="122",Min="9",ParametreId=1},
                new ParametreDegerleri {Id=202,Max="1000",Min="5",ParametreId=2},
                new ParametreDegerleri {Id=302,Max="130",Min="3",ParametreId=3},
                new ParametreDegerleri {Id=402,Max="140",Min="4",ParametreId=4},
                new ParametreDegerleri {Id=502,Max="150",Min="5",ParametreId=5},
                new ParametreDegerleri {Id=602,Max="160",Min="6",ParametreId=6},
                new ParametreDegerleri {Id=702,Max="170",Min="7",ParametreId=7},

                new ParametreDegerleri {Id=111,Max="123",Min="91",ParametreId=1},
                new ParametreDegerleri {Id=112,Max="220",Min="91",ParametreId=1},
                new ParametreDegerleri {Id=113,Max="330",Min="91",ParametreId=1},
                new ParametreDegerleri {Id=114,Max="380",Min="91",ParametreId=1},
                new ParametreDegerleri {Id=115,Max="1000",Min="91",ParametreId=1},
                new ParametreDegerleri {Id=116,Max="9",Min="9",ParametreId=1}
            };

        }

    }
}