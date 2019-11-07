using Microsoft.Extensions.DependencyInjection;
using ToDoList.Repository;

namespace ToDoList
{
    public static class DIConfig
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<IPlannerRepository, PlannerRepository>();
        }
    }
}
