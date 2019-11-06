using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Repository;

namespace ToDoList.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPlannerRepository PlannerRepository { get; }

        int Complete();
    }
}
