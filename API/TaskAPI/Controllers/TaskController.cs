using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Models.DTO;
using TaskAPI.Models.Entities;
using TaskAPI.Services.Interfaces;
using System.Linq;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public TaskModel Create([FromBody] NewTaskDTO newTask)
        {
            return _taskService.Create(newTask);
        }

        [HttpGet]
        public IEnumerable<TaskModel> GetAll()
        {
            return _taskService.ListAll();
        }

        [HttpGet("{id:guid}")]
        public TaskModel Get(Guid id)
        {
            return _taskService.Get(id);
        }

        [HttpDelete]
        public bool Delete(Guid id)
        {
            return _taskService.Delete(id);
        }

        [HttpPut]
        public TaskModel Edit([FromBody] EditTaskDTO editTask)
        {
            return _taskService.Update(editTask);
        }

        [HttpPost("/multiple-tasks")]
        public bool CreateMultipleTasks([FromBody] IEnumerable<NewTaskDTO> newTasks)
        {
            return _taskService.CreateMultipleTasks(newTasks);
        }

        [HttpDelete("/multiple-tasks")]
        public void DeleteMultipleTasks([FromBody] IEnumerable<Guid> ids)
        {
            _taskService.DeleteMultipleTasks(ids);
        }
    }
}