using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListGenerator.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
