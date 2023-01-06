using AltFuture.Areas.Competitions.Services;
using AltFuture.Areas.Competitions.Models;
using AltFuture.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AltFuture.Areas.Competitions.Controllers
{
    [Area("Competitions")]
    [Authorize]
    [Authorize(Policy = "CompetitionPlayerPolicy")]
    public class CelebrityController : Controller
    {
       // private readonly IHttpContextAccessor _contextAccessor;

        private LKCelebrityTypeRepository _lkCelebrityTypeRepository;
        private CelebrityRepository _celebrityRepository;


        public CelebrityController(
            ILKCelebrityTypeRepository lkCelebrityTypeRepository,
            ICelebrityRepository celebrityRepository
            ) 
        {
            _lkCelebrityTypeRepository = (LKCelebrityTypeRepository)lkCelebrityTypeRepository;
            _celebrityRepository = (CelebrityRepository)celebrityRepository;
        }



        // GET: CelebrityController
        public ActionResult Index()
        {
            List<Celebrity> celebrities = _celebrityRepository.CelebrityGetList("", -1);
            return View(celebrities);
        }

        // GET: CelebrityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CelebrityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CelebrityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CelebrityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CelebrityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CelebrityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CelebrityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
