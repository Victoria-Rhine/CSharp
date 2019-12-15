using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HomeworkTracker.Models;

namespace HomeworkTracker.DAL
{
    // Class that gives us access to a DB
    public class HomeworkContext : DbContext
    {
        // Which database to connect to (details in web.config)
        public HomeworkContext() : base("name=OurHomeworkDB")
        {

        }

        // Access to our Users table
        public virtual DbSet<Homework> Homework { get; set; }
    }
}