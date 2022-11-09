using Api.Context;
using Api.Models;
using Api.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Data
{
    public class DivisionRepository : GeneralRepository<Division>
    {
        private MyContext myContext;
        public DivisionRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public List<Division> Get(string name)
        {
            return myContext.Divisions.Where(d => d.Name == name).ToList();
        }
        /*
        //GET ALL
        public IEnumerable<Division> Get()
        {
            return myContext.Divisions.ToList();
        }
        //GET BY ID
        public Division GetById(int id)
        {
            return myContext.Divisions.Find(id);
        }
        //CREATE
        public int Create(Division division)
        {
            myContext.Divisions.Add(division);
            var result = myContext.SaveChanges();
            return result;
        }
        //UPDATE
        public int Update(Division division)
        {
            myContext.Entry(division).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }
        //DELETE
        public int Delete(int id)
        {
            var data = myContext.Divisions.Find(id);
            if (data != null)
            {
                myContext.Remove(data);
                var result = myContext.SaveChanges();
                return result;
            }
            return 0;
        }*/
    }
}
