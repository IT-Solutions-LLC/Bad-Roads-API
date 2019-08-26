using System;
using ITSTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ITSTracker
{
    public partial class traccarContext : DbContext
    {
        public traccarContext()
        {
        }

        public traccarContext(DbContextOptions<traccarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Databasechangeloglock> Databasechangeloglock { get; set; }
        public virtual DbSet<TcAttributes> TcAttributes { get; set; }
        public virtual DbSet<TcCalendars> TcCalendars { get; set; }
        public virtual DbSet<TcCommands> TcCommands { get; set; }
        public virtual DbSet<TcDevices> TcDevices { get; set; }
        public virtual DbSet<TcDrivers> TcDrivers { get; set; }
        public virtual DbSet<TcEvents> TcEvents { get; set; }
        public virtual DbSet<TcGeofences> TcGeofences { get; set; }
        public virtual DbSet<TcGroups> TcGroups { get; set; }
        public virtual DbSet<TcMaintenances> TcMaintenances { get; set; }
        public virtual DbSet<TcNotifications> TcNotifications { get; set; }
        public virtual DbSet<TcPositions> TcPositions { get; set; }
        public virtual DbSet<TcServers> TcServers { get; set; }
        public virtual DbSet<TcStatistics> TcStatistics { get; set; }
        public virtual DbSet<TcUsers> TcUsers { get; set; }

        // Unable to generate entity type for table 'public.tc_user_geofence'. Please see the warning messages.
        // Unable to generate entity type for table 'public.databasechangelog'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_user_attribute'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_device_geofence'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_group_command'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_group_geofence'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_device_maintenance'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_user_group'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_user_command'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_group_notification'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_user_user'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_group_attribute'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_device_attribute'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_temp'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_user_device'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_user_maintenance'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_user_driver'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_user_calendar'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_group_driver'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_user_notification'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_group_maintenance'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_device_command'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_device_notification'. Please see the warning messages.
        // Unable to generate entity type for table 'public.tc_device_driver'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=207.180.214.149;Database=traccar;Username=postgres;Password=p@$$w0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Databasechangeloglock>(entity =>
            {
                entity.ToTable("databasechangeloglock");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Locked).HasColumnName("locked");

                entity.Property(e => e.Lockedby).HasColumnName("lockedby");

                entity.Property(e => e.Lockgranted).HasColumnName("lockgranted");
            });

            modelBuilder.Entity<TcAttributes>(entity =>
            {
                entity.ToTable("tc_attributes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasColumnName("attribute");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Expression)
                    .IsRequired()
                    .HasColumnName("expression");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<TcCalendars>(entity =>
            {
                entity.ToTable("tc_calendars");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attributes)
                    .IsRequired()
                    .HasColumnName("attributes");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TcCommands>(entity =>
            {
                entity.ToTable("tc_commands");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attributes)
                    .IsRequired()
                    .HasColumnName("attributes");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Textchannel)
                    .IsRequired()
                    .HasColumnName("textchannel")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<TcDevices>(entity =>
            {
                entity.ToTable("tc_devices");

                entity.HasIndex(e => e.Uniqueid)
                    .HasName("tc_devices_uniqueid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attributes).HasColumnName("attributes");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Contact).HasColumnName("contact");

                entity.Property(e => e.Disabled)
                    .HasColumnName("disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Groupid).HasColumnName("groupid");

                entity.Property(e => e.Lastupdate).HasColumnName("lastupdate");

                entity.Property(e => e.Mileage)
                    .HasColumnName("mileage")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Model).HasColumnName("model");

                entity.Property(e => e.MotoTime)
                    .HasColumnName("moto_time")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Positionid).HasColumnName("positionid");

                entity.Property(e => e.Uniqueid)
                    .IsRequired()
                    .HasColumnName("uniqueid");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TcDevices)
                    .HasForeignKey(d => d.Groupid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_devices_groupid");
            });

            modelBuilder.Entity<TcDrivers>(entity =>
            {
                entity.ToTable("tc_drivers");

                entity.HasIndex(e => e.Uniqueid)
                    .HasName("tc_drivers_uniqueid_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attributes)
                    .IsRequired()
                    .HasColumnName("attributes");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Uniqueid)
                    .IsRequired()
                    .HasColumnName("uniqueid");
            });

            modelBuilder.Entity<TcEvents>(entity =>
            {
                entity.ToTable("tc_events");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attributes).HasColumnName("attributes");

                entity.Property(e => e.Deviceid).HasColumnName("deviceid");

                entity.Property(e => e.Geofenceid).HasColumnName("geofenceid");

                entity.Property(e => e.Maintenanceid).HasColumnName("maintenanceid");

                entity.Property(e => e.Positionid).HasColumnName("positionid");

                entity.Property(e => e.Servertime).HasColumnName("servertime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.TcEvents)
                    .HasForeignKey(d => d.Deviceid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_events_deviceid");
            });

            modelBuilder.Entity<TcGeofences>(entity =>
            {
                entity.ToTable("tc_geofences");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasColumnName("area");

                entity.Property(e => e.Attributes).HasColumnName("attributes");

                entity.Property(e => e.Calendarid).HasColumnName("calendarid");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.Calendar)
                    .WithMany(p => p.TcGeofences)
                    .HasForeignKey(d => d.Calendarid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_geofence_calendar_calendarid");
            });

            modelBuilder.Entity<TcGroups>(entity =>
            {
                entity.ToTable("tc_groups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attributes).HasColumnName("attributes");

                entity.Property(e => e.Groupid).HasColumnName("groupid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.InverseGroup)
                    .HasForeignKey(d => d.Groupid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_groups_groupid");
            });

            modelBuilder.Entity<TcMaintenances>(entity =>
            {
                entity.ToTable("tc_maintenances");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attributes)
                    .IsRequired()
                    .HasColumnName("attributes");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Period)
                    .HasColumnName("period")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Start)
                    .HasColumnName("start")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");
            });

            modelBuilder.Entity<TcNotifications>(entity =>
            {
                entity.ToTable("tc_notifications");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Always)
                    .IsRequired()
                    .HasColumnName("always")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Attributes).HasColumnName("attributes");

                entity.Property(e => e.Calendarid).HasColumnName("calendarid");

                entity.Property(e => e.Notificators).HasColumnName("notificators");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");

                entity.HasOne(d => d.Calendar)
                    .WithMany(p => p.TcNotifications)
                    .HasForeignKey(d => d.Calendarid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_notification_calendar_calendarid");
            });

            modelBuilder.Entity<TcPositions>(entity =>
            {
                entity.ToTable("tc_positions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accuracy)
                    .HasColumnName("accuracy")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Altitude).HasColumnName("altitude");

                entity.Property(e => e.Attributes).HasColumnName("attributes");

                entity.Property(e => e.Course).HasColumnName("course");

                entity.Property(e => e.Deviceid).HasColumnName("deviceid");

                entity.Property(e => e.Devicetime).HasColumnName("devicetime");

                entity.Property(e => e.Fixtime).HasColumnName("fixtime");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Network).HasColumnName("network");

                entity.Property(e => e.Protocol).HasColumnName("protocol");

                entity.Property(e => e.Servertime)
                    .HasColumnName("servertime")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Speed).HasColumnName("speed");

                entity.Property(e => e.Valid).HasColumnName("valid");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.TcPositions)
                    .HasForeignKey(d => d.Deviceid)
                    .HasConstraintName("fk_positions_deviceid");
            });

            modelBuilder.Entity<TcServers>(entity =>
            {
                entity.ToTable("tc_servers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attributes).HasColumnName("attributes");

                entity.Property(e => e.Bingkey).HasColumnName("bingkey");

                entity.Property(e => e.Coordinateformat).HasColumnName("coordinateformat");

                entity.Property(e => e.Devicereadonly)
                    .HasColumnName("devicereadonly")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Forcesettings)
                    .IsRequired()
                    .HasColumnName("forcesettings")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Limitcommands)
                    .HasColumnName("limitcommands")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Map).HasColumnName("map");

                entity.Property(e => e.Mapurl).HasColumnName("mapurl");

                entity.Property(e => e.Poilayer).HasColumnName("poilayer");

                entity.Property(e => e.Readonly)
                    .IsRequired()
                    .HasColumnName("readonly")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Registration)
                    .IsRequired()
                    .HasColumnName("registration")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Twelvehourformat)
                    .IsRequired()
                    .HasColumnName("twelvehourformat")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Zoom)
                    .HasColumnName("zoom")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TcStatistics>(entity =>
            {
                entity.ToTable("tc_statistics");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activedevices)
                    .HasColumnName("activedevices")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Activeusers)
                    .HasColumnName("activeusers")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Attributes)
                    .IsRequired()
                    .HasColumnName("attributes");

                entity.Property(e => e.Capturetime).HasColumnName("capturetime");

                entity.Property(e => e.Geocoderrequests)
                    .HasColumnName("geocoderrequests")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Geolocationrequests)
                    .HasColumnName("geolocationrequests")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mailsent)
                    .HasColumnName("mailsent")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Messagesreceived)
                    .HasColumnName("messagesreceived")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Messagesstored)
                    .HasColumnName("messagesstored")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Requests)
                    .HasColumnName("requests")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Smssent)
                    .HasColumnName("smssent")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TcUsers>(entity =>
            {
                entity.ToTable("tc_users");

                entity.HasIndex(e => e.Email)
                    .HasName("tc_users_email_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Administrator).HasColumnName("administrator");

                entity.Property(e => e.Attributes).HasColumnName("attributes");

                entity.Property(e => e.Coordinateformat).HasColumnName("coordinateformat");

                entity.Property(e => e.Devicelimit)
                    .HasColumnName("devicelimit")
                    .HasDefaultValueSql("'-1'::integer");

                entity.Property(e => e.Devicereadonly)
                    .HasColumnName("devicereadonly")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Disabled)
                    .HasColumnName("disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Expirationtime).HasColumnName("expirationtime");

                entity.Property(e => e.Hashedpassword).HasColumnName("hashedpassword");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Limitcommands)
                    .HasColumnName("limitcommands")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Login).HasColumnName("login");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Map).HasColumnName("map");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Poilayer).HasColumnName("poilayer");

                entity.Property(e => e.Readonly)
                    .IsRequired()
                    .HasColumnName("readonly")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Salt).HasColumnName("salt");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.Twelvehourformat)
                    .IsRequired()
                    .HasColumnName("twelvehourformat")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Userlimit)
                    .HasColumnName("userlimit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Zoom)
                    .HasColumnName("zoom")
                    .HasDefaultValueSql("0");
            });
        }
    }
}
