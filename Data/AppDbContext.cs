using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCAPI.Models;

namespace MVCAPI.Data
{
    public class AppDbContext  :  DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options){
            
        }
        // lets make a new variable which will link to from the database to the student
        // in order to attach properly we will be using the get:set from our student.cs
        public DbSet<Student>Students {get; set;}

    }
}