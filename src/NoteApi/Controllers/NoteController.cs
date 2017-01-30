using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NoteApi.Models;

namespace NoteApi.Controllers
{
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        private readonly IServiceProvider _service;

        public NoteController(IServiceProvider service)
        {
            _service = service;
        }

        // GET api/notes
        [HttpGet]
        public IEnumerable<Note> Get()
        {
            using (var context = _service.GetService<MyContext>())
            {
                return context.Notes.OrderByDescending(x=>x.CreateDate).Take(100).ToList();
            }
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/note
        [HttpPost]
        public void Post([FromBody]Note note)
        {
            if (note == null)
            {
                return;
            }
            using (var context = _service.GetService<MyContext>())
            {
                context.Notes.Add(note);
                context.SaveChanges();
            }
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
