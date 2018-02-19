using System.Collections.Generic;

namespace blog.Models
{
    public class BaseViewModel
    {
        public string PageTitle { get; set; }
        public virtual IEnumerable<string> Tags { get; set; }
    }
}