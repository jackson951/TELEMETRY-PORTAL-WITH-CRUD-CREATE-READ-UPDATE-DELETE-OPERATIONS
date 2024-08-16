using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TelemetryPortal_MVC.Models;

public partial class Client
{
    [DisplayName("Client ID")]
    public Guid ClientId { get; set; }

    [DisplayName("Client Name")] 
    public string? ClientName { get; set; }

    [DisplayName("Primary Contact Email")]
    [EmailAddress]
    public string? PrimaryContactEmail { get; set; }

    [DisplayName("Date Onboarded")]
    public DateTime? DateOnboarded { get; set; }
}
