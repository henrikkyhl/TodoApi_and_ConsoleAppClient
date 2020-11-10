using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class SqLiteDbInitializer : IDbInitializer
    {
        // This method will cre<ate and seed the database.
        public void Initialize(TodoContext context)
        {
            // Delete the database, if it already exists. You need to clean and build
            // the solution for this to take effect.
            context.Database.EnsureDeleted();

            // Create the database, if it does not already exists. If the database
            // already exists, no action is taken (and no effort is made to ensure it
            // is compatible with the model for this context).
            context.Database.EnsureCreated();

            List<TodoItem> items = new List<TodoItem>
            {
                new TodoItem {IsComplete=true, Name="Use SqLite"},
                new TodoItem {IsComplete=false, Name="Exam project"}
            };

            context.TodoItems.AddRange(items);
            context.SaveChanges();
        }
    }
}
