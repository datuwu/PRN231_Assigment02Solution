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
    public class AuthorsController : Controller
    {
        private readonly string AuthorApiUrl = "";
        private readonly HttpClient client = null;

        public AuthorsController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AuthorApiUrl = "https://localhost:7000/api/Authors";
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (string.IsNullOrEmpty(Role))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }

            var response = await client.GetFromJsonAsync<List<Author>>(AuthorApiUrl);

            return View(response);
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (string.IsNullOrEmpty(Role))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }
            var response = await client.GetFromJsonAsync<Publisher>($"{AuthorApiUrl}/{id}");

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Authors/Create
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

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {

                HttpResponseMessage response = await client.PostAsJsonAsync($"{AuthorApiUrl}", author);

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

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (Role == null || !Role.Equals("admin"))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }
            var author = await client.GetFromJsonAsync<Author>($"{AuthorApiUrl}/{id}");
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Phone,Email,Address,City,State,Zip")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync($"{AuthorApiUrl}/{id}", author);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (!Role.Equals("admin"))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }

            var author = await client.GetFromJsonAsync<Author>($"{AuthorApiUrl}/{id}");
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await client.GetFromJsonAsync<Author>($"{AuthorApiUrl}/{id}");
            if (author != null)
            {
                HttpResponseMessage response = await client.DeleteAsync($"{AuthorApiUrl}/{id}");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
