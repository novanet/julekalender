using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChristmasCalendar.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string DateOfBirth { get; set; }

        [MaxLength(300)]
        public string EmailAddressFromAuthProvider { get; set; }
    }
}
