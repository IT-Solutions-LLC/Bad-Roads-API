using ITSTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITSTracker.Services
{
    public interface IService
    {
        List<MyTask> GetTasks();
        MyTask Get(int id);

        MyTask Add(MyTask task);
    }
}
