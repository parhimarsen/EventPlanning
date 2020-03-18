using System;
using System.Collections.Generic;

namespace EventPlanning.Models
{
    public class EventViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DateTime { get; set; }

        public Guid UserId { get; set; }

        public UserViewModel User { get; set; }

        public IEnumerable<FieldViewModel> Fields { get; set; }
    }
}