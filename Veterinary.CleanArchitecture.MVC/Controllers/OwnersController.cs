using MediatR;
using Microsoft.AspNetCore.Mvc;
using Veterinary.CleanArchitecture.Application.UseCases.Owners.CreateOwner;
using Veterinary.CleanArchitecture.MVC.Models.Owner;

namespace Veterinary.CleanArchitecture.MVC.Controllers
{
    [Route("/[controller]/[action]")]
    public class OwnersController : Controller
    {
        private readonly ISender _mediatrSender;
        
        public OwnersController(ISender sender)
        {
            this._mediatrSender = sender;
        }

        [HttpGet]
        public IActionResult CreateOwner()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromForm] CreateOwnerViewModel form)
        {
            if (this.ModelState.IsValid)
            {
                var result = await this._mediatrSender.Send(new CreateOwnerCommand()
                {
                    FullName = form.FullName,
                    PhoneNumber = form.PhoneNumber,
                    AlternativePhoneNumber = form.AlternativePhoneNumber,
                    Identification = form.Identification.ToString()!,
                });

                if (result.IsSuccess)
                {
                    return RedirectToAction("IndividualOwner");    
                }
                else
                {
                    return View("Error"); 
                }
            }
            else
            {
                return View("Create");
            }
        }
    }
}

