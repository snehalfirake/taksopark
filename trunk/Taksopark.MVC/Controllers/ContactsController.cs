using System;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using Taksopark.MVC.Models;

namespace Taksopark.MVC.Controllers
{
    public class ContactsController : Controller
    {
        public ActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMail(Contact form)
        {
            string retValue = "There was an error submitting the form, please try again later.";
            if (!ModelState.IsValid)
            {
                return Content(retValue);
            }

            if (ModelState.IsValid)
            {
                using (var client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    //Credentials = new NetworkCredential("komaniakvitalik@gmail.com", "3411902474"),
                    Credentials = CredentialCache.DefaultNetworkCredentials,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                })
                {
                    var mail = new MailMessage();
                    mail.To.Add("komaniakvitalik@ukr.net");
                    mail.From = new MailAddress(form.Email, form.Name);
                    mail.Subject = String.Format("Request to Contact from {0}", form.Name);
                    mail.Body = form.Message;

                    try
                    {
                        client.Send(mail);
                        retValue = "Your Request for Contact was submitted successfully. We will contact you shortly.";
                    }
                    catch (ArgumentNullException) { throw; }
                    catch (ObjectDisposedException) { throw; }
                    catch (InvalidOperationException) { throw; }
                    catch (SmtpFailedRecipientsException) { throw; }
                    catch (SmtpException) { throw; }
                    catch (Exception) { throw; }
                }

            }
            return Content(retValue);
        }
    }
}