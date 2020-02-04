using Microsoft.Extensions.DependencyInjection;
using ToDoList.Persistence.Repositories.Commands;
using ToDoList.Persistence.Repositories.Queries;

namespace ToDoList
{
    public static class DIConfig
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseCommandsRepository<>), typeof(BaseCommandsRepository<>));
            services.AddTransient(typeof(IBaseReadRepository<>), typeof(BaseReadRepository<>));
        }
    }
}
