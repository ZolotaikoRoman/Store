﻿namespace Todos.MVC.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Todo { get; set; }

        public bool Completed { get; set; }

        public int UserId { get; set; }
    }
}