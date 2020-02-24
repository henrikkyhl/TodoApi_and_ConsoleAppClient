using System;

namespace TodoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create a new TodoItem:");

            var newItem = new TodoItem
            {
                Id = 2,
                Name = "Test",
                IsComplete = true
            };

            bool created = new ServiceGateway().CreateItem(newItem);
            if (created)
                Console.WriteLine("A new TodiItem was succesfully created!");
            else
                Console.WriteLine("A new TodiItem could not be created!");

            Console.WriteLine("Display all TodoItems:");
            var items = new ServiceGateway().GetItems();
            foreach (var item in items)
                Console.WriteLine(item.Id + ": " + item.Name + ", IsComplete: " + item.IsComplete);

            if (created)
            {
                Console.WriteLine("Update the newly created item:");
                newItem.Name = "Test updated";
                bool updated = new ServiceGateway().UpdateItem(newItem);
                if (updated)
                {
                    Console.WriteLine("Display the updated TodoItem:");
                    var updatedItem = new ServiceGateway().GetItem(newItem.Id);
                    Console.WriteLine(updatedItem.Id + ": " + updatedItem.Name + ", IsComplete: " + updatedItem.IsComplete);
                }
                else
                    Console.WriteLine("The TodiItem could not be updated!");

                Console.WriteLine("Delete the newly created item:");
                bool deleted = new ServiceGateway().DeleteItem(newItem.Id);
                if (deleted)
                    Console.WriteLine("The new TodiItem was succesfully deleted!");
                else
                    Console.WriteLine("The new TodiItem could not be deleted!");
            }
        }
    }
}