namespace CMS_seminar.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        public T GetById(int id);
        public void CreateNew(T obj);
        public void Delete(int id);
        public void Update(T obj);
    }
}
