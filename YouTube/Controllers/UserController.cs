﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Data.Data;
using Core.Dtos;
using Data.Entities;
using YouTube.Extensions;

namespace YouTube.Controllers
{
    public class UserController : Controller
    {
        private YouTubeDbContext ctx = new YouTubeDbContext();
        private readonly IMapper mapper;

        public UserController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var ids = HttpContext.Session.Get<List<int>>("UserId") ?? new List<int>();

            var user = ctx.Users.Where(x => ids.Contains(x.Id));
            if (user != null) return View(mapper.Map<UserDto>(user.ToList()[0]));
            else return RedirectToAction("SignIn");
        }
        public IActionResult Subscriptions()
        {
            var users = ctx.Users.ToList();

            return View(mapper.Map<List<UserDto>>(users));
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            var users = ctx.Users.ToList();
            ViewData["Users"] = mapper.Map<List<UserDto>>(users);
            ViewBag.CreateMode = true;
            return View("Upsert");
        }

        [HttpPost]
        public IActionResult SignUp(UserDto model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = true;
                return View("Upsert", model);
            }

            ctx.Users.Add(mapper.Map<User>(model));
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var users = ctx.Users.ToList();
            return View(mapper.Map<List<UserDto>>(users));
        }

        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            var user = ctx.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                var ids = new List<int> { user.Id };

                HttpContext.Session.Set("UserId", ids);
                return RedirectToAction("Index");
            }
            else
            {
                var users = ctx.Users.ToList();
                return View(mapper.Map<List<UserDto>>(users));
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = ctx.Users.Find(id);

            if (user == null) return NotFound();

            ViewBag.CreateMode = false;
            return View("Upsert", mapper.Map<UserDto>(user));
        }

        [HttpPost]
        public IActionResult Edit(UserDto model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = false;
                return View("Upsert", model);
            }

            ctx.Users.Update(mapper.Map<User>(model));
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = ctx.Users.Find(id);

            if (user == null) return NotFound();

            ctx.Users.Remove(mapper.Map<User>(user));
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
