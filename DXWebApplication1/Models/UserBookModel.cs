using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models
{
    public class UserBookModel
    {
        public List<User> listUsers { get; set; }
        public Book Book { get; set; }
    }
}