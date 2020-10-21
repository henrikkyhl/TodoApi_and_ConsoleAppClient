using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class DbInitializer : IDbInitializer
    {
        // This method will create and seed the database.
        public void Initialize(TodoContext context)
        {
            // Delete the database, if it already exists.
            // It seems that this operation will cause the application to exit with
            // an error, when a free Azure SQL Server database is used. For that
            // reason, I have commented it out.
            // This means that when you make changes to the entity model, you must
            // manually delete all the database tables before you re-publish the
            // application to your Azure Web App. Alternatively, you can create a
            // new Azure "Web App + SQL" and re-publis to it.
            // context.Database.EnsureDeleted();

            // Create the database, if it does not already exists. This operation
            // is necessary, if you use an SQL Server database. The method does not
            // check, if the entity model was changed since the database was created.
            context.Database.EnsureCreated();

            // Look for any TodoItems
            if (context.TodoItems.Any())
            {
                return;   // DB has been seeded
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
