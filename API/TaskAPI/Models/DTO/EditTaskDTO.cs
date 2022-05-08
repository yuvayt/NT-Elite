using System;

namespace TaskAPI.Models.DTO
{
    public class EditTaskDTO
    {
        public Guid Id { get; set; }
        public string Tilte { get; set; }
        public bool IsCompleted { get; set; }
    }
}