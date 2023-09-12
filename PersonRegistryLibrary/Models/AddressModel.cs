using PersonRegistryLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegistryLibrary.Models
{
    public class AddressModel : IRegistryItem
    {
        public int? Id { get; set; }
        public int? PersonId { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; } 
        public string DisplayName { get => $"ID: {Id}, PersonId: {PersonId}, City: {City}, Street: {Street}, PostalCode: {PostalCode}"; }

    }
}
