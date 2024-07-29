using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using ASI.Basecode.WebApp.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ASI.Basecode.WebApp.Controllers
{
    public class PersonController : ControllerBase<PersonController>
    {
        public readonly IPersonService _personService;
        public PersonController(IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IPersonService personService,
                               IMapper mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {

            _personService = personService;
        }
        
  
        public IActionResult Index()
        {
            var linkedlist = _personService.GetAllPersonInList();
            return View(linkedlist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonViewModel personViewModel)
        {
            _personService.AddPerson(personViewModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete( )
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Delete(string Id)
        //{


        //    _personService.DeletePerson(Id);
        //    //_personService.DeletePerson(personViewModel);
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public IActionResult Delete(PersonViewModel personViewModel)
        {

            bool isDeleted = _personService.DeletePerson(personViewModel);

            if (isDeleted)
            {
                return RedirectToAction("Index");

            }
            return NotFound();

        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            var person = _personService.Details(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

    }
}
