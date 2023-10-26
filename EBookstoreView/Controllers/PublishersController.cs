using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper.Execution;
using BussinessObjects;
using EBookstoreView.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Reflection.Metadata.BlobBuilder;

namespace EBookstoreView.Controllers
{
    public class PublishersController : Controller
    {
        private readonly string PublisherApiUrl = "";
        private readonly HttpClient client = null;

        public PublishersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            PublisherApiUrl = "https://localhost:7000/api/Publishers";
        }

        // GET: Publishers
        public async Task<IActionResult> Index()
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (string.IsNullOrEmpty(Role))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }

            var response = await client.GetFromJsonAsync<List<Publisher>>(PublisherApiUrl);

            return View(response);
        }

        // GET: Publishers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (string.IsNullOrEmpty(Role))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }
            var response = await client.GetFromJsonAsync<Publisher>($"{PublisherApiUrl}/{id}");

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Publishers/Create
        public async Task<IActionResult> Create()
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (!Role.Equals("admin"))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {

                HttpResponseMessage response = await client.PostAsJsonAsync($"{PublisherApiUrl}", publisher);

                if (response.StatusCode.Equals(HttpStatusCode.Created))
                {
                    return RedirectToAction(nameof(Index));
                }

                if (response.StatusCode.Equals(HttpStatusCode.InternalServerError))
                {
                    ViewData["GeneralValidationError"] = "Error when create author";
                }
            }
            return await Create();
        }

        // GET: Publishers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (!Role.Equals("admin"))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }
            var publisher = await client.GetFromJsonAsync<Publisher>($"{PublisherApiUrl}/{id}");
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PublisherName,City,State,Country")] Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync($"{PublisherApiUrl}/{id}", publisher);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Publishers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (!Role.Equals("admin"))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }

            var publisher = await client.GetFromJsonAsync<Publisher>($"{PublisherApiUrl}/{id}");
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisher = await client.GetFromJsonAsync<Publisher>($"{PublisherApiUrl}/{id}");
            if (publisher != null)
            {
                HttpResponseMessage response = await client.DeleteAsync($"{PublisherApiUrl}/{id}");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
