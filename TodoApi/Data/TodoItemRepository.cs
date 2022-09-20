using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoItemRepository : IRepository<TodoItem>
    {
        private readonly TodoContext db;

        public TodoItemRepository(TodoContext context)
        {
            db = context;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return db.TodoItems.ToList();
        }

        public TodoItem Get(long id)
        {
            return db.TodoItems.Find(id);
        }

        public void Add(TodoItem entity)
        {
            db.TodoItems.Add(entity);
            db.SaveChanges();
        }

        public void Edit(TodoItem entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(long id)
        {
            var item = db.TodoItems.Find(id);
            db.TodoItems.Remove(item);
            db.SaveChanges();
        }
    }
}
