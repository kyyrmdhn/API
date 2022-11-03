using Api.Context;
using Api.Models;
using Api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Data
{
    public class DivisionRepository : IRepository<Division, int>
    {
        private MyContext myContext;
        public DivisionRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
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
        }
    }
}
