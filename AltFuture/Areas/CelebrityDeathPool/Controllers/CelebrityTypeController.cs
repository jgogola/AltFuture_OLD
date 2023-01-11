using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AltFuture.Areas.CelebrityDeathPool.Models;
using AltFuture.Areas.CelebrityDeathPool.Services;

namespace AltFuture.Areas.CelebrityDeathPool.Controllers
{
    [Area("CelebrityDeathPool")]
    [Authorize]
    [Authorize(Policy = "CompetitionPlayerPolicy")]
    public class CelebrityTypeController : Controller
    {

        private LKCelebrityTypeRepository _lkCelebrityTypeRepository;


        public CelebrityTypeController(
            ILKCelebrityTypeRepository lkCelebrityTypeRepository
            )
        {
            _lkCelebrityTypeRepository = (LKCelebrityTypeRepository)lkCelebrityTypeRepository;
        }

        // GET: CelebrityTypeController
        public ActionResult Index()
        {
            List<LK_Celebrity_Type> lk_celebritie_types = _lkCelebrityTypeRepository.LKCelebrityTypeGetList();
            return View(lk_celebritie_types);
        }

        // GET: CelebrityTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CelebrityTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CelebrityTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LK_Celebrity_Type lk_celebrity_type)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int lk_celebrity_type_key = _lkCelebrityTypeRepository.LKCelebrityTypeAdd(lk_celebrity_type);
                    TempData["CelebrityTypeUserMsg"] = $"{lk_celebrity_type.celebrity_type} was updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ViewBag.UserMsg = "CATCH!";
                    return View(lk_celebrity_type);
                }
            }
            else
            {
                ViewBag.UserMsg = "ELSE!";
                return View(lk_celebrity_type);
            }
        }

        // GET: CelebrityTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            LK_Celebrity_Type lk_celebrity_type = _lkCelebrityTypeRepository.LKCelebrityTypeGet(id);
            return View(lk_celebrity_type);
        }

        // POST: CelebrityTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LK_Celebrity_Type lk_celebrity_type)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _lkCelebrityTypeRepository.LKCelebrityTypeUpd(lk_celebrity_type);
                    TempData["CelebrityTypeUserMsg"] = $"{lk_celebrity_type.celebrity_type} was updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ViewBag.UserMsg = "CATCH!";
                    return View(lk_celebrity_type);
                }
            }
            else
            {
                ViewBag.UserMsg = "ELSE!";
                return View(lk_celebrity_type);
            }
        }


        // POST: CelebrityTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string type)
        {
            try
            {
                int success = _lkCelebrityTypeRepository.LKCelebrityTypeDel(id);

                if (success == 1)
                {
                    TempData["CelebrityTypeUserMsg"] = $"{type} was deleted successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["CelebrityTypeUserMsg"] = $"Delete Canceled: {type} was found to be in use and could not be deleted.";
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                TempData["CelebrityTypeUserMsg"] = "Delete Failed.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
