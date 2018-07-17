using Contact.MvcUI.Global;
using Contact.MvcUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Contact.MvcUI.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult ContactListView(string search)

        {
            IEnumerable<ContactViewModel> contactList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Contact").Result;
            if (response.IsSuccessStatusCode)
            {
                contactList = response.Content.ReadAsAsync<IEnumerable<ContactViewModel>>().Result;

                // Filter data based on the search
                if(!string.IsNullOrEmpty(search))
                {
                  contactList = contactList.Where(s=>s.PhoneNumber==search ||
                                    String.Equals(s.FirstName,search,StringComparison.OrdinalIgnoreCase)||
                                    String.Equals(s.LastName, search, StringComparison.OrdinalIgnoreCase) || 
                                    String.Equals(s.Email, search, StringComparison.OrdinalIgnoreCase) ||
                                    String.Equals(s.Status, search, StringComparison.OrdinalIgnoreCase) );

                    if (contactList.Count()>0)
                    {
                        return View(contactList);
                    }
                    else
                    {
                        return View("SearchDataNotFound");
                    }
                  
                }
                
                return View(contactList);
            }
            return RedirectToAction("Error");

        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ContactDetail(int id)
        {
            ContactViewModel contactDetail;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Contact/"+ id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                contactDetail = response.Content.ReadAsAsync<ContactViewModel>().Result;
                return View(contactDetail);
            }
            return RedirectToAction("Error");
        }

        public ActionResult CreateOrUpdateContactInformation(int id = 0)
        {
            if (id == 0)
            {
                // return View(new ContactViewModel());
                ContactViewModel model = new ContactViewModel();
                model.Status = "ACTIVE";
                return View(model);

            }
            else
            {
                ContactViewModel model;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Contact/" + id.ToString()).Result;
               model = response.Content.ReadAsAsync<ContactViewModel>().Result;
                return View("Update", model);
            }

        }

        [HttpPost]
        public ActionResult CreateOrUpdateContactInformation(ContactViewModel contactModel)
        {
            if (contactModel.ContactId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Contact", contactModel).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Contact/" + contactModel.ContactId, contactModel).Result;
                TempData["SuccessMessage"] = "Updated  Successfully";
            }
            return RedirectToAction("ContactListView");
        }

        public ActionResult RemoveContact(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Contact/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Deleted  Successfully";
                return RedirectToAction("ContactListView");
            }
            return RedirectToAction("Error");


        }
    }
}