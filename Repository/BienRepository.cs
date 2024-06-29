using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class BienRepository
{
    private readonly AppDbContext _context;

    public BienRepository(AppDbContext context)
    {
        _context = context;
    }
    public List<Bien> FindAll()
    {
        return _context._bien?.ToList()?? new List<Bien>();
    }

    public void Add(Bien bien)
    {
        if (bien == null)
        {
            throw new ArgumentNullException(nameof(bien));
        }

        _context._bien.Add(bien);
        _context.SaveChanges();
    }

    public void Update(Bien  bien)
    {
        if (bien == null)
        {
            throw new ArgumentNullException(nameof(bien));
        }

        _context._bien.Update(bien);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var bienToDelete = _context._bien.Find(id);
        if (bienToDelete != null)
        {
            _context._bien.Remove(bienToDelete);
            _context.SaveChanges();
        }
    }
}