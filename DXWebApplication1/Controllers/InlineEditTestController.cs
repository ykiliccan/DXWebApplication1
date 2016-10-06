using DXWebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class InlineEditTestController : Controller
    {
        public ActionResult Index()
        {
            var listParam = ParametreSample.ParametreleriOlustur();
            return View(listParam);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial(string ParametreDegerListesi)
        {
            List<Parameters> liste = null;
            if (ParametreDegerListesi == null)
            {
                liste = ParametreSample.ParametreleriOlustur();
            }
            else
            {
                liste = GetParameterListesi(null, ParametreDegerListesi);
            }

            return PartialView("_GridViewPartial", liste);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateGridViewPartial(Parameters pv, string ParametreDegerListesi)
        {
            if (ModelState.IsValid)
            {


                



            }
            else
            {
                ViewData["EditError"] = "Lütfen tüm hataları düzeltiniz.\r\n";              
            }

            //var paramList = ParametreDegerListesi.Split(new char[] { ',' }).ToList<string>();

            //var paramDegerList = from p in paramList
            //                     let sp = p.Split(new char[] { '|' })
            //                     select new { parameterId = Int32.Parse(sp[0]), ParametreDegerId = Int32.Parse(sp[1])};

            ////parameter değer stringlerini ata : elimizde parametreId ve parametreDegerId'si var sadece
            //var queryParametreDegerler = (from p in paramDegerList
            //            join d in ParametreSample.GetParametreDegerleri() on p.ParametreDegerId equals d.Id
            //            where p.ParametreDegerId != 0
            //            select new Parameters { Id = p.parameterId, ParametreDegerId = p.ParametreDegerId, ParametreDegerString = string.Format("{0} - {1}",d.Min,d.Max) }).ToList();

            //// yeni girilen parametreDegerId ye karşılık gelen ParametreDegerString'i bul
            //var parametreDegerString = ParametreSample.GetParametreDegerleri()
            //    .Where(p => p.Id == pv.ParametreDegerId)
            //    .Select(p => new { value = string.Format("{0} - {1}", p.Min, p.Max) })
            //    .FirstOrDefault();



            ////yeni girilen degeri ata
            //foreach (var v in queryParametreDegerler)
            //    if (v.Id == pv.Id)
            //    {
            //        v.ParametreDegerId = pv.ParametreDegerId;
            //        v.ParametreDegerString = parametreDegerString.value;
            //    }

            //var query = (from lp in ParametreSample.ParametreleriOlustur()
            //            join pd in queryParametreDegerler on lp.Id equals pd.Id into pdL
            //            from subPd in pdL.DefaultIfEmpty()
            //            select new Parameters {
            //                                    Id = lp.Id,
            //                                    Adi = lp.Adi,
            //                                    ParametreDegerId = lp.ParametreDegerId,
            //                                    ParametreDegerString = subPd==null?null:subPd.ParametreDegerString,
            //                                    DegistiMi = subPd==null?false:lp.ParametreDegerId!=subPd.ParametreDegerId
            //                   }).ToList();


            var liste = GetParameterListesi(pv, ParametreDegerListesi);                        

            return PartialView("_GridViewPartial", liste);
        }

        private List<Parameters> GetParameterListesi(Parameters pv, string ParametreDegerListesi)
        {
            var paramList = ParametreDegerListesi.Split(new char[] { ',' }).ToList<string>();

            var paramDegerList = from p in paramList
                                 let sp = p.Split(new char[] { '|' })
                                 select new { parameterId = Int32.Parse(sp[0]), ParametreDegerId = Int32.Parse(sp[1]) };

            //parameter değer stringlerini ata : elimizde parametreId ve parametreDegerId'si var sadece
            var queryParametreDegerler = (from p in paramDegerList
                                          join d in ParametreSample.GetParametreDegerleri() on p.ParametreDegerId equals d.Id
                                          where p.ParametreDegerId != 0
                                          select new Parameters { Id = p.parameterId, ParametreDegerId = p.ParametreDegerId, ParametreDegerString = string.Format("{0} - {1}", d.Min, d.Max) }).ToList();

            


            if (pv != null)
            {
                // yeni girilen parametreDegerId ye karşılık gelen ParametreDegerString'i bul
                var parametreDegerString = ParametreSample.GetParametreDegerleri()
                    .Where(p => p.Id == pv.ParametreDegerId)
                    .Select(p => new { value = string.Format("{0} - {1}", p.Min, p.Max) })
                    .FirstOrDefault();

                //yeni girilen degeri ata
                foreach (var v in queryParametreDegerler)
                    if (v.Id == pv.Id)
                    {
                        v.ParametreDegerId = pv.ParametreDegerId;
                        v.ParametreDegerString = parametreDegerString.value;
                    }
            }

            var query = (from lp in ParametreSample.ParametreleriOlustur()
                         join pd in queryParametreDegerler on lp.Id equals pd.Id into pdL
                         from subPd in pdL.DefaultIfEmpty()
                         select new Parameters
                         {
                             Id = lp.Id,
                             Adi = lp.Adi,
                             ParametreDegerId =subPd==null?lp.ParametreDegerId:subPd.ParametreDegerId,
                             ParametreDegerString = subPd == null ? null : subPd.ParametreDegerString,
                             DegistiMi = subPd == null ? false : lp.ParametreDegerId != subPd.ParametreDegerId
                         }).ToList();

            return query;

        }


    }
}