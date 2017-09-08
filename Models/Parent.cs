using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace auditproblem.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Child> Children { get; set; }
    }
}
