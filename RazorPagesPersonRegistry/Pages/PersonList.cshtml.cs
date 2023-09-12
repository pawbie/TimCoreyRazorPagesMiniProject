using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonRegistryLibrary.Interfaces;
using PersonRegistryLibrary.Models;
using PersonRegistryLibrary.Services;
using System.Collections.ObjectModel;

namespace RazorPagesPersonRegistry.Pages
{
    public class PersonListModel : PageModel
    {
        readonly IDataAccess<PersonModel> _personSessionStorage;
        private ReadOnlyCollection<PersonModel> _persons;

        public PersonListModel(IDataAccess<PersonModel> personSessionStorage)
        {
            _personSessionStorage = personSessionStorage;
        }

        public ReadOnlyCollection<PersonModel> Persons => _persons;

        public void OnGet()
        {
            _persons = _personSessionStorage.GetAll();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("PersonGeneralInformation");
        }



    }
}
