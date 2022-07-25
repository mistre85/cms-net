using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace cms_net.Models
{
    public class Component
    {
        public int Id { get; set; }

        public List<Field>? fields { get; set; }

        public string ComponentDefinitionKey { get; set; }
        public ComponentDefinition ComponentDefinition { get; set; }

        public int PageId { get; set; }
        public Page Page { get; set; }


        public Component()
        {

        }

        public Component(string key)
        { 
            ComponentDefinitionKey = key;
        }
    }
}

