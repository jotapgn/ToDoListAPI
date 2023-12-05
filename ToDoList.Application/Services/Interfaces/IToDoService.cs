using ToDoList.Application.ViewModels;

namespace ToDoList.Application.Services.Interfaces
{
    public interface IToDoService
    {
        Task<Guid> Add(InsertToDoViewModel toDo);
        Task Delete(Guid id);
        Task<List<ToDoViewModel>> GetAll();
        Task<ToDoViewModel> GetById(Guid id);
        Task Update(UpdateToDoViewModel toDo);
    }
}