using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ToDoList.Core.Entities;
using ToDoList.Core.Repositories;

namespace ToDoList.Infrastructure.Persistence.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly IMongoCollection<ToDo> _toDoCollection;
        public ToDoRepository(IOptions<MongoDbOptions> database)
        {
            var mongoClient = new MongoClient(database.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(database.Value.Database);
            _toDoCollection = mongoDatabase.GetCollection<ToDo>("to-do");
        }

        public async Task<List<ToDo>> GetAllAsync()
        {
            return await _toDoCollection.Find(t => true).ToListAsync();
        }

        public async Task<ToDo> GetByIdAsync(Guid id)
        {
            return await _toDoCollection.Find(t => t.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Guid> AddAync(ToDo toDo)
        {
            await _toDoCollection.InsertOneAsync(toDo);
            return toDo.Id;
        }
        public async Task UpdateAsync(ToDo toDo)
        {
            await _toDoCollection.ReplaceOneAsync(t => t.Id == toDo.Id, toDo);
        }
        public async Task RemoveAsync(Guid id)
        {
            await _toDoCollection.DeleteOneAsync(t => t.Id == id);
        }
    }
}
