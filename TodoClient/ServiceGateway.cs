using RestSharp;

namespace TodoClient
{
    public class ServiceGateway
    {
        // The base address of the Todo Api may vary whether you run
        // the project on the built-in Kestrel web server or IIS Express
        // (the last one is only available if you are running Visual
        // Studio on Windows)
        const string baseAddress = "https://localhost:5001/Todo";

        RestClient c = new RestClient(baseAddress);


        public IEnumerable<TodoItem> GetItems()
        {
            var request = new RestRequest();
            var response = c.GetAsync<List<TodoItem>>(request);
            response.Wait();
            return response.Result;
        }

        public TodoItem GetItem(long id)
        {
            var request = new RestRequest(id.ToString());
            var response = c.GetAsync<TodoItem>(request);
            response.Wait();
            return response.Result;
        }
        
        public bool CreateItem(TodoItem item)
        {
            var request = new RestRequest();
            request.AddJsonBody(item);
            var response = c.PostAsync(request);
            response.Wait();
            return response.IsCompletedSuccessfully;
        }

        public bool UpdateItem(TodoItem item)
        {
            var request = new RestRequest(item.Id.ToString());
            request.AddJsonBody(item);
            var response = c.PutAsync(request);
            response.Wait();
            return response.IsCompletedSuccessfully;
        }

        public bool DeleteItem(long id)
        {
            var request = new RestRequest(id.ToString());
            var response = c.DeleteAsync(request);
            response.Wait();
            return response.IsCompletedSuccessfully;
        }
    }
}
