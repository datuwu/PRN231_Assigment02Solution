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
    public class BooksController : Controller
    {
        private readonly string BookApiUrl = "";
        private readonly string PublisherApiUrl = "";
        private readonly HttpClient client = null;

        public BooksController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BookApiUrl = "https://localhost:7000/api/Books";
            PublisherApiUrl = "https://localhost:7000/api/Publishers";
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (string.IsNullOrEmpty(Role))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }

            var response = await client.GetFromJsonAsync<List<Book>>($"{BookApiUrl}?$expand=Publisher,BookAuthors");

            return View(response);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (string.IsNullOrEmpty(Role))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }
            var response = await client.GetFromJsonAsync<Book>($"{BookApiUrl}/{id}");

            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (!Role.Equals("admin"))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }
            var publishers = await client.GetFromJsonAsync<List<Publisher>>(PublisherApiUrl);
            ViewData["PublisherId"] = new SelectList(publishers, "Id", "PublisherName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {

                HttpResponseMessage response = await client.PostAsJsonAsync($"{BookApiUrl}", book);

                if (response.StatusCode.Equals(HttpStatusCode.Created))
                {
                    return RedirectToAction(nameof(Index));
                }

                if (response.StatusCode.Equals(HttpStatusCode.InternalServerError))
                {
                    ViewData["GeneralValidationError"] = "Error when create book";
                }
            }
            return await Create();
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (!Role.Equals("admin"))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }
            var book = await client.GetFromJsonAsync<Book>($"{BookApiUrl}/{id}");
            if (book == null)
            {
                return NotFound();
            }
            var publishers = await client.GetFromJsonAsync<List<Publisher>>(PublisherApiUrl);
            ViewData["PublisherId"] = new SelectList(publishers, "Id", "PublisherName");
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Type,PublisherId,Price,Advance,Royalty,YTDSales,Note,PublishedDate")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    HttpResponseMessage response = await client.PutAsJsonAsync($"{BookApiUrl}/{id}", book);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var Role = HttpContext.Session.GetString("role");
            var LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (!Role.Equals("admin"))
            {
                HttpContext.Session.SetString("LoginFailed", "You are not authorized");

                return Redirect("/Home/Index");
            }

            var book = await client.GetFromJsonAsync<Book>($"{BookApiUrl}/{id}");
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await client.GetFromJsonAsync<Book>($"{BookApiUrl}/{id}");
            if (book != null)
            {
                HttpResponseMessage response = await client.DeleteAsync($"{BookApiUrl}/{id}");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
