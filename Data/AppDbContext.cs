using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class AppDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public AppDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public DbSet<Admin> _admin {get; set;}
 
    public DbSet<Proprietaire> _proprietaire {get; set;}
 
    public DbSet<Bien> _bien {get; set;}
 
    public DbSet<Region> _region {get; set;}
 
    public DbSet<TypeDeBien> _type_de_bien {get; set;}
 
    public DbSet<Location> _location {get; set;}
 
    public DbSet<Client> _client {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }
    // public DbSet<EtapeEquipePenalite> _etape_equipe_penalite {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // modelBuilder.Entity<ListDevisClient>().HasNoKey();
        base.OnModelCreating(modelBuilder);                
        modelBuilder.Entity<Admin>()
            .Property(p => p.Id)
            .HasDefaultValueSql($"NEXT VALUE FOR admin_seq");

        modelBuilder.Entity<Proprietaire>()
            .Property(p => p.Id)
            .HasDefaultValueSql($"NEXT VALUE FOR proprietaire_seq");

        modelBuilder.Entity<Bien>()
            .Property(p => p.Id)
            .HasDefaultValueSql($"NEXT VALUE FOR bien_seq");

        modelBuilder.Entity<Region>()
            .Property(p => p.Id)
            .HasDefaultValueSql($"NEXT VALUE FOR region_seq");

        modelBuilder.Entity<TypeDeBien>()
            .Property(p => p.Id)
            .HasDefaultValueSql($"NEXT VALUE FOR type_de_bien_seq");

        modelBuilder.Entity<Location>()
            .Property(p => p.Id)
            .HasDefaultValueSql($"NEXT VALUE FOR location_seq");

        modelBuilder.Entity<Client>()
            .Property(p => p.Id)
            .HasDefaultValueSql($"NEXT VALUE FOR client_seq");

        modelBuilder.Entity<Bien>()
            .HasOne(d => d.Proprietaire)
            .WithMany()
            .HasForeignKey(d => d.IdProprietaire);

        modelBuilder.Entity<Bien>()
            .HasOne(d => d.Region)
            .WithMany()
            .HasForeignKey(d => d.IdRegion);

        modelBuilder.Entity<Bien>()
            .HasOne(d => d.TypeDeBien)
            .WithMany()
            .HasForeignKey(d => d.IdTypeDeBien);        
        
        modelBuilder.Entity<Location>()
            .HasOne(d => d.Bien)
            .WithMany()
            .HasForeignKey(d => d.IdBien);

        modelBuilder.Entity<Location>()
            .HasOne(d => d.Client)
            .WithMany()
            .HasForeignKey(d => d.IdClient);
    }
}