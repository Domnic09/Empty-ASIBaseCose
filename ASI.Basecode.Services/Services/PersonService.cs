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
        public void EditPerson(PersonViewModel personViewModel)
        {
            Person person = new()
            {
                Id = personViewModel.Id,
                Name = personViewModel.Name,
                Age = personViewModel.Age,
                Address = personViewModel.Address,
            };
            _repository.UpdatePerson(person);
        }
        //public bool EditPerson(PersonViewModel personViewModel)
        //{
        //    Person person = _repository.GetPerson(personViewModel.Id);
        //    if (person != null)
        //    {
        //        person.Id = personViewModel.Id;
        //        person.Name = personViewModel.Name;
        //        person.Age = personViewModel.Age;
        //        person.Address = personViewModel.Address;
        //        _repository.UpdatePerson(person);
        //        return true;
        //    }
        //    return false;
        //}

        //public bool EditPerson(string id)
        //{
        //    Person pers = _repository.GetPerson(id);

        //    if (pers != null)
        //    {
        //        Person person = new()
        //        {
        //            Id = id,
        //            Name = pers.Name,
        //            Age = pers.Age,
        //            Address = pers.Address,
        //        };
        //        _repository.UpdatePerson(person);
        //        return true;
        //    }
        //    return false;
        //}

        public bool DeletePerson(string id)
        {
            Person person = _repository.GetPerson(id);
            if (person != null)
            {
                _repository.RemovePerson(person);
                return true;
            }
            return false;

        }

        public Person Details(string id)
        {
            return _repository.GetPerson(id);
        }

    }
}
