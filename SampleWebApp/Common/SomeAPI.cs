using Hammock;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApp.Common
{
    static public class SomeAPI
    {
        static public IList<Book> GetList()
        {
            RestClient client = new RestClient
            {
                Authority = "http://openlibrary.org",
            };

            RestRequest request = new RestRequest
            {
                Path = "authors/OL1A/works.json"
            };

            RestResponse response = client.Request(request);
            var books = JObject.Parse(response.Content);

            IList<Book> bookList = books["entries"].Select(b => new Book
            {
                title = (string)b["title"],
                key = (string)b["key"]
            }).ToList();

            return bookList;
        }

    }
}