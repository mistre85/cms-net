using System;
namespace cms_net.Models
{
    public class Field
    {
        public int Id { get; set; }

        public string Name;

        public string Value;

        //relazione 1 a n
        public int ComponentId;
        public Component Component { get; set; }

        public Field()
        {
            
        }

        public Field(string name)
        {
            Name = name;
        }
    }
}

