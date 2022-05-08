using System;
using System.Collections.Generic;
using TaskAPI.Models.DTO;
using TaskAPI.Models.Entities;

namespace TaskAPI.Services.Interfaces
{
    public interface ITaskService
    {
        TaskModel Create(NewTaskDTO newTask);
        TaskModel Get(Guid id);
        TaskModel Update(EditTaskDTO editTask);
        bool Delete(Guid id);
        IEnumerable<TaskModel> ListAll();
        int DeleteMultipleTasks(IEnumerable<Guid> ids);
        bool CreateMultipleTasks(IEnumerable<NewTaskDTO> newTaskDTOs);
    }
}