using System;
using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models
{
    public class ContactModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string WebSite { get; set; }

        [Required]
        public string Comment { get; set; }

        public string ConstructEmail()
        {
            return string.Format("Comment From:{1}{0}Email:{2}{0}Subject:{3}{0}Message:{4}{0}",
                Environment.NewLine,
                this.Name,
                this.Email,
                this.WebSite,
                this.Comment);
        }
    }
}