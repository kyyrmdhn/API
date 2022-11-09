namespace Api.Repositories.Interface
{
    public interface IRepository<Entity, K> 
        where Entity : class
    {
        //Entity menandakan class
        //Key menandakan type
        public IEnumerable<Entity> Get();
        public Entity GetById(K id);
        public int Create(Entity Entity);
        public int Update(Entity Entity);
        public int Delete(K id);
    }
}
