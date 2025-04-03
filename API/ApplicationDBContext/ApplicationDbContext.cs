using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.ApplicationDBContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<FarmerRating> FarmerRatings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Agency> Agencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OF88FCU;database=dbFarm;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                base.OnModelCreating(modelBuilder);

                // User <-> Agent relationship
                modelBuilder.Entity<User>()
                    .HasOne(u => u.Agent)
                    .WithOne(a => a.User)
                    .HasForeignKey<Agent>(a => a.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                // User <-> Farmer relationship
                modelBuilder.Entity<User>()
                    .HasOne(u => u.Farmer)
                    .WithOne(f => f.User)
                    .HasForeignKey<Farmer>(f => f.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Farmer <-> Agent relationship
                modelBuilder.Entity<Farmer>()
                    .HasOne(f => f.Agent)
                    .WithMany(a => a.Farmers)
                    .HasForeignKey(f => f.AgentId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Farmer <-> Animal relationship
                modelBuilder.Entity<Animal>()
                    .HasOne(a => a.Farmer)
                    .WithMany(f => f.Animals)
                    .HasForeignKey(a => a.FarmerId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Farmer <-> Land relationship
                modelBuilder.Entity<Land>()
                    .HasOne(l => l.Farmer)
                    .WithMany(f => f.Lands)
                    .HasForeignKey(l => l.FarmerId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Farmer <-> FarmerRating relationship
                modelBuilder.Entity<FarmerRating>()
                    .HasOne(fr => fr.Farmer)
                    .WithMany(f => f.FarmersRatings)
                    .HasForeignKey(fr => fr.FarmerId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Agent <-> Agency relationship
                modelBuilder.Entity<Agent>()
                    .HasOne(a => a.Agency)
                    .WithMany(ag => ag.Agents)
                    .HasForeignKey(a => a.AgencyId)
                    .OnDelete(DeleteBehavior.Restrict);


                // Precision settings for specific fields
                modelBuilder.Entity<Animal>().Property(a => a.Price).HasPrecision(18, 2);
                modelBuilder.Entity<Supply>().Property(s => s.Price).HasPrecision(18, 2);
                modelBuilder.Entity<Farmer>().Property(f => f.Budget).HasPrecision(18, 2);

                // Seed data for Agency
                modelBuilder.Entity<Agency>().HasData(
                    new Agency { Id = 1, Name = "AgroExperts", County = "Cluj", Location = "Cluj-Napoca" },
                    new Agency { Id = 2, Name = "FarmAssist", County = "Timiș", Location = "Timișoara" },
                    new Agency { Id = 3, Name = "EcoFarm", County = "Iași", Location = "Brasov" }
                );

                // Seed data for User
                modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Name = "Alex Johnson", Email = "alex.johnson@example.com", Password = "hashedpassword1", Role = "Agent" },
                    new User { Id = 2, Name = "Laura Smith", Email = "laura.smith@example.com", Password = "hashedpassword2", Role = "Agent" },
                    new User { Id = 3, Name = "Robert Green", Email = "robert.green@example.com", Password = "hashedpassword3", Role = "Agent" },
                    new User { Id = 4, Name = "John Doe", Email = "john.doe@example.com", Password = "hashedpassword4", Role = "Farmer" },
                    new User { Id = 5, Name = "Jane Smith", Email = "jane.smith@example.com", Password = "hashedpassword5", Role = "Farmer" },
                    new User { Id = 6, Name = "Michael Brown", Email = "michael.brown@example.com", Password = "hashedpassword6", Role = "Farmer" },
                    new User { Id = 7, Name = "Emily Davis", Email = "emily.davis@example.com", Password = "hashedpassword7", Role = "Farmer" }
                );

                // Seed data for Agent
                modelBuilder.Entity<Agent>().HasData(
                    new Agent { Id = 1, UserId = 1, Name = "Alex Johnson", AgencyId = 1 },
                    new Agent { Id = 2, UserId = 2, Name = "Laura Smith", AgencyId = 2 },
                    new Agent { Id = 3, UserId = 3, Name = "Robert Green", AgencyId = 3 }
                );

                // Seed data for Farmer
                modelBuilder.Entity<Farmer>().HasData(
                    new Farmer { Id = 1, UserId = 4, Name = "John Doe", Location = "Village A", Budget = 10000, Category = "Livestock", AgentId = 1 },
                    new Farmer { Id = 2, UserId = 5, Name = "Jane Smith", Location = "Village B", Budget = 15000, Category = "Crops", AgentId = 2 },
                    new Farmer { Id = 3, UserId = 6, Name = "Michael Brown", Location = "Village C", Budget = 20000, Category = "Dairy", AgentId = 1 },
                    new Farmer { Id = 4, UserId = 7, Name = "Emily Davis", Location = "Village D", Budget = 18000, Category = "Poultry", AgentId = 3 }
                );

                // Seed data for Land
                modelBuilder.Entity<Land>().HasData(
                    new Land { Id = 1, Location = "Field 1", Type = "Pasture", Area = 50, FarmerId = 1 },
                    new Land { Id = 2, Location = "Field 2", Type = "Corn", Area = 30, FarmerId = 2 },
                    new Land { Id = 3, Location = "Field 3", Type = "Wheat", Area = 40, FarmerId = 3 },
                    new Land { Id = 4, Location = "Field 4", Type = "Rice", Area = 60, FarmerId = 4 }
                );

                // Seed data for Animal
                modelBuilder.Entity<Animal>().HasData(
                    new Animal { Id = 1, Name = "Cow 1", Breed = "Holstein", Weight = 500, Price = 1500, FarmerId = 1 },
                    new Animal { Id = 2, Name = "Sheep 1", Breed = "Merino", Weight = 80, Price = 300, FarmerId = 2 },
                    new Animal { Id = 3, Name = "Goat 1", Breed = "Boer", Weight = 50, Price = 200, FarmerId = 2 },
                    new Animal { Id = 4, Name = "Chicken 1", Breed = "Leghorn", Weight = 2, Price = 50, FarmerId = 4 }
                );

                // Seed data for Supply
                modelBuilder.Entity<Supply>().HasData(
                    new Supply { Id = 1, Name = "Hay", Quantity = 100, Quality = "Good", Price = 500 },
                    new Supply { Id = 2, Name = "Corn Feed", Quantity = 50, Quality = "Premium", Price = 700 },
                    new Supply { Id = 3, Name = "Wheat Bran", Quantity = 80, Quality = "Standard", Price = 400 },
                    new Supply { Id = 4, Name = "Rice Husk", Quantity = 120, Quality = "High", Price = 600 }
                );

                // Seed data for FarmerRating
                modelBuilder.Entity<FarmerRating>().HasData(
                    new FarmerRating { Id = 1, FarmerId = 1, Rating = 5, Comment = "Excellent work", CreatedAt = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc) },
                    new FarmerRating { Id = 2, FarmerId = 2, Rating = 4, Comment = "Good progress", CreatedAt = new DateTime(2024, 1, 2, 14, 30, 0, DateTimeKind.Utc) },
                    new FarmerRating { Id = 3, FarmerId = 3, Rating = 3, Comment = "Needs improvement", CreatedAt = new DateTime(2024, 1, 3, 16, 45, 0, DateTimeKind.Utc) },
                    new FarmerRating { Id = 4, FarmerId = 4, Rating = 5, Comment = "Excellent produce", CreatedAt = new DateTime(2024, 1, 4, 9, 15, 0, DateTimeKind.Utc) }
                );
            }
        }
    }
}
