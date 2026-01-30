using System;

namespace SWENG421_Lab3
{
    public class Task
    {
        public int Id 
        { 
            get; 
        }
        public DateTime DueDate 
        { 
            get; 
        }
        public string Description 
        { 
            get; 
        }

        public Task(int id, DateTime dueDate, string description)
        {
            Id = id;
            DueDate = dueDate;
            Description = description;
        }
    }
}

