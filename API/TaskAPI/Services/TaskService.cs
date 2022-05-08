using System;
using System.Collections.Generic;
using System.Linq;
using TaskAPI.Models.DTO;
using TaskAPI.Models.Entities;
using TaskAPI.Services.Interfaces;

namespace TaskAPI.Services
{
    public class TaskService : ITaskService
    {

        public static List<TaskModel> AllTasks { get; set; }

        public TaskService()
        {
            if (AllTasks == null)
            {
                AllTasks = InitDummyData();
            }
        }

        private List<TaskModel> InitDummyData()
        {
            return new List<TaskModel>{
             new TaskModel("mua quat", true),
             new TaskModel("di lam", true),
            };
        }

        public TaskModel Create(NewTaskDTO newTask)
        {
            var addingTask = new TaskModel(newTask.Tilte, newTask.IsCompleted);

            AllTasks.Add(addingTask);

            return addingTask;
        }

        public TaskModel Get(Guid id)
        {
            return AllTasks.FirstOrDefault(t => t.Id == id);
        }

        public TaskModel Update(EditTaskDTO editTask)
        {
            var existingTask = Get(editTask.Id);
            if (existingTask != null)
            {
                existingTask.Tilte = editTask.Tilte;
                existingTask.IsCompleted = editTask.IsCompleted;

                return existingTask;
            }

            return null;
        }

        public bool Delete(Guid id)
        {
            var existingTask = Get(id);
            if (existingTask != null)
            {
                AllTasks.Remove(existingTask);

                return true;
            }

            return false;
        }

        public int DeleteMultipleTasks(IEnumerable<Guid> ids)
        {
            return AllTasks.RemoveAll(x => ids.Contains(x.Id));
        }

        public bool CreateMultipleTasks(IEnumerable<NewTaskDTO> newTaskDTOs)
        {
            try
            {
                if (newTaskDTOs != null && newTaskDTOs.Any())
                {
                    var addingTasks = newTaskDTOs.ToList().Select(x => new TaskModel(x.Tilte, x.IsCompleted));
                    AllTasks.AddRange(addingTasks);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<TaskModel> ListAll()
        {
            return AllTasks;
        }
    }
}