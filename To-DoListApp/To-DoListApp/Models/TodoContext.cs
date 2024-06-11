using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace To_DoListApp.Models
{
    public class TodoContext :DbContext
    {
        public TodoContext() : base("name =TodoContext") { }

        public DbSet<TodoItem> TodoItems { get; set; }

    }
}