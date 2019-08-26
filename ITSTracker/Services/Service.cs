using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITSTracker.Models;

namespace ITSTracker.Services
{
    public class Service : IService
    {
        public List<MyTask> Tasks { get; set; }

        public Service()
        {
            this.Tasks = new List<MyTask>()
            {
                new MyTask
                {
                    Id = 1,
                    Title = "First Task",
                    Content = "First Task Content"
                },
                new MyTask
                {
                    Id = 2,
                    Title = "Second Task",
                    Content = "Second Task Content"
                }
            };
        }
        public MyTask Add(MyTask task)
        {
            var t = this.Tasks.FirstOrDefault((obj) =>
            {
                return obj.Id == task.Id;
            });
            if (t != null) return null;
            this.Tasks.Add(task);
            return task;
        }

        public MyTask Get(int id)
        {
            return this.Tasks.Find((obj) =>
            {
                return obj.Id == id;
            });
        }

        public List<MyTask> GetTasks()
        {
            return this.Tasks;
        }
    }
}
