using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TelemetryPortal_MVC.Data;
using TelemetryPortal_MVC.Models;
using TelemetryPortal_MVC.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly TechtrendsContext _context;

    public ProjectRepository(TechtrendsContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Project> GetProjectByIdAsync(Guid id)
    {
        return await _context.Projects.FindAsync(id);
    }

    public async Task AddProjectAsync(Project project)
    {
        project.ProjectId = Guid.NewGuid();
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProjectAsync(Project project)
    {
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProjectAsync(Guid id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project != null)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }

    public bool ProjectExists(Guid id)
    {
        return _context.Projects.Any(e => e.ProjectId == id);
    }
}
