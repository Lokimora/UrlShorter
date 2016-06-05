﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UrlShorter.Models.DB;
using UrlShorter.Repository;

namespace UrlShorter.Controllers
{
    [AllowAnonymous]
    public class ReducerController : ApiController
    {
        private readonly IReducerRepository _reducerRepository;

        public ReducerController(IReducerRepository reducerRepository)
        {
            _reducerRepository = reducerRepository;
        }

        [HttpPost]
        public IHttpActionResult Create(string url)
        {
            Uri uriResult;
            if( Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
            {
                return Ok(_reducerRepository.Create(url));
            }

            return BadRequest("url is invalid");                     

        }

        [HttpGet]
        public IEnumerable<Reduction> GetAll()
        {
            return _reducerRepository.GetAll();
        }
       
    }
}