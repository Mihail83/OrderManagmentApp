using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using OrderManagmentApp.Infrastructure.Constatnts;
using Microsoft.AspNetCore.Identity;

namespace OrderManagmentApp.WEB.Models
{
    public class CreateUserViewModel
    {
        public CreateUserViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }

        [Required(ErrorMessage =Messages.NeedName)]
        public string Name { get; set; }
        [Required(ErrorMessage = Messages.NeedPassword)]
        public string Password { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }




    }
}
