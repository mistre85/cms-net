using Microsoft.Extensions.Primitives;
using System;
namespace cms_net.Models
{
    public class Field
    {
        private StringValues stringValues;

        public int Id { get; set; }

        public string Name { get; set; } 

        public string Value { get; set; } 

        //relazione 1 a n
        public int ComponentId { get; set; }
        public Component Component { get; set; }

        public Field()
        {
            
        }

        public Field(string name, string value) 
        {
            Name = name;
            Value = value;
        }
    }
}

