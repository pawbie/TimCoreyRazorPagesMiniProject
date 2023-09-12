using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonRegistryLibrary.Interfaces;
using PersonRegistryLibrary.Models;
using System.Collections.ObjectModel;

namespace RazorPagesPersonRegistry.Pages
{
    public class PersonGeneralInformationModel : PageModel
    {
        readonly IDataAccess<PersonModel> _personSessionStorage;
        private ReadOnlyCollection<PersonModel> _persons;

        readonly IDataAccess<AddressModel> _addressSessionStorage;
        private ReadOnlyCollection<AddressModel> _addresses;

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        [BindProperty]
        public int Age { get; set; }

        [BindProperty]
        public int? Id { get; set; }

        public void OnGet()
        {
        }

        public void OnGetEditPerson(string firstName, string lastName, int age, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Id = id;
        }

        public IActionResult OnPost()
        {
            if (Id == null)
            {
                return RedirectToPage("PersonAddressInformation", "PersonDetails", new { firstName = FirstName, lastName = LastName, age = Age});
            }
            else
            {
                return RedirectToPage("PersonAddressInformation", "PersonDetails", new { firstName = FirstName, lastName = LastName, age = Age, id = Id});
            }
            
        }
    }
}
