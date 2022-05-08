using System;

namespace TaskAPI.Models.Entities
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Tilte { get; set; }
        public bool IsCompleted { get; set; }

        public TaskModel(string tilte, bool isCompleted)
        {
            Id = Guid.NewGuid();
            Tilte = tilte;
            IsCompleted = isCompleted;
        }
    }
}