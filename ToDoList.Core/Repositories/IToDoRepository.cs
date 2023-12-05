using ToDoList.Core.Entities;

namespace ToDoList.Core.Repositories
{
    public interface IToDoRepository
    {
        Task<Guid> AddAync(ToDo toDo);
        Task<List<ToDo>> GetAllAsync();
        Task<ToDo> GetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(ToDo toDo);
    }
}