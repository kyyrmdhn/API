﻿using Api.Context;
using Api.Repositories.Interface;

namespace Api.Repositories.Data
{
    public class GeneralRepository<Entity> : IRepository<Entity, int>
        where Entity : class
    {
        MyContext myContext;
        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IEnumerable<Entity> Get()
        {
            return myContext.Set<Entity>().ToList();
        }
        public Entity GetById(int id)
        {
            return myContext.Set<Entity>().Find(id);
        }
        public int Create(Entity Entity)
        {
            myContext.Set<Entity>().Add(Entity);
            var result = myContext.SaveChanges();
            return result;
        }
        public int Update(Entity Entity)
        {
            myContext.Set<Entity>().Update(Entity);
            var result = myContext.SaveChanges();
            return result;
        }
        public int Delete(int id)
        {
            var data = GetById(id);
            myContext.Set<Entity>().Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
