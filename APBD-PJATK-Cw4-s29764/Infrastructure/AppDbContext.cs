using APBD_PJATK_Cw4_s29764.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_PJATK_Cw4_s29764.Infrastructure;

public class AppDbContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<Component> Components { get; set; }
    public DbSet<Pc> Pcs { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<PcComponent> PcComponents { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Component>(opt =>
        {
            opt.ToTable("Components");
            opt.HasKey(x => x.Code);

            opt.Property(x => x.Code).HasColumnType("char(10)");
            opt.Property(x => x.Name).HasMaxLength(300);

            opt.HasOne(x => x.ComponentManufacturer).WithMany(x => x.Components).HasForeignKey(x => x.ComponentManufacturersId);
            opt.HasOne(x => x.ComponentType).WithMany(x => x.Components).HasForeignKey(x => x.ComponentTypesId);
        });

        
        modelBuilder.Entity<ComponentManufacturer>(opt =>
        {
            opt.ToTable("ComponentManufacturers");
            opt.HasKey(x => x.Id);
            
            opt.Property(x => x.Abbreviation).HasMaxLength(30);
            opt.Property(x => x.FullName).HasMaxLength(300);
            opt.Property(x => x.FoundationDate).HasColumnType("date");
        });

        
        modelBuilder.Entity<ComponentType>(opt =>
        {
            opt.ToTable("ComponentTypes");
            opt.HasKey(x => x.Id);
            
            opt.Property(x => x.Abbreviation).HasMaxLength(30);
            opt.Property(x => x.Name).HasMaxLength(150);
        });

        
        modelBuilder.Entity<Pc>(opt =>
        {
            opt.ToTable("PCs");
            opt.HasKey(x => x.Id);
            
            opt.Property(x => x.Name).HasMaxLength(50);
            opt.Property(x => x.Weight).HasColumnType("float(5)");
            opt.Property(x => x.CreatedAt).HasColumnType("datetime");
        });

        
        //przykładowe dane
        modelBuilder.Entity<PcComponent>(opt =>
        {
            opt.ToTable("PcComponents");
            opt.HasKey(x => new {x.PcId, x.ComponentCode});
            
            opt.Property(x => x.ComponentCode).HasColumnType("char(10)");
            
            opt.HasOne(x => x.Pc).WithMany(x => x.PcComponents).HasForeignKey(x => x.PcId);
            opt.HasOne(x => x.Component).WithMany(x => x.PcComponents).HasForeignKey(x => x.ComponentCode);
        });


        modelBuilder.Entity<ComponentType>().HasData([
            new ComponentType { Id = 1, Abbreviation = "CPU",  Name = "Procesor" },
            new ComponentType { Id = 2, Abbreviation = "GPU",  Name = "Karta graficzna" },
            new ComponentType { Id = 3, Abbreviation = "RAM",  Name = "Pamięć RAM" },
            new ComponentType { Id = 4, Abbreviation = "SSD",  Name = "Dysk SSD" },
            new ComponentType { Id = 5, Abbreviation = "MB",   Name = "Płyta główna" }
        ]);
        
        modelBuilder.Entity<ComponentManufacturer>().HasData([
            new ComponentManufacturer 
            { 
                Id = 1, 
                Abbreviation = "INTEL", 
                FullName = "Intel Corporation", 
                FoundationDate = new DateOnly(1968, 7, 18) 
            },
            new ComponentManufacturer 
            { 
                Id = 2, 
                Abbreviation = "AMD", 
                FullName = "Advanced Micro Devices", 
                FoundationDate = new DateOnly(1969, 5, 1) 
            },
            new ComponentManufacturer 
            { 
                Id = 3, 
                Abbreviation = "NVIDIA", 
                FullName = "NVIDIA Corporation", 
                FoundationDate = new DateOnly(1993, 4, 5) 
            },
            new ComponentManufacturer 
            { 
                Id = 4, 
                Abbreviation = "SAMSUNG", 
                FullName = "Samsung Electronics", 
                FoundationDate = new DateOnly(1969, 1, 13) 
            }
        ]);
        
        modelBuilder.Entity<Component>().HasData([
            new Component 
            { 
                Code = "I5-12400", 
                Name = "Intel Core i5-12400", 
                Description = "6 rdzeni, 12 wątków, do 4.4 GHz, 18MB cache", 
                ComponentManufacturersId = 1, 
                ComponentTypesId = 1 
            },
            new Component 
            { 
                Code = "RTX4070", 
                Name = "NVIDIA GeForce RTX 4070", 
                Description = "12GB GDDR6X, 5888 CUDA cores", 
                ComponentManufacturersId = 3, 
                ComponentTypesId = 2 
            },
            new Component 
            { 
                Code = "DDR4-32", 
                Name = "Kingston Fury Beast 32GB (2x16GB) DDR4-3200", 
                Description = "CL16, 1.35V", 
                ComponentManufacturersId = 4, 
                ComponentTypesId = 3 
            },
            new Component 
            { 
                Code = "SSD-1TB", 
                Name = "Samsung 990 PRO 1TB", 
                Description = "NVMe PCIe 4.0, do 7450 MB/s", 
                ComponentManufacturersId = 4, 
                ComponentTypesId = 4 
            },
            new Component 
            { 
                Code = "B760-A", 
                Name = "ASUS Prime B760-PLUS", 
                Description = "Socket LGA 1700, DDR5, PCIe 5.0", 
                ComponentManufacturersId = 1, 
                ComponentTypesId = 5 
            }
        ]);
        
        modelBuilder.Entity<Pc>().HasData([
            new Pc 
            { 
                Id = 1, 
                Name = "Gaming Beast", 
                Weight = 14.8f, 
                Warranty = 36, 
                CreatedAt = new DateTime(new DateOnly(2025, 3, 15), new TimeOnly(15,20,30)), 
                Stock = 8 
            },
            new Pc 
            { 
                Id = 2, 
                Name = "Office Pro", 
                Weight = 9.2f, 
                Warranty = 24, 
                CreatedAt = new DateTime(new DateOnly(2025, 4, 20), new TimeOnly(10,15,10)), 
                Stock = 15 
            },
            new Pc 
            { 
                Id = 3, 
                Name = "Creator Ultra", 
                Weight = 16.5f, 
                Warranty = 36, 
                CreatedAt = new DateTime(new DateOnly(2025, 5, 10),  new TimeOnly(14,55,44)), 
                Stock = 5 
            }
        ]);
        
        modelBuilder.Entity<PcComponent>().HasData([
            new PcComponent { PcId = 1, ComponentCode = "I5-12400", Amount = 1 },
            new PcComponent { PcId = 1, ComponentCode = "RTX4070", Amount = 1 },
            new PcComponent { PcId = 1, ComponentCode = "DDR4-32",  Amount = 2 },
            new PcComponent { PcId = 1, ComponentCode = "SSD-1TB",   Amount = 1 },
            new PcComponent { PcId = 1, ComponentCode = "B760-A",   Amount = 1 },
            
            new PcComponent { PcId = 2, ComponentCode = "I5-12400", Amount = 1 },
            new PcComponent { PcId = 2, ComponentCode = "DDR4-32",  Amount = 1 },
            new PcComponent { PcId = 2, ComponentCode = "SSD-1TB",  Amount = 1 },
            new PcComponent { PcId = 2, ComponentCode = "B760-A",   Amount = 1 },

            new PcComponent { PcId = 3, ComponentCode = "RTX4070", Amount = 1 },
            new PcComponent { PcId = 3, ComponentCode = "DDR4-32", Amount = 2 },
            new PcComponent { PcId = 3, ComponentCode = "SSD-1TB", Amount = 2 },
            new PcComponent { PcId = 3, ComponentCode = "B760-A",  Amount = 1 }
        ]);
    }
}