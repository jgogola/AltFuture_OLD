using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using AltFuture.Areas.CelebrityDeathPool.Models;
using AltFuture.Areas.CelebrityDeathPool.Services;

namespace AltFuture.Areas.CelebrityDeathPool.Controllers
{
    [Area("CelebrityDeathPool")]
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
            ViewBag.SelectListCelebrityTypes = new SelectList(_lkCelebrityTypeRepository.LKCelebrityTypeGetList(), "lk_celebrity_type_key", "celebrity_type");
            return View();
        }

        // POST: CelebrityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Celebrity celebrity)
        {
            bool is_success = true;
            string userMsg = "";

            if (ModelState.IsValid)
            {
                try
                {
                    int new_key = _celebrityRepository.CelebrityAdd(celebrity);
                    userMsg = $"{celebrity.celebrity_name} was successfully added.";
                }
                catch
                {
                    is_success = false;
                    userMsg = "Save Canceled: Issue with saving to database.";
                }
            }
            else
            {
                is_success = false;
                userMsg = "Save Canceled: Please review your entries below.";
            }

            ViewBag.UserMsg = userMsg;

            if (is_success)
            {
                TempData["CelebrityUserMsg"] = $"{celebrity.celebrity_name} was successfully added.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.SelectListCelebrityTypes = new SelectList(_lkCelebrityTypeRepository.LKCelebrityTypeGetList(), "lk_celebrity_type_key", "celebrity_type");
                return View(celebrity);
            }

        }

        // GET: CelebrityController/Edit/5
        public ActionResult Edit(int id)
        {
            Celebrity celebrity = _celebrityRepository.CelebrityGet(id);
            ViewBag.SelectListCelebrityTypes = new SelectList(_lkCelebrityTypeRepository.LKCelebrityTypeGetList(), "lk_celebrity_type_key", "celebrity_type");
            return View(celebrity);
        }

        // POST: CelebrityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Celebrity celebrity)
        {
            bool is_success = true;
            string userMsg = "";

            if (ModelState.IsValid)
            {
                try
                {
                    _celebrityRepository.CelebrityUpd(celebrity);
                    userMsg = $"{celebrity.celebrity_name} was successfully added.";
                }
                catch
                {
                    is_success = false;
                    userMsg = "Save Canceled: Issue with saving to database.";
                }
            }
            else
            {
                is_success = false;
                userMsg = "Save Canceled: Please review your entries below.";
            }

            ViewBag.UserMsg = userMsg;

            if (is_success)
            {
                TempData["CelebrityUserMsg"] = $"{celebrity.celebrity_name} was successfully updated.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.SelectListCelebrityTypes = new SelectList(_lkCelebrityTypeRepository.LKCelebrityTypeGetList(), "lk_celebrity_type_key", "celebrity_type");
                return View(celebrity);
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

        //#region "LK_Celebirty_Type CRUD"

        //public ActionResult CreateCelebrityType()
        //{
        //    return View();
        //}

        //// POST: CelebrityController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateCelebrityType(LK_Celebrity_Type lk_celebrity_type)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            int lk_celebrity_type_key = _lkCelebrityTypeRepository.LKCelebrityTypeAdd(lk_celebrity_type);
        //            ViewBag.UserMsg = "Your Celebrity Type was added successfully.";
        //            return RedirectToAction("EditCelebrityType", new { id = lk_celebrity_type_key, add = true });
        //            //return View();
        //        }
        //        catch
        //        {
        //            ViewBag.UserMsg = "CATCH!";
        //            return View(lk_celebrity_type);
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.UserMsg = "ELSE!";
        //        return View(lk_celebrity_type);
        //    }

        //}


        //// GET: CelebrityController/EditCelebrityType/5
        //public ActionResult EditCelebrityType(int id)
        //{
        //    LK_Celebrity_Type lk_celebrity_type = _lkCelebrityTypeRepository.LKCelebrityTypeGet(id);
        //    return View(lk_celebrity_type);
        //}

        //// POST: CelebrityController/EditCelebrityType/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditCelebrityType(int id, LK_Celebrity_Type lk_celebrity_type)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _lkCelebrityTypeRepository.LKCelebrityTypeUpd(lk_celebrity_type);
        //            ViewBag.UserMsg = "Your Celebrity Type was updated successfully.";
        //            // return RedirectToAction(nameof(Index));
        //            return View(lk_celebrity_type);
        //        }
        //        catch
        //        {
        //            ViewBag.UserMsg = "CATCH!";
        //            return View(lk_celebrity_type);
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.UserMsg = "ELSE!";
        //        return View(lk_celebrity_type);
        //    }
        //}

        //#endregion
    }
}
