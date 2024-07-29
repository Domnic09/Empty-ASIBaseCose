using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        private readonly AsiBasecodeDBContext _context;
        public PersonRepository(IUnitOfWork unitOfWork, AsiBasecodeDBContext asiBasecodeDB) : base(unitOfWork)
        {
            _context = asiBasecodeDB;
        }

        public List<Person> GetAllPersonInList()
        {
            return this.GetDbSet<Person>().ToList();
        }

        public void AddPerson(Person person)
        {
            this.GetDbSet<Person>().Add(person);
            UnitOfWork.SaveChanges();
        }
        public Person GetPerson(string Id)
        {
            return this.GetDbSet<Person>().FirstOrDefault(x => x.Id == Id);
           
        }

        public void RemovePerson(Person person)
        {
            this.GetDbSet<Person>().Remove(person);
            UnitOfWork.SaveChanges();
        }
       

    }
}
