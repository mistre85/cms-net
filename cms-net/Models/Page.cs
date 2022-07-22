using System;
namespace cms_net.Models
{
    public class Page
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Component>? components { get; set; }

        public Page()
        {
        }

        public Page(string title)
        {
            Title = title;
        }
    }
}

