using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using ASI.Basecode.Services.ServiceModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;
        private readonly IMapper _mapper;

       
        public PersonService(IPersonRepository repository, IMapper mapper)
        {
            _repository = repository; //to be able to use addBook() from repo
            _mapper = mapper;
        }

        public List<Person> GetAllPersonInList()
        {
            //LinkedList<Person> list = _repository.GetAllPersonInList();
            //return list; 
            return _repository.GetAllPersonInList();

        }
        public void AddPerson(PersonViewModel personViewModel)
        {
            //create new instance
            Person person = new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = personViewModel.Name,
                Age = personViewModel.Age,
                Address = personViewModel.Address,
            }; 
            _repository.AddPerson(person);
        }
        public bool DeletePerson(string id)
        {
            Person person = _repository.GetPerson(id);
            if(person != null)
            {
                _repository.RemovePerson(person);
                return true;
            }
            return false;


        }
        public Person Details(string id)
        {
            //Person person = _repository.GetPerson(personViewModel.Id);
            //if (person != null)
            //{
            //    _repository.GetPerson(person.Id);
            //    return true;
            //}
            //return false;
            //Person person = new()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Name = personViewModel.Name,
            //    Age = personViewModel.Age,
            //    Address = personViewModel.Address,
            //};
            
            //you need to declare void since you are using the method from the repo which is naka return
            return _repository.GetPerson(id);
        }

    }
}
