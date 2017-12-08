using MySql.Data.MySqlClient;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using TreasyOps.Models;
using TreasyOps.ViewModel;

namespace TreasyOps.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int startWeek = 1, int endWeek = 52)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TreasyDatabase"].ConnectionString;
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (Context context = new Context(connection, false))
                {
                    //Recupero somente as informações que necesito utilizar
                    var query = context.DealUpdates
                        .Where(i => i.UpdateDate.Year == 2017) //Somente em 2017
                        .Where(i => i.StageTo != null) //Retiro as etapas não identificadas
                        .Select(i => new
                        {
                            i.Deal_ID,
                            i.UpdateDate,
                            i.StageTo
                        }).ToList();

                    ResultViewModel viewModel = new ResultViewModel
                    {
                        //1 - Quantos negócios entraram em cada etapa, por semana do ano 2017?
                        Question1 = query
                               .GroupBy(i => cal.GetWeekOfYear(i.UpdateDate, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)) //Agrupo pelo número da semana da data da atualização
                               .Where(i => i.Key >= startWeek && i.Key <= endWeek) //Filtro pelo número da semana
                               .OrderBy(i => i.Key) //Ordeno pelo número da semana
                               .Select(g => new AnalyzeDealsViewModel
                               {
                                   WeekOfYear = g.Key,
                                   Items = g.ToList()
                                       .GroupBy(i => i.StageTo)
                                       .OrderByDescending(i => i.Count()) //Ordeno pela quantidade
                                       .Select(gg => new AnalyzeDealsItemViewModel
                                       {
                                           StageTo = gg.Key.ToString(),
                                           Count = gg.Count()
                                       }).ToList()
                               }).ToList(),

                        //2 - Qual é o total de negócios por semana do ano 2017?
                        Question2 = query.GroupBy(i => i.Deal_ID) //Primeiramente agrupo por negócio
                                   .Select(g => new
                                   {
                                       DealId = g.Key,
                                       LastUpdate = g.LastOrDefault(), //Após isso, recupero somente a última etapa de cada negócio
                                   }).GroupBy(i => cal.GetWeekOfYear(i.LastUpdate.UpdateDate, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)) //Agrupo pelo número da semana da data da atualização
                                   .Where(i => i.Key >= startWeek && i.Key <= endWeek) //Filtro pelo número da semana 
                                   .OrderBy(i => i.Key) //Ordeno pelo número da semana
                                    .Select(g => new AnalyzeDealsViewModel
                                    {
                                        WeekOfYear = g.Key,
                                        Items = g.ToList()
                                            .GroupBy(i => i.LastUpdate.StageTo)
                                            .OrderByDescending(i => i.Count()) //Ordeno pela quantidade
                                            .Select(gg => new AnalyzeDealsItemViewModel
                                            {
                                                StageTo = gg.Key.ToString(),
                                                Count = gg.Count()
                                            }).ToList()
                                    }).ToList()
                    };
                    ViewBag.StartWeek = startWeek;
                    ViewBag.EndWeek = endWeek;
                    return View(viewModel);
                }
            }
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }

    

    

    
}