using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class ProprietaireRepository
{
    private readonly AppDbContext _context;

    public ProprietaireRepository(AppDbContext context)
    {
        _context = context;
    }
    public List<Proprietaire> FindAll()
    {
        return _context._proprietaire?.ToList()?? new List<Proprietaire>();
    }

    public void Add(Proprietaire proprietaire)
    {
        if (proprietaire == null)
        {
            throw new ArgumentNullException(nameof(proprietaire));
        }

        _context._proprietaire.Add(proprietaire);
        _context.SaveChanges();
    }

    public void Update(Proprietaire  proprietaire)
    {
        if (proprietaire == null)
        {
            throw new ArgumentNullException(nameof(proprietaire));
        }

        _context._proprietaire.Update(proprietaire);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var proprietaireToDelete = _context._proprietaire.Find(id);
        if (proprietaireToDelete != null)
        {
            _context._proprietaire.Remove(proprietaireToDelete);
            _context.SaveChanges();
        }
    }

    public String VerificationLoginProprietaire(string numero){
        var proprietaire = _context._proprietaire.FirstOrDefault(m => m.Tel == numero);
        if (proprietaire == null) {throw new ArgumentException("verifier votre numero !!");}
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
        return proprietaire.Id;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
    }
}