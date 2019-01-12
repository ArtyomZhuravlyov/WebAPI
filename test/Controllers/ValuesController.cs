using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using test.Models;

namespace test.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Request req)
        {
            if (req == null || req.AppToken == "" || req.UserKey == "" || req.Message == "") return "Вы заполнены не все поля";
            
                var parameters = new NameValueCollection {
             { "token", req.AppToken },
             { "user", req.UserKey },
             { "message", req.Message }
             };
            try
            { 
                 using (var client = new WebClient())
                 {
                    client.UploadValues("https://api.pushover.net/1/messages.json", parameters);
                 }
                return "успешно";
            }
            catch 
            {
                return "неправильно введены данные";
            }


        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
