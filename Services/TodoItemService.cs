using TodoList.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TodoList.Services
{
    public class TodoItemService
    {
        private readonly IMongoCollection<TodoItem> _TodoItems;

        public TodoItemService(ITodoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _TodoItems = database.GetCollection<TodoItem>(settings.TodoCollectionName);
        }

        public List<TodoItem> Get() =>
            _TodoItems.Find(TodoItem => true).ToList();

        public TodoItem Get(string id) =>
            _TodoItems.Find<TodoItem>(TodoItem => TodoItem.Id == id).FirstOrDefault();

        public TodoItem Create(TodoItem TodoItem)
        {
            _TodoItems.InsertOne(TodoItem);
            return TodoItem;
        }

        public void Update(string id, TodoItem TodoItemIn) =>
            _TodoItems.ReplaceOne(TodoItem => TodoItem.Id == id, TodoItemIn);

        public void Remove(TodoItem TodoItemIn) =>
            _TodoItems.DeleteOne(TodoItem => TodoItem.Id == TodoItemIn.Id);

        public void Remove(string id) =>
            _TodoItems.DeleteOne(TodoItem => TodoItem.Id == id);
    }
}