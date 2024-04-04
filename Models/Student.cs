using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAPI.Models
{
    public class Student
    {
        public int Id {get; set;}
        // when you have a dataType?   === nullable value, it is allowed to be blank!
        public string? Name {get; set;}
        public string? Address {get; set;}
        public string? PhoneNumber {get; set;}
        public string? Email {get; set;}
        // by using the emmet snippet "prop" and then the tab key, a new property template is created         public int MyProperty { get; set; }
        
    }
}