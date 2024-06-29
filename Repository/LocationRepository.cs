using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class LocationRepository
{
    private readonly AppDbContext _context;

    public LocationRepository(AppDbContext context)
    {
        _context = context;
    }
    public List<Location> FindAll()
    {
        return _context._location?.ToList()?? new List<Location>();
    }

    public void Add(Location location)
    {
        if (location == null)
        {
            throw new ArgumentNullException(nameof(location));
        }

        _context._location.Add(location);
        _context.SaveChanges();
    }

    public void Update(Location  location)
    {
        if (location == null)
        {
            throw new ArgumentNullException(nameof(location));
        }

        _context._location.Update(location);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var locationToDelete = _context._location.Find(id);
        if (locationToDelete != null)
        {
            _context._location.Remove(locationToDelete);
            _context.SaveChanges();
        }
    }
}