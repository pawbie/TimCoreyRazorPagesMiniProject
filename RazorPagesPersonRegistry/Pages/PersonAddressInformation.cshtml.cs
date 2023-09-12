using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonRegistryLibrary.Interfaces;
using PersonRegistryLibrary.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RazorPagesPersonRegistry.Pages
{
    public class PersonAddressInformationModel : PageModel
    {
        readonly IDataAccess<PersonModel> _personSessionStorage;
        readonly IDataAccess<AddressModel> _addressSessionStorage;

        public PersonAddressInformationModel(IDataAccess<PersonModel> personSessionStorage, IDataAccess<AddressModel> addressSessionStorage)
        {
            _personSessionStorage = personSessionStorage;
            _addressSessionStorage = addressSessionStorage;
        }

        [BindProperty]
        public PersonModel Person { get; set; }

        [BindProperty]
        public List<AddressModel> Addresses { get; set; } = new List<AddressModel>();

        [BindProperty]
        public string City { get; set; }

        [BindProperty]
        public string Street { get; set; }

        [BindProperty]
        public string PostalCode { get; set; }

        public void OnGet()
        {
        }

        public void OnGetPersonDetails(string firstName, string lastName, int age, int? id = null)
        {
            Person = new PersonModel { FirstName = firstName, LastName = lastName, Age = age, Id = id };
            if (Person.Id != null)
            {
                Addresses = _addressSessionStorage.GetAll().Where(x => x.PersonId == Person.Id).ToList();
            }
        }

        public void OnPostAddAddress()
        {
            Addresses.Add(new AddressModel { City = City, Street = Street, PostalCode = PostalCode });
        }

        public IActionResult OnPostAddPerson()
        {
            _personSessionStorage.Add(Person);

            foreach (var address in Addresses)
            {
                address.PersonId = Person.Id;
                _addressSessionStorage.Add(address);
            }

            Addresses = _addressSessionStorage.GetAll().ToList();
            return RedirectToPage("PersonList");
        }
    }
}
