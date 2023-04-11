using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
//using DevExpress.Persistent.BaseImpl.EFCore.AuditTrail;
using DevExpress.CodeParser;

namespace Dogz.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class DogzContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<DogzEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new DogzEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class DogzDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DogzEFCoreDbContext> {
	public DogzEFCoreDbContext CreateDbContext(string[] args) {
		throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
		//var optionsBuilder = new DbContextOptionsBuilder<DogzEFCoreDbContext>();
		//optionsBuilder.UseSqlServer("Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Dogz");
        //optionsBuilder.UseChangeTrackingProxies();
        //optionsBuilder.UseObjectSpaceLinkProxies();
		//return new DogzEFCoreDbContext(optionsBuilder.Options);
	}
}
[TypesInfoInitializer(typeof(DogzContextInitializer))]
public class DogzEFCoreDbContext : DbContext {
	public DogzEFCoreDbContext(DbContextOptions<DogzEFCoreDbContext> options) : base(options) {
	}
	//public DbSet<ModuleInfo> ModulesInfo { get; set; }
	public DbSet<ModelDifference> ModelDifferences { get; set; }
	public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }
	public DbSet<PermissionPolicyRole> Roles { get; set; }
	public DbSet<Dogz.Module.BusinessObjects.ApplicationUser> Users { get; set; }
    public DbSet<Dogz.Module.BusinessObjects.ApplicationUserLoginInfo> UserLoginInfos { get; set; }
	public DbSet<ReportDataV2> ReportDataV2 { get; set; }
    //public DbSet<AuditDataItemPersistent> AuditData { get; set; }
    //public DbSet<AuditEFCoreWeakReference> AuditEFCoreWeakReference { get; set; }

    public DbSet<Dog> Dogs { get; set; }
   // public DbSet<Dalmation> Dalmations { get; set; }
    //public DbSet<Poodle> Poodles { get; set; }
    //public DbSet<Pug> Pugs { get; set; }
     public DbSet<Puppy> Puppies{ get; set; }

    //public DbSet<DalmationPup> DalmationPuppies { get; set; }
    //public DbSet<PoodlePup> PoodlePuppies { get; set; }
    //public DbSet<PugPup> PugPuppies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
         
        modelBuilder.Entity<Dog>().ToTable("Dogs");
        modelBuilder.Entity<Dog>().HasDiscriminator<int>(x => x.BreedId)
            .HasValue<Poodle>((int)DogBreed.Poodle)
            .HasValue<Dalmation>((int)DogBreed.Dalmation)
            .HasValue<Pug>((int)DogBreed.Pug);

        modelBuilder.Entity<Puppy>().ToTable("Puppies");
        modelBuilder.Entity<Puppy>().HasDiscriminator<int>(x => x.BreedId)
            .HasValue<PoodlePup>((int)DogBreed.Poodle)
            .HasValue<DalmationPup>((int)DogBreed.Dalmation)
            .HasValue<PugPup>((int)DogBreed.Pug);

        modelBuilder.Entity<DalmationPup>().HasOne(x => x.DalmationParent).WithMany(x => x.DalmationPups).HasForeignKey(x => x.ParentId);
        modelBuilder.Entity<PoodlePup>().HasOne(x => x.PoodleParent).WithMany(x => x.PoodlePups).HasForeignKey(x => x.ParentId);
        modelBuilder.Entity<PugPup>().HasOne(x => x.PugParent).WithMany(x => x.PugPups).HasForeignKey(x => x.ParentId);
        modelBuilder.Entity<Puppy>().HasOne(x => x.Parent).WithMany(x => x.Puppies).HasForeignKey(x => x.ParentId);

         
    }
}

 