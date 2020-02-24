using System;
namespace TodoApi.Data
{
    public interface IDbInitializer
    {
        void Initialize(TodoContext context);
    }
}
