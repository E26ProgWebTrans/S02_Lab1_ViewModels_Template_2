using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;

namespace ZombieParty.Controllers
{
    public class ZombieTypeController : Controller
    {
        public IActionResult Index()
        {
            this.ViewBag.MaListe = _baseDonnees.ZombieTypes.ToList();
            return View();
        }


        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Models.ZombieType zombieType)
        {
            if (ModelState.IsValid)
            {
                _baseDonnees.ZombieTypes.Add(zombieType);
                TempData["Success"] = $"{zombieType.TypeName} zombie type added";
                return this.RedirectToAction("Index");
            }


            return this.View(zombieType);
        }

        private BaseDonnees _baseDonnees { get; set; }

        public ZombieTypeController(BaseDonnees baseDonnees)
        {
            _baseDonnees = baseDonnees;
        }

        public class ZombieType
        {
            public int Id { get; set; }
            [DisplayName("Type Name")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "{0}Type Name has to be filled.")]
            public string TypeName { get; set; }
        }

    }
}
