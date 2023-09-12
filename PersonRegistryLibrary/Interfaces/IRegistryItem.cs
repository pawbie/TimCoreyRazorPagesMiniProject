using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegistryLibrary.Interfaces
{
    public interface IRegistryItem
    {
        public string DisplayName { get; }
        public int? Id { get; set; }
    }
}
