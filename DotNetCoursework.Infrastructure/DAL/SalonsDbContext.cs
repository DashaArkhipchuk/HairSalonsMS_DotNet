using System;
using System.Collections.Generic;
using DotNetCoursework.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoursework.Infrastructure.DAL;

public partial class SalonsDbContext : DbContext
{
    public SalonsDbContext()
    {
    }

    public SalonsDbContext(DbContextOptions<SalonsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Salon> Salons { get; set; }

    public virtual DbSet<SalonsManager> SalonsManagers { get; set; }

    public virtual DbSet<SalonsStylist> SalonsStylists { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Stylist> Stylists { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-PFI2QT1\\SQLEXPRESS;Database=salons_db;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3213E83F0C38BDBC");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("district");
            entity.Property(e => e.Region)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("region");
            entity.Property(e => e.SalonId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("salon_id");
            entity.Property(e => e.Street)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("street");

            entity.HasOne(d => d.Salon).WithOne(p => p.Address)
                .HasForeignKey<Address>(a => a.SalonId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Addresses__salon__3C69FB99");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3213E83F32F18218");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.SalonId).HasColumnName("salon_id");
            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.StylistId).HasColumnName("stylist_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Appointme__custo__09A971A2");

            entity.HasOne(d => d.Salon).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.SalonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__salon__0C85DE4D");

            entity.HasOne(d => d.Schedule).WithOne(p => p.Appointment)
                .HasForeignKey<Appointment>(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__sched__0D7A0286");

            entity.HasOne(d => d.Service).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__servi__0A9D95DB");

            entity.HasOne(d => d.Stylist).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.StylistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__styli__0B91BA14");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Currenci__3213E83FB1F9864A");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.CurrencyValue)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("currency_value");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3213E83F1DA30AB6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("contact_phone");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Customers__user___5AEE82B9");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Managers__3213E83FD352F52A");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("contact_phone");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Manager)
                .HasForeignKey<Manager>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Managers__user_i__5629CD9C");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3213E83FD79FB736");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.PaymentValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("payment_value");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.StylistId).HasColumnName("stylist_id");

            entity.HasOne(d => d.Currency).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK__Payments__curren__160F4887");

            entity.HasOne(d => d.Customer).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Payments__custom__17036CC0");

            entity.HasOne(d => d.Service).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__servic__17F790F9");

            entity.HasOne(d => d.Stylist).WithMany(p => p.Payments)
                .HasForeignKey(d => d.StylistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payments__stylis__18EBB532");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prices__3213E83FC1F5BC9D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.StylistId).HasColumnName("stylist_id");
            entity.Property(e => e.Value)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("value");

            entity.HasOne(d => d.Currency).WithMany(p => p.Prices)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Prices__currency__6C190EBB");

            entity.HasOne(d => d.Stylist).WithMany(p => p.Prices)
                .HasForeignKey(d => d.StylistId)
                .HasConstraintName("FK__Prices__stylist___6B24EA82");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3213E83FC6FB92A7");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Salon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Salons__3213E83FBF22E7A6");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("contact_phone");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.HasMany(e => e.Managers)
                .WithMany(e => e.Salons)
            .UsingEntity<SalonsManager>();
            entity.HasMany(e => e.Stylists)
                .WithMany(e => e.Salons)
                .UsingEntity<SalonsStylist>();

        });
        modelBuilder.Entity<SalonsManager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__salons_m__3213E83FE2DC45A3");

            entity.ToTable("salons_managers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.SalonId).HasColumnName("salon_id");

            entity.HasOne(d => d.Manager).WithMany(p => p.SalonsManagers)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__salons_ma__manag__60A75C0F");

            entity.HasOne(d => d.Salon).WithMany(p => p.SalonsManagers)
                .HasForeignKey(d => d.SalonId)
                .HasConstraintName("FK__salons_ma__salon__5FB337D6");
        });

        modelBuilder.Entity<SalonsStylist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__salons_s__3213E83FAF0304A2");

            entity.ToTable("salons_stylists");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SalonId).HasColumnName("salon_id");
            entity.Property(e => e.StylistId).HasColumnName("stylist_id");

            entity.HasOne(d => d.Salon).WithMany(p => p.SalonsStylists)
                .HasForeignKey(d => d.SalonId)
                .HasConstraintName("FK__salons_st__salon__6383C8BA");

            entity.HasOne(d => d.Stylist).WithMany(p => p.SalonsStylists)
                .HasForeignKey(d => d.StylistId)
                .HasConstraintName("FK__salons_st__styli__6477ECF3");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Schedule__3213E83F50513767");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EndHour).HasColumnName("end_hour");
            entity.Property(e => e.SalonId).HasColumnName("salon_id");
            entity.Property(e => e.StartHour).HasColumnName("start_hour");
            entity.Property(e => e.StylistId).HasColumnName("stylist_id");

            entity.HasOne(d => d.Salon).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.SalonId)
                .HasConstraintName("FK__Schedules__salon__6754599E");

            entity.HasOne(d => d.Stylist).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.StylistId)
                .HasConstraintName("FK__Schedules__styli__68487DD7");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Services__3213E83F2B056289");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PriceId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("price_id");

            entity.HasOne(d => d.Price).WithMany(p => p.Services)
                .HasForeignKey(d => d.PriceId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Services__price___7E37BEF6");
        });

        modelBuilder.Entity<Stylist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stylists__3213E83F739DFD4B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("contact_phone");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Stylist)
                .HasForeignKey<Stylist>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Stylists__user_i__5165187F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FD927AB4E");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__role_id__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
