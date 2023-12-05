using ToDoList.Application.Services.Interfaces;
using ToDoList.Application.ViewModels;
using ToDoList.Core.Entities;
using ToDoList.Core.Repositories;

namespace ToDoList.Application.Services
{
    public class ToDoService : IToDoService
    {
        public readonly IToDoRepository _todoRepository;
        public ToDoService(IToDoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<ToDoViewModel>> GetAll()
        {
            var toDos = await _todoRepository.GetAllAsync();

            return toDos
                .Select(td => new ToDoViewModel(
                        td.Id,
                        td.Title,
                        td.Done,
                        td.Date
                    )).ToList();
        }
        public async Task<ToDoViewModel> GetById(Guid id)
        {
            var toDo = await _todoRepository.GetByIdAsync(id);

            return new ToDoViewModel(
                        toDo.Id,
                        toDo.Title,
                        toDo.Done,
                        toDo.Date
                    );

        }
        public async Task<Guid> Add(InsertToDoViewModel toDo)
        {
            var toDoEntity = new ToDo(toDo.Title, toDo.Done);
            return await _todoRepository.AddAync(toDoEntity);
            
        }
        public async Task Update(UpdateToDoViewModel toDo)
        {
            var toDoEntity = new ToDo(toDo.Id, toDo.Title, toDo.Done);;
            await _todoRepository.UpdateAsync(toDoEntity);
        }
        public async Task Delete(Guid id)
        {
            await _todoRepository.RemoveAsync(id);
        }
    }
}
