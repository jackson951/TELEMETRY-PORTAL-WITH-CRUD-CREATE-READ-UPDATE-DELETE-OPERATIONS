using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TelemetryPortal_MVC.Models;

public partial class Project
{
    [DisplayName("Project ID")]
    public Guid ProjectId { get; set; }

    [DisplayName("Project Name")]
    public string? ProjectName { get; set; }

    [DisplayName("Project Description")]
    public string? ProjectDescription { get; set; }

    [DisplayName("Project Creation Date")]
    public DateTime? ProjectCreationDate { get; set; }

    [DisplayName("Project Status")]
    public string? ProjectStatus { get; set; }

    [DisplayName("Client ID")]
    public Guid? ClientId { get; set; }
}
