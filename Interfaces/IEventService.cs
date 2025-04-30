namespace SportsFixture.Interfaces
{
    public interface IEventService<T> where T : class
    {
        public Task<T> AddFixture(T fixture);
        public Task<T?> GetFixtureById(int id);
    }
}
