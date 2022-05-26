using Microsoft.EntityFrameworkCore;

namespace Hunter.API.Data
{
    public class HunterDbContext : DbContext
    {
        public HunterDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Company> Companys { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Ghost> Ghosts { get; set; }
        public DbSet<Population> Populations { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder )
        {
            // base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Company>()
                .HasMany<Project>(p => p.Projects);
       //         .OnDelete(DeleteBehavior.Cascade);

            modelbuilder.Entity<Project>()
                .HasOne<Company>(c => c.Company).WithMany(p => p.Projects)
                .HasForeignKey(c => c.CompanyId);

            modelbuilder.Entity<Ghost>()
                .HasOne<Project>(p => p.Project).WithMany(g => g.Ghosts)
                .HasForeignKey(g => g.ProjectId);

            modelbuilder.Entity<Ghost>()
                .HasOne<Population>(p => p.Population).WithOne(g => g.Ghost);

            modelbuilder.Entity<Population>()
                .HasMany<Individual>(i => i.Individuals).WithOne(p => p.Population);

            modelbuilder.Entity<Individual>()
                .HasMany<Feature>(f => f.Features).WithOne(i => i.Individual);

            modelbuilder.Entity<Feature>()
                .HasOne<Individual>(i => i.Individual);

            ///////////////////////////////////////////////////////////////

            modelbuilder.Entity<Company>()
                .HasData(
                new Company
                {
                    Id = 1,
                    Name = "Solution Hunter Engineering",
                    Billing = "free unlimited",
                    Region = "NewEngland"
                }
            );
            modelbuilder.Entity<Project>()
                .HasData(
                new Project
                {
                    Id = 1,
                    Designer = "Chuck Duncan",
                    Runner = "Buttons Duncan",
                    CompanyId = 1,
                }
            );
            modelbuilder.Entity<Ghost>().HasData(
                new Ghost
                {
                    Id = 1,
                    Era = 0,
                    isActive = true,
                    initialEra = "",
                    ProjectId = 1,
                }
            );

            modelbuilder.Entity<Population>().HasData(
                new Population
                {
                    Id = 1,
                    Evolution = 0,
                }
            );

            modelbuilder.Entity<Individual>().HasData(
                new Individual
                {
                    Id = 1,
                }
            );

            modelbuilder.Entity<Feature>().HasData(
                new Feature
                {
                    Id = 1,
                }
            );

        }

    }
}
