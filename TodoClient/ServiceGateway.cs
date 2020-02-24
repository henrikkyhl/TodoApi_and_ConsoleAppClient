using System;
using System.Collections.Generic;

using RestSharp;

namespace TodoClient
{
    public class ServiceGateway
    {
        // The base address of the Todo Api may vary whether you run
        // the project on the built-in Kestrel web server or IIS Express
        // (the last one is only available if you are running Visual
        // Studio on Windows)
        string baseAddress = "https://localhost:5001/Todo";

        RestClient c = new RestClient();

        public ServiceGateway()
        {
            c.BaseUrl = new Uri(baseAddress);
        }

        public IEnumerable<TodoItem> GetItems()
        {
            var request = new RestRequest(Method.GET);
            var response = c.Execute<List<TodoItem>>(request);
            return response.Data;
        }

        public TodoItem GetItem(long id)
        {
            var request = new RestRequest(id.ToString(), Method.GET);
            var response = c.Execute<TodoItem>(request);
            return response.Data;
        }

        public bool CreateItem(TodoItem item)
        {
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(item);
            var response = c.Execute(request);
            return response.IsSuccessful;
        }

        public bool UpdateItem(TodoItem item)
        {
            var request = new RestRequest(item.Id.ToString(), Method.PUT);
            request.AddJsonBody(item);
            var response = c.Execute(request);
            return response.IsSuccessful;
        }

        public bool DeleteItem(long id)
        {
            var request = new RestRequest(id.ToString(), Method.DELETE);
            var response = c.Execute(request);
            return response.IsSuccessful;
        }
    }
}
