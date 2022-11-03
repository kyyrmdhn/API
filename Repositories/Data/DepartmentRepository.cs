using Api.Context;
using Api.Models;
using Api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Data
{
    public class DepartmentRepository : IRepository<Department, int>
    {
        private MyContext myContext;
        public DepartmentRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IEnumerable<Department> Get()
        {
            return myContext.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return myContext.Departments.Find(id);
        }
        public int Create(Department department)
        {
            myContext.Departments.Add(department);
            var result = myContext.SaveChanges();
            return result;
        }
        public int Update(Department department)
        {
            myContext.Entry(department).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }
        public int Delete(int id)
        {
            var data = myContext.Departments.Find(id);
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
