using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Services.Interfaces;
using ToDoList.Application.ViewModels;

namespace ToDoList.Controllers
{
    [Route("api/todo")]
    public class ToDoController: ControllerBase
    {
        private readonly IToDoService _toDoService;
        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var toDos = await _toDoService.GetAll();

            return Ok(toDos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var project = await _toDoService.GetById(id);

            if (project is null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertToDoViewModel toDo)
        {
            var id = await _toDoService.Add(toDo);

            return CreatedAtAction(nameof(GetById), new { id = id }, toDo);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateToDoViewModel toDo)
        {
            await _toDoService.Update(toDo);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _toDoService.Delete(id);

            return NoContent();
        }

    }
}
