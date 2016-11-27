using System.ComponentModel.DataAnnotations;

using Sitecore.Services.Core.Model;

namespace CustomService.Model
{
    public class BookEntity : EntityIdentity
    {
        [Required]
        [MinLength(2)]
        public string Title { get; set; }
    }
}