namespace Api.Repositories.Interface
{
    public interface IRepository<Entity, Key> where Entity : class
    {
        //Entity menandakan class
        //Key menandakan type
        public IEnumerable<Entity> Get();
        public Entity GetById(Key id);
        public int Create(Entity Entity);
        public int Update(Entity Entity);
        public int Delete(Key id);
    }
}
