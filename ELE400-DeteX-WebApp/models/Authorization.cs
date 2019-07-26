using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELE400_DeteX_WebApp.models
{
    public class Authorization
    {
        public Authorization(IRestResponse response)    /* Populate types with Response.*/
        {
            this.UserId = response.Content;
        }

        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public string Token { get; set; }
    }
}
