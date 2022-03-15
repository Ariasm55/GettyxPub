using System;
using System.Collections.Generic;
using Getty.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Getty.Infrastructure.Data
{
    public partial class GettyContext : DbContext
    {
        public GettyContext()
        {
        }

        public GettyContext(DbContextOptions<GettyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CampCampaign> CampCampaigns { get; set; } = null!;
        public virtual DbSet<CntCountry> CntCountries { get; set; } = null!;
        public virtual DbSet<EmpEmployee> EmpEmployees { get; set; } = null!;
        public virtual DbSet<EschEmployeeSchedule> EschEmployeeSchedules { get; set; } = null!;
        public virtual DbSet<PnchPunchClock> PnchPunchClocks { get; set; } = null!;
        public virtual DbSet<RlsRole> RlsRoles { get; set; } = null!;
        public virtual DbSet<SchSchedule> SchSchedules { get; set; } = null!;
        public virtual DbSet<SchdScheduleDay> SchdScheduleDays { get; set; } = null!;
        public virtual DbSet<StsSite> StsSites { get; set; } = null!;
        public virtual DbSet<TmmbTeamMember> TmmbTeamMembers { get; set; } = null!;
        public virtual DbSet<TmsTeam> TmsTeams { get; set; } = null!;
        public virtual DbSet<UsrUser> UsrUsers { get; set; } = null!;
        public virtual DbSet<UsrlUserRole> UsrlUserRoles { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CampCampaign>(entity =>
            {
                entity.HasKey(e => e.CampId);

                entity.ToTable("camp_campaigns");

                entity.Property(e => e.CampId).HasColumnName("camp_id");

                entity.Property(e => e.CampDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("camp_description");

                entity.Property(e => e.CampStatus).HasColumnName("camp_status");

                entity.Property(e => e.CampStsId).HasColumnName("camp_sts_id");

                entity.HasOne(d => d.CampSts)
                    .WithMany(p => p.CampCampaigns)
                    .HasForeignKey(d => d.CampStsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_camp_campaigns_sts_sites");
            });

            modelBuilder.Entity<CntCountry>(entity =>
            {
                entity.HasKey(e => e.CntId);

                entity.ToTable("cnt_country");

                entity.Property(e => e.CntId).HasColumnName("cnt_id");

                entity.Property(e => e.CntDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cnt_description");

                entity.Property(e => e.CntStatus).HasColumnName("cnt_status");
            });

            modelBuilder.Entity<EmpEmployee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_Employee");

                entity.ToTable("emp_employees");

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.EmpFirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emp_first_name");

                entity.Property(e => e.EmpLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("emp_last_name");

                entity.Property(e => e.EmpStatus).HasColumnName("emp_status");

                entity.Property(e => e.EmpStsId).HasColumnName("emp_sts_id");
            });

            modelBuilder.Entity<EschEmployeeSchedule>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("esch_employee_schedule");

                entity.Property(e => e.EschEmpId).HasColumnName("esch_emp_id");

                entity.Property(e => e.EschSchId).HasColumnName("esch_sch_id");

                entity.HasOne(d => d.EschEmp)
                    .WithMany()
                    .HasForeignKey(d => d.EschEmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_esch_employee_schedule_emp_employees");

                entity.HasOne(d => d.EschSch)
                    .WithMany()
                    .HasForeignKey(d => d.EschSchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_esch_employee_schedule_sch_schedule");
            });

            modelBuilder.Entity<PnchPunchClock>(entity =>
            {
                entity.HasKey(e => e.PnchId);

                entity.ToTable("pnch_punch_clock");

                entity.Property(e => e.PnchId).HasColumnName("pnch_id");

                entity.Property(e => e.PnchDate)
                    .HasColumnType("datetime")
                    .HasColumnName("pnch_date");

                entity.Property(e => e.PnchDescrption)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pnch_descrption");

                entity.Property(e => e.PnchEmpId).HasColumnName("pnch_emp_id");
            });

            modelBuilder.Entity<RlsRole>(entity =>
            {
                entity.HasKey(e => e.RlsId)
                    .HasName("PK_urls_user_roles");

                entity.ToTable("rls_roles");

                entity.Property(e => e.RlsId).HasColumnName("rls_id");

                entity.Property(e => e.RlsDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("rls_description");

                entity.Property(e => e.RlsStatus).HasColumnName("rls_status");
            });

            modelBuilder.Entity<SchSchedule>(entity =>
            {
                entity.HasKey(e => e.SchId);

                entity.ToTable("sch_schedule");

                entity.Property(e => e.SchId).HasColumnName("sch_id");

                entity.Property(e => e.SchCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sch_code");

                entity.Property(e => e.SchDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sch_description");

                entity.Property(e => e.SchStatus).HasColumnName("sch_status");
            });

            modelBuilder.Entity<SchdScheduleDay>(entity =>
            {
                entity.HasKey(e => e.SchdDayId)
                    .HasName("PK_schd_schedule_detail");

                entity.ToTable("schd_schedule_days");

                entity.Property(e => e.SchdDayId).HasColumnName("schd_day_id");

                entity.Property(e => e.SchdDayDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("schd_day_description");

                entity.Property(e => e.SchdEndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("schd_end_time");

                entity.Property(e => e.SchdNumberOfDay).HasColumnName("schd_number_of_day");

                entity.Property(e => e.SchdScheduleId).HasColumnName("schd_schedule_id");

                entity.Property(e => e.SchdStartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("schd_start_time");

                entity.HasOne(d => d.SchdSchedule)
                    .WithMany(p => p.SchdScheduleDays)
                    .HasForeignKey(d => d.SchdScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_schd_schedule_days_sch_schedule");
            });

            modelBuilder.Entity<StsSite>(entity =>
            {
                entity.HasKey(e => e.StsId)
                    .HasName("PK_Sites");

                entity.ToTable("sts_sites");

                entity.Property(e => e.StsId).HasColumnName("sts_id");

                entity.Property(e => e.StsCntId).HasColumnName("sts_cnt_id");

                entity.Property(e => e.StsDateFormat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sts_date_format");

                entity.Property(e => e.StsName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sts_name");

                entity.Property(e => e.StsStatus).HasColumnName("sts_status");

                entity.Property(e => e.StsUtc).HasColumnName("sts_utc");

                entity.HasOne(d => d.StsCnt)
                    .WithMany(p => p.StsSites)
                    .HasForeignKey(d => d.StsCntId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sts_sites_cnt_country");
            });

            modelBuilder.Entity<TmmbTeamMember>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmmb_team_members");

                entity.Property(e => e.TmmbEmpId).HasColumnName("tmmb_emp_id");

                entity.Property(e => e.TmmbTmsId).HasColumnName("tmmb_tms_id");

                entity.HasOne(d => d.TmmbEmp)
                    .WithMany()
                    .HasForeignKey(d => d.TmmbEmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tmmb_team_members_emp_employees");

                entity.HasOne(d => d.TmmbTms)
                    .WithMany()
                    .HasForeignKey(d => d.TmmbTmsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tmmb_team_members_tms_teams");
            });

            modelBuilder.Entity<TmsTeam>(entity =>
            {
                entity.HasKey(e => e.TmsId);

                entity.ToTable("tms_teams");

                entity.Property(e => e.TmsId).HasColumnName("tms_id");

                entity.Property(e => e.TmsCampId).HasColumnName("tms_camp_id");

                entity.Property(e => e.TmsDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tms_description");

                entity.HasOne(d => d.TmsCamp)
                    .WithMany(p => p.TmsTeams)
                    .HasForeignKey(d => d.TmsCampId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tms_teams_camp_campaigns");
            });

            modelBuilder.Entity<UsrUser>(entity =>
            {
                entity.HasKey(e => e.UsrId)
                    .HasName("PK_Users");

                entity.ToTable("usr_users");

                entity.Property(e => e.UsrId).HasColumnName("usr_id");

                entity.Property(e => e.UsrEmpId).HasColumnName("usr_emp_id");

                entity.Property(e => e.UsrPassword).HasColumnName("usr_password");

                entity.Property(e => e.UsrRoleId).HasColumnName("usr_role_id");

                entity.Property(e => e.UsrSalt).HasColumnName("usr_salt");

                entity.Property(e => e.UsrUsername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usr_username");

                entity.Property(e => e.UsrUuId).HasColumnName("usr_uu_id");

                entity.HasOne(d => d.UsrEmp)
                    .WithMany(p => p.UsrUsers)
                    .HasForeignKey(d => d.UsrEmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usr_users_emp_employees");
            });

            modelBuilder.Entity<UsrlUserRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("usrl_user_roles");

                entity.Property(e => e.UsrlRlsId).HasColumnName("usrl_rls_id");

                entity.Property(e => e.UsrlUsrId).HasColumnName("usrl_usr_id");

                entity.HasOne(d => d.UsrlRls)
                    .WithMany()
                    .HasForeignKey(d => d.UsrlRlsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usrl_user_roles_rls_roles");

                entity.HasOne(d => d.UsrlUsr)
                    .WithMany()
                    .HasForeignKey(d => d.UsrlUsrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usrl_user_roles_usr_users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
