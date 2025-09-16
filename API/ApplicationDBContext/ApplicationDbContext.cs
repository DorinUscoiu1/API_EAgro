using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Data;
using Newtonsoft.Json;
namespace API.ApplicationDBContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<FarmerSupply> FarmerSupplies { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<PaymentScheme> PaymentSchemes { get; set; }
        public DbSet<AnimalPaymentScheme>AnimalPaymentSchemes { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<FarmerRating> FarmerRatings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Agency> Agencies { get; set; }

        public DbSet<LandFundingRequest> LandFundingRequests {  get; set; }
        public DbSet<AnimalFundingRequest> AnimalFundingRequests { get; set; }
        public DbSet<MarketItem> MarketItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:demosql11.database.windows.net,1433;Initial Catalog=Farming;Persist Security Info=False;User ID=dorin;Password=Dori1506;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<User>()
                    .HasOne(u => u.Agent)
                    .WithOne(a => a.User)
                    .HasForeignKey<Agent>(a => a.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<User>()
                    .HasOne(u => u.Farmer)
                    .WithOne(f => f.User)
                    .HasForeignKey<Farmer>(f => f.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Farmer>()
                    .HasOne(f => f.Agent)
                    .WithMany(a => a.Farmers)
                    .HasForeignKey(f => f.AgentId)
                    .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Animal>()
                    .HasOne(a => a.Farmer)
                    .WithMany(f => f.Animals)
                    .HasForeignKey(a => a.FarmerId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Land>()
                    .HasOne(l => l.Farmer)
                    .WithMany(f => f.Lands)
                    .HasForeignKey(l => l.FarmerId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<FarmerRating>()
                    .HasOne(fr => fr.Farmer)
                    .WithMany(f => f.FarmersRatings)
                    .HasForeignKey(fr => fr.FarmerId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Agent>()
                    .HasOne(a => a.Agency)
                    .WithMany(ag => ag.Agents)
                    .HasForeignKey(a => a.AgencyId)
                    .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<FarmerSupply>()
                    .HasOne(fs => fs.Farmer)
                    .WithMany(f => f.FarmerSupplies)
                    .HasForeignKey(fs => fs.FarmerId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<FarmerSupply>()
                    .HasOne(fs => fs.Supply)
                    .WithMany(s => s.FarmerSupplies)
                    .HasForeignKey(fs => fs.SupplyId)
                    .OnDelete(DeleteBehavior.Cascade);


                modelBuilder.Entity<MarketItem>()
                     .HasOne(mi => mi.BuyerFarmer)
                     .WithMany()
                     .HasForeignKey(mi => mi.BuyerFarmerId)
                     .OnDelete(DeleteBehavior.SetNull);

                modelBuilder.Entity<Farmer>()
                    .HasOne(f => f.LandFundingRequest)
                    .WithOne(l => l.Farmer)
                    .HasForeignKey<LandFundingRequest>(l => l.FarmerId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Farmer>()
                    .HasOne(f => f.AnimalFundingRequest)
                    .WithOne(l => l.Farmer)
                    .HasForeignKey<AnimalFundingRequest>(l => l.FarmerId)
                    .OnDelete(DeleteBehavior.Cascade);

                var coordinates = new[]
                    {new { 
                        lat = 45.7416, lng = 25.1282 }, new { lat = 45.7418, lng = 25.1287 }, new { lat = 45.7415, lng = 25.1285 
                        }
                };
                var coordinatesJson = JsonConvert.SerializeObject(coordinates);

                modelBuilder.Entity<Animal>().Property(a => a.Price).HasPrecision(18, 2);
                modelBuilder.Entity<Supply>().Property(s => s.Price).HasPrecision(18, 2);
                modelBuilder.Entity<Farmer>().Property(f => f.Budget).HasPrecision(18, 2);

                modelBuilder.Entity<MarketItem>().Property(mi => mi.Price).HasPrecision(18, 2);

                modelBuilder.Entity<Agency>().HasData(
                    new Agency { Id = 1, Name = "AgroExperts", County = "Brasov", Location = "Brasov", Address = "Strada Agricultorilor nr. 10" ,Type="Judetean"},
                    new Agency { Id = 2, Name = "FarmAssist", County = "Brasov", Location = "Poiana Marului", Address = "Strada Principală nr. 45",Type="Local" },
                    new Agency { Id = 3, Name = "EcoFarm", County = "Brasov", Location = "Sercaia", Address = "Strada Morii nr. 22", Type = "Local" }, 
                    new Agency { Id = 13, Name = "Centrul Județean Brașov", County = "Brasov", Location = "Brașov",Address= "Str. Ecaterina Teodoroiu, nr. 38A", Type = "Judetean" },
                    new Agency { Id = 14, Name = "Centrul Local Poiana Mărului", County = "Brasov", Location = "Poiana Mărului",Address= "str. Laterală, nr. 224", Type = "Local" },
                    new Agency { Id = 15, Name = "Centrul Local Șercaia", County = "Brasov", Location = "Șercaia",Address = "str.Principală, nr. 82", Type = "Local" },
                    new Agency { Id = 16, Name = "Centrul Local Făgăraș", County = "Brasov", Location = "Făgăraș",Address= "str. Cetății, nr. 40" , Type = "Local" },
                    new Agency { Id = 17, Name = "Centrul Local Codlea", County = "Brasov", Location = "Codlea",Address= "str. Muntişor, nr. 1", Type = "Local" },
                    new Agency { Id = 18, Name = "Centrul Local Prejmer", County = "Brasov", Location = "Prejmer",Address= "str. Ştefan Ludwig Roth, nr. 565 A,", Type = "Local" },
                    new Agency { Id = 19, Name = "Centrul Local Rupea", County = "Brasov", Location = "Rupea",Address="str.Republicii nr. 166", Type = "Local" },
                    new Agency { Id = 22, Name = "Centrul Local Râșnov", County = "Brasov", Location = "Râșnov",Address= "str. Piața Unirii, nr. 20", Type = "Local" }
                );

                modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Name = "Alex Johnson", Email = "alex.johnson@example.com", Password = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", Role = "Agent",Phone= "0712345678" },
                    new User { Id = 2, Name = "Laura Smith", Email = "laura.smith@example.com", Password = "hashedpassword2", Role = "Agent", Phone = "0722334455" },
                    new User { Id = 3, Name = "Robert Green", Email = "robert.green@example.com", Password = "hashedpassword3", Role = "Agent", Phone = "0733445566" },
                    new User { Id = 4, Name = "John Doe", Email = "john.doe@example.com", Password = "hashedpassword4", Role = "Farmer", Phone = "0744556677" },
                    new User { Id = 5, Name = "Jane Smith", Email = "jane.smith@example.com", Password = "hashedpassword5", Role = "Farmer", Phone = "0755667788" },
                    new User { Id = 6, Name = "Michael Brown", Email = "michael.brown@example.com", Password = "hashedpassword6", Role = "Farmer", Phone = "0766778899" },
                    new User { Id = 7, Name = "Emily Davis", Email = "emily.davis@example.com", Password = "hashedpassword7", Role = "Farmer", Phone = "0777889900" },
                    new User { Id = 15, Name = "Dorin Uscoiu", Email = "dorin.uscoiu@apia.ro", Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", Role = "Admin", Phone = "0777889900" },


                    new User { Id = 37, Name = "Ion Popescu", Email = "ion.popescu@apia.ro", Password = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", Role = "Agent", Phone = "0700000001" },
                    new User { Id = 38, Name = "Maria Ionescu", Email = "maria.ionescu@apia.ro", Password = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", Role = "Agent", Phone = "0700000002" },
                    new User { Id = 39, Name = "Vasile Georgescu", Email = "vasile.georgescu@apia.ro", Password = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", Role = "Agent", Phone = "0700000003" },
                    new User { Id = 40, Name = "Elena Dumitrescu", Email = "elena.dumitrescu@apia.ro", Password = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", Role = "Agent", Phone = "0700000004" },
                    new User { Id = 41, Name = "Mihai Marin", Email = "mihai.marin@apia.ro", Password = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", Role = "Agent", Phone = "0700000005" },
                    new User { Id = 42, Name = "Ana Vasilescu", Email = "ana.vasilescu@apia.ro", Password = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", Role = "Agent", Phone = "0700000006" },
                    new User { Id = 43, Name = "Cristian Ene", Email = "cristian.ene@apia.ro", Password = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", Role = "Agent", Phone = "0700000007" },
                    new User { Id = 46, Name = "Ioana Neagu", Email = "ioana.neagu@apia.ro", Password = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", Role = "Agent", Phone = "0700000010" },
                    new User { Id = 48, Name = "Monica Florescu", Email = "monica.florescu@apia.ro", Password = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", Role = "Agent", Phone = "0700000012" },
                    new User { Id = 49, Name = "George Petrescu", Email = "george.petrescu@apia.ro", Password = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", Role = "Agent", Phone = "0700000013" },
                    new User { Id = 50, Name = "Daniela Voicu", Email = "daniela.voicu@apia.ro", Password = "d4f0bc5a29de06b510f9aa428f1eedba926012b591fef7a518e776a7c9bd1824", Role = "Agent", Phone = "0700000014" }
                );

                modelBuilder.Entity<Agent>().HasData(
                    new Agent { Id = 1, UserId = 1, Name = "Alex Johnson", Email = "alex.johnson@example.com", AgencyId = 1 },
                    new Agent { Id = 2, UserId = 2, Name = "Laura Smith", Email = "laura.smith@example.com", AgencyId = 2 },
                    new Agent { Id = 3, UserId = 3, Name = "Robert Green", Email = "robert.green@example.com", AgencyId = 3 },


                    new Agent { Id = 12, UserId = 37, Name = "Ion Popescu", Email = "ion.popescu@apia.ro", AgencyId = 13 },
                    new Agent { Id = 13, UserId = 38, Name = "Maria Ionescu", Email = "maria.ionescu@apia.ro", AgencyId = 14 },
                    new Agent { Id = 14, UserId = 39, Name = "Vasile Georgescu", Email = "vasile.georgescu@apia.ro", AgencyId = 15 },
                    new Agent { Id = 15, UserId = 40, Name = "Elena Dumitrescu", Email = "elena.dumitrescu@apia.ro", AgencyId = 16 },
                    new Agent { Id = 16, UserId = 41, Name = "Mihai Marin", Email = "mihai.marin@apia.ro", AgencyId = 17 },
                    new Agent { Id = 17, UserId = 42, Name = "Ana Vasilescu", Email = "ana.vasilescu@apia.ro", AgencyId = 18 },
                    new Agent { Id = 18, UserId = 43, Name = "Cristian Ene", Email = "cristian.ene@apia.ro", AgencyId = 19 },
                    new Agent { Id = 21, UserId = 46, Name = "Ioana Neagu", Email = "ioana.neagu@apia.ro", AgencyId = 22 },
                    new Agent { Id = 23, UserId = 48, Name = "Monica Florescu", Email = "monica.florescu@apia.ro", AgencyId = 13 },
                    new Agent { Id = 24, UserId = 49, Name = "George Petrescu", Email = "george.petrescu@apia.ro", AgencyId = 14 },
                    new Agent { Id = 25, UserId = 50, Name = "Daniela Voicu", Email = "daniela.voicu@apia.ro", AgencyId = 15 }
                );


                modelBuilder.Entity<Farmer>().HasData(
                    new Farmer { Id = 1, UserId = 4, Name = "John Doe", Location = "Sinca Noua", Budget = 10000, Category = "Livestock", AgentId = 1,Email="john.doe@example.com" },
                    new Farmer { Id = 2, UserId = 5, Name = "Jane Smith", Location = "Poiana Marului", Budget = 15000, Category = "Crops", AgentId = 2, Email = "jane.smith@example.com" },
                    new Farmer { Id = 3, UserId = 6, Name = "Michael Brown", Location = "Sinca Veche", Budget = 20000, Category = "Dairy", AgentId = 1, Email = "michael.brown@example.com" },
                    new Farmer { Id = 4, UserId = 7, Name = "Emily Davis", Location = "Sinca Noua", Budget = 18000, Category = "Poultry", AgentId = 3, Email = "emily.davis@example.com" }
                );

                modelBuilder.Entity<Land>().HasData(
                    new Land { Id = 1, County="Brasov", Location = "Field 1", Type = "Pasture", Area = 50, FarmerId = 1, CoordinatesJson = "[{\"lat\":45.7401,\"lng\":25.0659},{\"lat\":45.7402,\"lng\":25.0663},{\"lat\":45.7403,\"lng\":25.0660}]" },
                    new Land { Id = 2, County = "Brasov", Location = "Field 2", Type = "Corn", Area = 30, FarmerId = 2, CoordinatesJson = "[{\"lat\":45.7410,\"lng\":25.0671},{\"lat\":45.7412,\"lng\":25.0675},{\"lat\":45.7411,\"lng\":25.0672}]" },
                    new Land { Id = 3, County = "Brasov", Location = "Field 3", Type = "Wheat", Area = 40, FarmerId = 3, CoordinatesJson = "[{\"lat\":45.7425,\"lng\":25.0680},{\"lat\":45.7427,\"lng\":25.0683},{\"lat\":45.7426,\"lng\":25.0681}]" },
                    new Land { Id = 4, County = "Brasov", Location = "Field 4", Type = "Rice", Area = 60, FarmerId = 4, CoordinatesJson = "[{\"lat\":45.7430,\"lng\":25.0690},{\"lat\":45.7432,\"lng\":25.0695},{\"lat\":45.7431,\"lng\":25.0692}]"  },
                    new Land
                    {
                        Id = 7,
                        County = "Brasov",
                        Location = "Șinca Nouă",
                        Type = "Fâneață",
                        Area = 25,
                        FarmerId = 9,
                        CoordinatesJson = "[{\"lat\":45.7416,\"lng\":25.1282},{\"lat\":45.7418,\"lng\":25.1287},{\"lat\":45.7415,\"lng\":25.1285}]"
                    },
                    new Land
                    {
                        Id = 8,
                        County = "Brasov",
                        Location = "Șinca Nouă",
                        Type = "Fâneață",
                        Area = 25,
                        FarmerId = 9,
                        CoordinatesJson = coordinatesJson
                    },
                    new Land
                    {
                        Id = 9,
                        County = "Brasov",
                        Location = "Șinca Nouă",
                        Type = "Fâneață",
                        Area = 25,
                        FarmerId = 9,
                        CoordinatesJson = coordinatesJson
                    }
                );

                modelBuilder.Entity<Animal>().HasData(
                    new Animal { Id = 1, Name = "Cow 1", Breed = "Holstein", Weight = 500, Price = 1500, FarmerId = 1 },
                    new Animal { Id = 2, Name = "Sheep 1", Breed = "Merino", Weight = 80, Price = 300, FarmerId = 2 },
                    new Animal { Id = 3, Name = "Goat 1", Breed = "Boer", Weight = 50, Price = 200, FarmerId = 2 },
                    new Animal { Id = 4, Name = "Chicken 1", Breed = "Leghorn", Weight = 2, Price = 50, FarmerId = 4 }
                );

                modelBuilder.Entity<Supply>().HasData(
                    new Supply { Id = 1, Name = "Hay", Quantity = 100, Quality = "Good", Price = 500 },
                    new Supply { Id = 2, Name = "Corn Feed", Quantity = 50, Quality = "Premium", Price = 700 }
);

                modelBuilder.Entity<FarmerSupply>().HasData(
                    //new FarmerSupply { Id = 1, FarmerId = 1, SupplyId = 1, Quantity = 50 },
                    new FarmerSupply { Id = 2, FarmerId = 2, SupplyId = 2, Quantity = 30 },
                    new FarmerSupply { Id = 3, FarmerId = 9, SupplyId = 3, Quantity = 20 }
                    );



                modelBuilder.Entity<FarmerRating>().HasData(
                    new FarmerRating { Id = 1, FarmerId = 1, Rating = 5, Comment = "Excellent work", CreatedAt = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc) },
                    new FarmerRating { Id = 2, FarmerId = 2, Rating = 4, Comment = "Good progress", CreatedAt = new DateTime(2024, 1, 2, 14, 30, 0, DateTimeKind.Utc) },
                    new FarmerRating { Id = 3, FarmerId = 3, Rating = 3, Comment = "Needs improvement", CreatedAt = new DateTime(2024, 1, 3, 16, 45, 0, DateTimeKind.Utc) },
                    new FarmerRating { Id = 4, FarmerId = 4, Rating = 5, Comment = "Excellent produce", CreatedAt = new DateTime(2024, 1, 4, 9, 15, 0, DateTimeKind.Utc) },
                    new FarmerRating { Id = 5, FarmerId = 9, Rating = 5, Comment = "Excellent produce", CreatedAt = new DateTime(2024, 1, 4, 9, 15, 0, DateTimeKind.Utc) }
                );

                modelBuilder.Entity<MarketItem>().HasData(
            new MarketItem { Id = 1, ItemType = "Animal", ItemId = 1, Price = 1500, SellerFarmerId = 1 },
            new MarketItem { Id = 2, ItemType = "Animal", ItemId = 2, Price = 300, SellerFarmerId = 2 },
            new MarketItem { Id = 3, ItemType = "Land", ItemId = 1, Price = 5000, SellerFarmerId = 1 },
            new MarketItem { Id = 4, ItemType = "Supply", ItemId = 1, Price = 500, SellerFarmerId = 3 }
        );
            }
        }
    }
}
