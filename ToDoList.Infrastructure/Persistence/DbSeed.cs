using MongoDB.Driver;
using ToDoList.Core.Entities;

namespace ToDoList.Infrastructure.Persistence
{
    public class DbSeed
    {
        private readonly IMongoCollection<ToDo> _collection;
        private ToDo _toDo = new ToDo("Inital task", false);

        public DbSeed(IMongoDatabase database)
        {
            _collection = database.GetCollection<ToDo>("to-do");
        }
        public void Populate()
        {
            if ((_collection.CountDocuments(c => true) == 0))
                _collection.InsertOne(_toDo);
        }
    }
}
