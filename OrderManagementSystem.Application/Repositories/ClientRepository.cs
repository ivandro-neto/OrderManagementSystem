using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Exceptions;
using OrderManagementSystem.Infrastructure;
using OrderManagementSystem.Infrastructure.Entities;

namespace OrderManagementSystem.Application.Repositories;

public interface IClientRepository
{
    Task AddClientAsync(Client client);
    Task<Client> GetClientByIdAsync(Guid id);
    Task<List<Client>> GetClients();
}

public class ClientRepository : IClientRepository
{
    private OrderManagementSystemContext _context;

    public ClientRepository(OrderManagementSystemContext context)
    {
        _context = context;
    }

    public async Task AddClientAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
    }

    public async Task<Client> GetClientByIdAsync(Guid id)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(client => client.Id == id);

        if (client is null)
        {
            throw new NotFoundException("Client not found.");

        }

        return client;
    }

    public async Task<List<Client>> GetClients()
    {
        return await _context.Clients.ToListAsync();
    }
}