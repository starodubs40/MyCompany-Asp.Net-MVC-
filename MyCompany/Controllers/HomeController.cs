using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Controllers
{
    public class HomeController : Controller
    {
        //private readonly DataManager dataManager;

        private readonly ITextFieldsRepository textFieldsRepository;

        public HomeController(ITextFieldsRepository textFieldsRepository)
        {
            this.textFieldsRepository = textFieldsRepository;
        }

        
        public IActionResult Index()
        {
            return View(textFieldsRepository.GetTextFieldByCodeWord("PageIndex"));
        }

      
        public IActionResult Contacts()
        {
            return View(textFieldsRepository.GetTextFieldByCodeWord("PageContacts"));
        }


        public IActionResult SignIn()
        {
            return View();
        }
    }
}