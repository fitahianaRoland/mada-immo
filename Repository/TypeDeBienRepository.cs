using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class TypeDeBienRepository
{
    private readonly AppDbContext _context;

    public TypeDeBienRepository(AppDbContext context)
    {
        _context = context;
    }
    public List<TypeDeBien> FindAll()
    {
        return _context._type_de_bien?.ToList()?? new List<TypeDeBien>();
    }

    public void Add(TypeDeBien type_de_bien)
    {
        if (type_de_bien == null)
        {
            throw new ArgumentNullException(nameof(type_de_bien));
        }

        _context._type_de_bien.Add(type_de_bien);
        _context.SaveChanges();
    }

    public void Update(TypeDeBien  type_de_bien)
    {
        if (type_de_bien == null)
        {
            throw new ArgumentNullException(nameof(type_de_bien));
        }

        _context._type_de_bien.Update(type_de_bien);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var type_de_bienToDelete = _context._type_de_bien.Find(id);
        if (type_de_bienToDelete != null)
        {
            _context._type_de_bien.Remove(type_de_bienToDelete);
            _context.SaveChanges();
        }
    }
}