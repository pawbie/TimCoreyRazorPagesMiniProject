using PersonRegistryLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegistryLibrary.Models
{
    public class PersonModel : IRegistryItem
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string DisplayName => $"ID: {Id}, First Name: {FirstName}, LastName: {LastName}, {Age.ToString()}";
    }
}
