using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class ClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }
    public List<Client> FindAll()
    {
        return _context._client?.ToList()?? new List<Client>();
    }

    public void Add(Client client)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        _context._client.Add(client);
        _context.SaveChanges();
    }

    public void Update(Client  client)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        _context._client.Update(client);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var clientToDelete = _context._client.Find(id);
        if (clientToDelete != null)
        {
            _context._client.Remove(clientToDelete);
            _context.SaveChanges();
        }
    }
}