using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IPersonRepository
    {
        public List<Person> GetAllPersonInList();
        public void AddPerson(Person person);
        public Person GetPerson(string Id);
        public void RemovePerson(Person person);
        public void UpdatePerson(Person person);
    }
}
