using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class SqlServerDbInitializer: IDbInitializer
    {
        // This method will cre<ate and seed the database.
        public void Initialize(TodoContext context)
        {
            // Create the database, if it does not already exists. If the database
            // already exists, no action is taken (and no effort is made to ensure it
            // is compatible with the model for this context).
            context.Database.EnsureCreated();

            //Look for any TodoItems
            if (context.TodoItems.Any())
                {
                // Delete and re-create the database, if it had already been created.
                // You must delete all the tables in the database. We do this, because
                // "context.Database.EnsureDeleted()" doesn't work on an Azure SQL
                // database with our type of subscription.
                // The statements below doesn't work on SqLite. This is the reason why
                // we have two database initializer classes (one for SqLite and one for
                // SQL Server.
                context.Database.ExecuteSqlRaw("DROP TABLE TodoItems");
                    context.Database.EnsureCreated();
                }

            List<TodoItem> items = new List<TodoItem>
            {
                new TodoItem {IsComplete=true, Name="Use SQL Server"}
            };

            context.TodoItems.AddRange(items);
            context.SaveChanges();
        }
    }
}
