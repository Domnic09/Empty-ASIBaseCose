using ASI.Basecode.Data.Models;
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
        public readonly IMapper _personMapper;
        public PersonController(IHttpContextAccessor httpContextAccessor,
                              ILoggerFactory loggerFactory,
                              IConfiguration configuration,
                              IPersonService personService,
                               IMapper mapper = null) : base(httpContextAccessor, loggerFactory, configuration, mapper)
        {

            _personService = personService;
            _personMapper = mapper;
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
        public IActionResult Update(string id)
        {
            var person = _personService.Details(id);
            return View(person);  
        }
        [HttpPost]
        public IActionResult UpdateNow(PersonViewModel personViewModel)
        {
            //var person = _personService.Details(id);
            //PersonViewModel personViewModel = new PersonViewModel();
            //if (person != null)
            //{
                _personService.EditPerson(personViewModel);
            //}
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {

            bool isDeleted = _personService.DeletePerson(id);

            if (isDeleted)
            {
                return RedirectToAction("Index");

            }
            return NotFound();

        }
        //[HttpPost]
        //public IActionResult Update(PersonViewModel personViewModel)
        //{
        //   bool isUpdated = _personService.EditPerson(personViewModel);
        //    if (isUpdated)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return NotFound();
        //}
        [HttpGet]
        public IActionResult Details(string id)
        {
            var person = _personService.Details(id);
            //if (person == null)
            //{
            //    return NotFound();
            //}

            return View(person);
        }

    }
}
