using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Services.Interfaces
{
    public interface IPersonService
    {
        //public List<Person> CreatePerson(Person person);
        public List<Person> GetAllPersonInList();
        public void AddPerson(PersonViewModel personViewModel);
        public bool DeletePerson(PersonViewModel personViewModel);
        //public bool Details(PersonViewModel personViewModel);
        public Person Details(string id);


    }
}
