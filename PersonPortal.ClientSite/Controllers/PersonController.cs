using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonPortal.ClientSite.Models;
using PersonPortal.Contracts.Interfaces.Services;
using PersonPortal.Contracts.Models;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PersonPortal.ClientSite.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;
        private readonly ICityService _cityService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PersonController(
            ILogger<PersonController> logger,
            IPersonService personService,
            ICityService cityService,
            IHostingEnvironment hostingEnvironment
            )
        {
            _logger = logger;
            _personService = personService;
            _cityService = cityService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var personList = _personService.GetPersons();
            return View(personList);
        }

        public IActionResult Create()
        {
            var model = new CreatePersonViewModel
            {
                Persons = _personService.GetPersons(),
                Cities = _cityService.GetCities(),
                Person = new PersonModel()
            };
            return View(model);
        }

        public IActionResult CreatePerson(PersonModel model, IFormFile file)
        {
            string personImagePath = null;

            if (file != null && file.Length > 0)
            {
                var extension = Path.GetExtension(file.FileName);
                personImagePath = $"{Guid.NewGuid()}{extension}";
                var filePath = $"{_hostingEnvironment.WebRootPath}/Images/{personImagePath}";

                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }
            }

            model.ImagePath = personImagePath;

            _personService.CreatePerson(model);

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var cities = _cityService.GetCities();
            var person = _personService.GetPersonById(id);

            var personViewModel = new UpdatePersonViewModel
            {
                Person = person,
                Cities = cities
            };

            return View(personViewModel);
        }
        [HttpPost]
        public IActionResult Update(PersonModel person)
        {
            _personService.UpdatePerson(person);
            return RedirectToAction("Index");
        }

        public IActionResult RelatedPersons(int id)
        {
            var person = _personService.GetPersonById(id);

            var viewModel = new RelatedPersonsViewModel
            {
                ID = person.Id,
                RelatedPersons = person.RelatedPersons
            };

            return View(viewModel);
        }

        public IActionResult DeleteRelatedPerson(int id, int parentId)
        {
            var person = _personService.GetPersonById(parentId);
            var relatedPerson = _personService.GetPersonById(id);
            _personService.DeleteRelatedPerson(person, relatedPerson);

            return RedirectToAction("RelatedPersons", new { id = parentId });
        }

        public IActionResult AddRelatedPersonView(int id)
        {
            var relationTypes = _personService.GetPersonRelationTypes();
            var persons = _personService.GetPersons();

            var model = new AddPersonViewModel
            {
                Id = id,
                RelatedPersons = persons.ToList(),
                RelationTypes = relationTypes.ToList()
            };

            return View(model);
        }
        public IActionResult AddRelatedPerson(AddPersonViewModel model)
        {
            var person = _personService.GetPersonById(model.Id);
            var relatedPerson = _personService.GetPersonById(model.RelatedPersonId);
            _personService.AddRelatedPerson(person, relatedPerson, model.RelationTypeId);

            return RedirectToAction("RelatedPersons", new { id = model.Id });
        }
    }
}