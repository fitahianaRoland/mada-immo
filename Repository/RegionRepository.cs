using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class RegionRepository
{
    private readonly AppDbContext _context;

    public RegionRepository(AppDbContext context)
    {
        _context = context;
    }
    public List<Region> FindAll()
    {
        return _context._region?.ToList()?? new List<Region>();
    }

    public void Add(Region region)
    {
        if (region == null)
        {
            throw new ArgumentNullException(nameof(region));
        }

        _context._region.Add(region);
        _context.SaveChanges();
    }

    public void Update(Region  region)
    {
        if (region == null)
        {
            throw new ArgumentNullException(nameof(region));
        }

        _context._region.Update(region);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var regionToDelete = _context._region.Find(id);
        if (regionToDelete != null)
        {
            _context._region.Remove(regionToDelete);
            _context.SaveChanges();
        }
    }
}