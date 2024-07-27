using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Naqleen.Presistence.Configurations;
using Naqleen.Presistence.Configurations.Invoice;
using Naqleen.Presistence.Configurations.Clients;
using MediatorCQRS.Helpers.DTOS.Functions;
using MediatorCQRS.Helpers.DTOS.LKs;
using MediatorCQRS.Helpers.DTOS.Reports;
using MediatorCQRS.Helpers.DTOS.Views;
using MediatorCQRS.Helpers.Entities;
using MediatorCQRS.Helpers.Entities.ClientAggregateRoot;
using MediatorCQRS.Helpers.Entities.InvoiceAggregateRoot;
using MediatorCQRS.Helpers.Entities.Zatca;

namespace MediatorCQRS.DatabaseContext
{
    public class NaqleenDBContext : IdentityDbContext<ApplicationUser>
    {

        public virtual DbSet<LKCity> LKCity { get; set; }
        public virtual DbSet<LKPointOfSale> LKPointOfSale { get; set; }
        public virtual DbSet<LKProduct> LKProduct { get; set; }
        public virtual DbSet<LKRegion> LKRegion { get; set; }
        public virtual DbSet<MainPriceHistory> MainPriceHistories { get; set; }
        public virtual DbSet<PointOfSale> PointOfSales { get; set; }
        public virtual DbSet<Pump> Pumps { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<StationProduct> StationProducts { get; set; }
        public virtual DbSet<Tank> Tanks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LKOrderType> LKOrderTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Escape> Escapes { get; set; }
        public virtual DbSet<vw_StationOverview> vw_StationOverview { get; set; }
        public virtual DbSet<ActiveStationDashboardResult> sp_GetActiveStationDashboardResult { get; set; }
        public virtual DbSet<vw_EmployeeDetails> vw_EmployeeDetails { get; set; }
        public virtual DbSet<vw_GetStationPrices> vw_getstationprices { get; set; }
        public virtual DbSet<vw_GetMainStationDetails> vw_getmainstationdetails { get; set; }
        public virtual DbSet<vw_GetStationTanks> vw_getstationtanks { get; set; }
        public virtual DbSet<vw_GetStationPumps> vw_GetStationPumps { get; set; }
        public virtual DbSet<vw_GetStationPointOfSales> vw_GetStationPointOfSales { get; set; }
        public virtual DbSet<vw_GetCityByRegionId> vw_GetCityByRegionId { get; set; }
        public virtual DbSet<XMLData> XMLsData { get; set; }
        public virtual DbSet<CSIDData> CSIDData { get; set; }
        public virtual DbSet<InvalidZatcaInvoice> InvalidZatcaInvoices { get; set; }
        public virtual DbSet<LKInvoiceType> LKInvoiceTypes { get; set; }
        public virtual DbSet<GetZatcaReportsDto> GetZatcaReportsDtos { get; set; }
        public virtual DbSet<SerialNumberTrack> SerialNumberTrack { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ShopRentalInvoice> ShopRentalInvoices { get; set; }
        public virtual DbSet<ShopRentalInvoiceCondition> ShopRentalInvoiceConditions { get; set; }
        public virtual DbSet<PostpaidClientInvoice> PostpaidClientInvoices { get; set; }
        public virtual DbSet<PostpaidClientInvoiceCondition> PostpaidClientInvoiceConditions { get; set; }
        public DbSet<GeneralBudgetReportView> DailyProductSales { get; set; }
        public NaqleenDBContext(DbContextOptions<NaqleenDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<XMLData>()
                .HasIndex(e => e.InvoiceCounter)
                .IsUnique();

            builder.ApplyConfiguration(new StationConfiguration());
            builder.ApplyConfiguration(new StationProductConfiguration());
            builder.ApplyConfiguration(new PointOfSaleConfiguration());
            builder.ApplyConfiguration(new TankConfiguration());
            builder.ApplyConfiguration(new PumpConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ShopRentalInvoiceConfiguration());
            builder.ApplyConfiguration(new ShopRentalInvoiceConditionConfiguration());
            builder.ApplyConfiguration(new PostpaidClientInvoiceConfiguration());
            builder.ApplyConfiguration(new PostpaidClientInvoiceConditionConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            //builder.ApplyQueryFilter<IActiveEntity>(e => e.IsActive == true);


            base.OnModelCreating(builder);

            #region Views
            builder.Entity<vw_StationOverview>(entity =>
            {
                entity.ToView("vw_stationoverview")
                .HasNoKey();
            });

            builder.Entity<vw_EmployeeDetails>(entity =>
            {
                entity.ToView("vw_EmployeeDetails")
                .HasNoKey();
            });

            builder.Entity<vw_GetStationPrices>(entity =>
            {
                entity.ToView("vw_getstationprices")
                .HasNoKey();
            });

            builder.Entity<vw_GetMainStationDetails>(entity =>
            {
                entity.ToView("vw_getmainstationdetails")
                .HasNoKey();
            });

            builder.Entity<vw_GetStationTanks>(entity =>
            {
                entity.ToView("vw_getstationtanks")
                .HasNoKey();
            });

            builder.Entity<vw_GetStationPumps>(entity =>
            {
                entity.ToView("vw_GetStationPumps")
                .HasNoKey();
            });

            builder.Entity<vw_GetStationPointOfSales>(entity =>
            {
                entity.ToView("vw_GetStationPointOfSales")
                .HasNoKey();
            });

            builder.Entity<vw_GetCityByRegionId>(entity =>
            {
                entity.ToView("vw_GetCityByRegionId")
                .HasNoKey();
            });

            //builder.Entity<ClientPaymentSummaryDto>(entity =>
            //{
            //    entity.ToView("vw_ClientPaymentSummary")
            //    .HasNoKey();
            //});

            //builder.Entity<PostpaidClientPaymentSummaryDto>(entity =>
            //{
            //    entity.ToView("vw_PostpaidClientPaymentSummary")
            //    .HasNoKey();
            //});

            //builder.Entity<GetZatcaReportsDto>(entity =>
            //{
            //    entity.ToView("vw_InvoiceReportsView")
            //    .HasNoKey();
            //});
            //builder.Entity<GeneralBudgetReportView>(entity =>
            //{
            //    entity.ToView("vw_GeneralBudgetReport")
            //    .HasNoKey();
            //});
            #endregion

            #region SP
            builder.Entity<ActiveStationDashboardResult>(entity =>
            {
                entity.ToView("sp_GetActiveStationDashboard")
                .HasNoKey();
            });

            builder.Entity<GeneralBudgetReportView>(entity =>
            {
                entity.HasNoKey(); // Important because the function doesn't provide a primary key
                entity.ToView("GetDailyProductSales"); // Treat the function as a view
            });

            #endregion
        }























        public class ApplicationUser : IdentityUser
        {

            public bool? PasswordNeedToReset { get; set; }

            // Override the UserName property to allow nul
            public override string? UserName { get; set; }
            public string? FullName { get; set; }

            public String? Job { get; set; }
            public int? StationId { get; set; }
            public DateTime BirthDay { get; set; }
            [Required]
            public string EmployeeNumber { get; set; }
            public string? OTP { get; set; }
            public DateTime? OTPExpiration { get; set; }
        }
    }
}
