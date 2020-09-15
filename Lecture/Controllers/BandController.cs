using Lecture.Data;
using Lecture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lecture.Controllers
{
    public class Band : Controller
    {
        private readonly ApplicationDbContext _context;
        public Band(ApplicationDbContext context)
        {
            _context = context;
        }
        // view all bands
        public IActionResult Index()
        {
            return View(_context);
        }
        // view details
        public IActionResult Details(int bandID)
        {
            BandModel matchingBand = _context.bands.FirstOrDefault(band => band.id == bandID);
            if(matchingBand != null)
            {
                return View(matchingBand);
            } else
            {
                return Content("No Matching Band Found");
            }
        }

        // create
        [HttpPost]
        public IActionResult Add(BandModel newBand)
        {
            if(ModelState.IsValid)
            {
                _context.bands.Add(newBand);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else 
            {
                return View("AddForm", newBand);
            }

        }

        // update
        [HttpPost]
        public IActionResult Update(BandModel updateBand)
        {
            BandModel matchingBand = _context.bands.FirstOrDefault(band => band.id == updateBand.id);
            if(matchingBand != null)
            {
                if(ModelState.IsValid)
                {
                    matchingBand.bandName = updateBand.bandName;
                    matchingBand.yearFormed = updateBand.yearFormed;
                    matchingBand.numberOfMembers = updateBand.numberOfMembers;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                } else
                {
                    return View("UpdateForm", updateBand);
                }
            } else 
            {
                return Content("No matching band found");
            }
        }

        // delete
        public IActionResult Delete(int bandID)
        {
            BandModel matchingBand = _context.bands.FirstOrDefault(band => band.id == bandID);
            if(matchingBand != null)
            {
                _context.Remove(matchingBand);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else 
            {
                return Content("Matching Band Not Found");
            }
        }

        // create form
        [Authorize]
        public IActionResult AddForm()
        {
            return View();
        }

        // update form
        [Authorize]
        public IActionResult UpdateForm(int bandID)
        {            
            BandModel matchingBand = _context.bands.FirstOrDefault(band => band.id == bandID);
            if(matchingBand != null)
            {
                return View(matchingBand);
            } else 
            {
                return Content("Matching Band Not Found");
            }
        }

        // delete confirmation
        [Authorize]
        public IActionResult DeleteConf(int bandID)
        {
            BandModel matchingBand = _context.bands.FirstOrDefault(band => band.id == bandID);
            if(matchingBand != null)
            {
                return View(matchingBand);
            } else 
            {
                return Content("Matching Band Not Found");
            }
        }
    }
}