using Golf.RESTService.Client.Interfaces;
using Golf.ServiceLayer.Dto.Implementations;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Golf.MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRetrieveEntity<GolferDto> _retrieveEntity;

        public HomeController(IRetrieveEntity<GolferDto> retrieveEntity)
        {
            if (retrieveEntity == null)
            {
                throw new ArgumentNullException(nameof(retrieveEntity));
            }

            _retrieveEntity = retrieveEntity;
        }

        public async Task<ActionResult> Index()
        {
            var golfers = await _retrieveEntity.GetEntitiesAsync();

            return View(test);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}