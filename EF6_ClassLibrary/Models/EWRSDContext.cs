using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EF6_ClassLibrary.Models.Mapping;

namespace EF6_ClassLibrary.Models
{
    public partial class EWRSDContext : DbContext
    {
        static EWRSDContext()
        {
            Database.SetInitializer<EWRSDContext>(null);
        }

        public EWRSDContext()
            : base("Name=EWRSDContext")
        {
        }

        public DbSet<POSITION_HIREARCHY> POSITION_HIREARCHY { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<XXHR_ORG_HIERARCHY_MV> XXHR_ORG_HIERARCHY_MV { get; set; }
        public DbSet<Delegation> Delegations { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationsUser> NotificationsUsers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<ReviewWorkflowInstance> ReviewWorkflowInstances { get; set; }
        public DbSet<ReviewWorkflow> ReviewWorkflows { get; set; }
        public DbSet<ReviewWorkflowsProject> ReviewWorkflowsProjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectStatus> SubjectStatuses { get; set; }
        public DbSet<TeamModel> TeamModels { get; set; }
        public DbSet<TeamModelSubject> TeamModelSubjects { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<WeeklyInput> WeeklyInputs { get; set; }
        public DbSet<WeeklyInputHistory> WeeklyInputHistories { get; set; }
        public DbSet<BusinessUnitesView> BusinessUnitesViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new POSITION_HIREARCHYMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new XXHR_ORG_HIERARCHY_MVMap());
            modelBuilder.Configurations.Add(new DelegationMap());
            modelBuilder.Configurations.Add(new GroupPermissionMap());
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new GroupUserMap());
            modelBuilder.Configurations.Add(new PermissionMap());
            modelBuilder.Configurations.Add(new ConfigurationMap());
            modelBuilder.Configurations.Add(new NotificationMap());
            modelBuilder.Configurations.Add(new NotificationsUserMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new ProjectStatusMap());
            modelBuilder.Configurations.Add(new ReviewWorkflowInstanceMap());
            modelBuilder.Configurations.Add(new ReviewWorkflowMap());
            modelBuilder.Configurations.Add(new ReviewWorkflowsProjectMap());
            modelBuilder.Configurations.Add(new SubjectMap());
            modelBuilder.Configurations.Add(new SubjectStatusMap());
            modelBuilder.Configurations.Add(new TeamModelMap());
            modelBuilder.Configurations.Add(new TeamModelSubjectMap());
            modelBuilder.Configurations.Add(new TemplateMap());
            modelBuilder.Configurations.Add(new WeeklyInputMap());
            modelBuilder.Configurations.Add(new WeeklyInputHistoryMap());
            modelBuilder.Configurations.Add(new BusinessUnitesViewMap());
        }
    }
}
