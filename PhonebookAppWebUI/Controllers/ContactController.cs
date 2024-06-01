using PhoneBookApp.BusinessLogicLayer;
using PhoneBookApp.BusinessObjectLayer.Common;
using PhoneBookApp.BusinessObjectLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhonebookAppWebUI.Controllers
{
    [ValidationAuthorize]
    public class ContactController : Controller
    {
        private readonly ContactBll _contactBll;
        public ContactController()
        {
            _contactBll = new ContactBll();
        }
        // GET: Contact
        public ActionResult Index()
        {
            long userId = Convert.ToInt64(Session["UserId"]);
            var contactList = _contactBll.GetAllContactsByUser(userId);
            return View(contactList);
        }
        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddContact(CreateContactDto createContactDto)
        {
            long userId = Convert.ToInt64(Session["UserId"]);
            createContactDto.UserReferenceId = userId;
            var response = _contactBll.AddContact(createContactDto);
            ViewBag.Success = response.Status;
            ViewBag.Message = response.Message;
            if (response.Status)
                return RedirectToAction("Index", "Contact");
            else
                return View("Add");
        }

        public ActionResult Edit(int Id)
        {
            long userId = Convert.ToInt64(Session["UserId"]);
            var contact = _contactBll.GetSingleContact(Id, userId);
            if (contact == null)
                return RedirectToAction("Index");
            return View(contact);
        }
        public ActionResult Delete(int Id)
        {
            long userId = Convert.ToInt64(Session["UserId"]);
            var contact = _contactBll.GetSingleContact(Id, userId);
            if (contact == null)
                return RedirectToAction("Index");
            return View(contact);
        }
        [HttpPost]
        public ActionResult DeleteConfirm(int Id)
        {
            long userId = Convert.ToInt64(Session["UserId"]);
            var contact = _contactBll.DeleteContact(Id, userId);
            ViewBag.Success = contact.Status;
            ViewBag.Message = contact.Message;
            if (!contact.Status)
                return View("Delete", new { Id = Id });
            return RedirectToAction("Index");
        }
    }
}