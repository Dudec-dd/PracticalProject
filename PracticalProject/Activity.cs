using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalProject
{
    
    internal class Activity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public Activity() { }
        public Activity(string name, string description)
        { 
            Name = name; 
            Description = description; 
        }
    }
}
