namespace EF6_ClassLibrary
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<n> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Delegation> Delegations { get; set; }
        public virtual DbSet<GroupPermission> GroupPermissions { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupUser> GroupUsers { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<NotificationsUser> NotificationsUsers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public virtual DbSet<ReviewWorkflowInstance> ReviewWorkflowInstances { get; set; }
        public virtual DbSet<ReviewWorkflow> ReviewWorkflows { get; set; }
        public virtual DbSet<ReviewWorkflowsProject> ReviewWorkflowsProjects { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectStatus> SubjectStatuses { get; set; }
        public virtual DbSet<TeamModel> TeamModels { get; set; }
        public virtual DbSet<TeamModelSubject> TeamModelSubjects { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<WeeklyInput> WeeklyInputs { get; set; }
        public virtual DbSet<WeeklyInputHistory> WeeklyInputHistories { get; set; }
        public virtual DbSet<POSITION_HIREARCHY> POSITION_HIREARCHY { get; set; }
        public virtual DbSet<XXHR_ORG_HIERARCHY_MV> XXHR_ORG_HIERARCHY_MV { get; set; }
        public virtual DbSet<BusinessUnitesView> BusinessUnitesViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.PF_NO)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FIRST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FAMILY_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.EMPLOYEE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.POST_TITLE_LONG_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LOCATION)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ENGAGEMENT_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.OFFICE_TELEPHONE_NUMBER)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.OFFICE_LOCATION)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.EMPLOYMENT_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Owner_UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.GroupUsers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.NotificationsUsers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ReviewWorkflows)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ReviewWorkflows1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.Owner_UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupPermission>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<GroupPermission>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Group>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Group>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupPermissions)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupUsers)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupUser>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<GroupUser>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Permission>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.GroupPermissions)
                .WithRequired(e => e.Permission)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Configuration>()
                .Property(e => e.Key)
                .IsUnicode(false);

            modelBuilder.Entity<Configuration>()
                .Property(e => e.Value)
                .IsUnicode(false);

            modelBuilder.Entity<Configuration>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Configuration>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Configuration>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Notification>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Notification>()
                .HasMany(e => e.NotificationsUsers)
                .WithRequired(e => e.Notification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NotificationsUser>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Project>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Project>()
                .HasMany(e => e.ReviewWorkflowsProjects)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.TeamModels)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Templates)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectStatus>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectStatus>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<ProjectStatus>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.ProjectStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReviewWorkflowInstance>()
                .Property(e => e.Action)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ReviewWorkflowInstance>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<ReviewWorkflowInstance>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<ReviewWorkflow>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ReviewWorkflow>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ReviewWorkflow>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<ReviewWorkflow>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<ReviewWorkflow>()
                .HasMany(e => e.ReviewWorkflowsProjects)
                .WithRequired(e => e.ReviewWorkflow)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReviewWorkflowsProject>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ReviewWorkflowsProject>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<ReviewWorkflowsProject>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<ReviewWorkflowsProject>()
                .HasMany(e => e.ReviewWorkflowInstances)
                .WithRequired(e => e.ReviewWorkflowsProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.TeamModelSubjects)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.WeeklyInputs)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.WeeklyInputHistories)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubjectStatus>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<SubjectStatus>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<SubjectStatus>()
                .HasMany(e => e.Subjects)
                .WithRequired(e => e.SubjectStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TeamModel>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<TeamModel>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<TeamModel>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<TeamModel>()
                .HasMany(e => e.TeamModelSubjects)
                .WithRequired(e => e.TeamModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TeamModelSubject>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<TeamModelSubject>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<TeamModelSubject>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Template>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Template>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Template>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Template>()
                .HasMany(e => e.Subjects)
                .WithRequired(e => e.Template)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WeeklyInput>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<WeeklyInput>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<WeeklyInput>()
                .HasMany(e => e.WeeklyInputHistories)
                .WithRequired(e => e.WeeklyInput)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WeeklyInputHistory>()
                .Property(e => e.Action)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<WeeklyInputHistory>()
                .Property(e => e.UpdateBy)
                .IsUnicode(false);

            modelBuilder.Entity<WeeklyInputHistory>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<POSITION_HIREARCHY>()
                .Property(e => e.POSITION_ID)
                .HasPrecision(15, 0);

            modelBuilder.Entity<POSITION_HIREARCHY>()
                .Property(e => e.REP_TO_POSITION_ID)
                .HasPrecision(15, 0);

            modelBuilder.Entity<XXHR_ORG_HIERARCHY_MV>()
                .Property(e => e.ORGID)
                .HasPrecision(15, 0);

            modelBuilder.Entity<BusinessUnitesView>()
                .Property(e => e.ORGID)
                .HasPrecision(15, 0);
        }
    }
}
