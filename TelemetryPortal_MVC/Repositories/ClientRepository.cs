using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TelemetryPortal_MVC.Data;
using TelemetryPortal_MVC.Models;

public class ClientRepository : IClientRepository
{
    private readonly TechtrendsContext _context;

    public ClientRepository(TechtrendsContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> GetClientByIdAsync(Guid id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task AddClientAsync(Client client)
    {
        client.ClientId = Guid.NewGuid();
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateClientAsync(Client client)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteClientAsync(Guid id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }

    public bool ClientExists(Guid id)
    {
        return _context.Clients.Any(e => e.ClientId == id);
    }
}
