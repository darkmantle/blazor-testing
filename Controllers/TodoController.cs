using TodoList.Models;
using TodoList.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly TodoItemService _todoItemService;

        public BooksController(TodoItemService TodoItemService)
        {
            _todoItemService = TodoItemService;
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> Get() =>
            _todoItemService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<TodoItem> Get(string id)
        {
            var todo = _todoItemService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        [HttpPost]
        public ActionResult<TodoItem> Create(TodoItem todo)
        {
            _todoItemService.Create(todo);

            return CreatedAtRoute("GetBook", new { id = todo.Id.ToString() }, todo);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, TodoItem todoIn)
        {
            var todo = _todoItemService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            _todoItemService.Update(id, todoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var todo = _todoItemService.Get(id);

            if (todo == null)
            {
                return NotFound();
            }

            _todoItemService.Remove(todo.Id);

            return NoContent();
        }
    }
}