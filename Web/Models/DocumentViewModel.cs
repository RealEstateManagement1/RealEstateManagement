using System;
using Microsoft.AspNetCore.Components.Forms;

namespace Web.Models
{
    public class DocumentViewModel
    {
        public Guid? LandTitleId { get; set; }
        public string Description { get; set; } = string.Empty;
        // Use IBrowserFile to receive uploads from Blazor forms
        public IBrowserFile? File { get; set; }
    }
}
