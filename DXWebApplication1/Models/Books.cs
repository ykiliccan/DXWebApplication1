using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models
{
    public static class Books
    {
        public static List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book { Id = 1, Name = "INSTANT_NODEJS_STARTER", ISBN = "9781782165569" });
            books.Add(new Book { Id = 2, Name = "BURP_SUITE_ESSENTIALS", ISBN= "9781783550111" });
            books.Add(new Book { Id = 3, Name = "POSTGRESQL_90_HIGH_PERFORMANCE", ISBN = "9781849510301" });

            return books;
        }
    }
}