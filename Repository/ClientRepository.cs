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
    public String VerificationLoginClient(string email){
        var client = _context._client.FirstOrDefault(m => m.Email == email);
        if (client == null) {throw new ArgumentException("verifier votre mail !!");}
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
        return client.Id;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
    }
}