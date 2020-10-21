using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class DbInitializer : IDbInitializer
    {
        // This method will create and seed the database.
        public void Initialize(TodoContext context)
        {
            // Create the database, if it does not already exists. If the database
            // already exists, no action is taken (and no effort is made to ensure it
            // is compatible with the model for this context).
            context.Database.EnsureCreated();

            // Look for any TodoItems
            if (context.TodoItems.Any())
            {
                // Delete and re-create the database, if it had already been created.
                // You must delete all the tables in the database.
                context.Database.ExecuteSqlRaw("DROP TABLE TodoItems");
                context.Database.EnsureCreated();
            }

            List<TodoItem> items = new List<TodoItem>
            {
                new TodoItem {IsComplete=true, Name="Deploy TodoApi"}
            };

            context.TodoItems.AddRange(items);
            context.SaveChanges();
        }
    }
}
