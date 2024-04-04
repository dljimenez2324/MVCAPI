using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCAPI.Data;
using MVCAPI.Models;

namespace MVCAPI.Controllers
{
    [ApiController]  // this gives context that everything under this is an API Controller
    [Route("api/[controller]")]  // This is saying look into here for knowing more about the controller  this is saying hey we have controlelrs to look at so it looks at Program.css and looks at .addControllers and MapControllers
    public class StudentsController : ControllerBase // This is a constructor and knows you're putting in commands that will be api responses
    {
        
        private readonly AppDbContext _context;  // this is pointing at the spot we want to refference

        public StudentsController(AppDbContext context){  // this is linking up and go through the steps will make ef core and sqlite work together  or connecting what want to talk to
            _context = context;
        }
        
        //  To create data in our CRUD cycle we need to make a POST down below
        // we can now add endpoints
        [HttpPost("/CreatStudent")]  // this is going to be an async communication

        // this task is like a promise of the datatype of a function  notice we have Student is a data type and the variable is newStudent
        public async Task<IActionResult> CreateStudent(Student newStudent){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            // now we can add the await portion for this to work
            // this is now going to connect to the AppDbContext.cs
            await _context.AddAsync(newStudent);

            // now lets double check to make sure things are translating and going to our tables correctly by saving into a variable to check

            // now lets return this data
            var result = await _context.SaveChangesAsync();

            if(result > 0){
                return Ok("Student Created Successfully!");
            }
            else{
                return BadRequest("Could not Create Student");
            }

        }
        
        // // this is where we will be writing our endpoints to read and see our data
        // for a bulk of info we use IEnumerable
        [HttpGet("DisplayStudents")]
        public async Task<IEnumerable<Student>> getStudents(){
            var ourStudents = await _context.Students.AsNoTracking().ToListAsync();
            return ourStudents;
        }
        
    }
}