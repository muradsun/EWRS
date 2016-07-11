using ADMA.EWRS.Data.Access.EFConfigurations;
using ADMA.EWRS.Data.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace ADMA.EWRS.Data.Access
{
    [DbConfigurationType(typeof(EFDbConfiguration))]
    public class EWRSContext : DbContext
    {
        const string _connectionString = @"Data Source=MURAD-LP\SQL2K16;Initial Catalog=EWRSD;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public EWRSContext()
            : base(_connectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Murad> Muradies { get; set; }
        public DbSet<PositionHierarchy> PositionHierarchy { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrganizationHierarchy> OrganizationHierarchy { get; set; }
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
            //Murad :: TODO : Replace with Murad Db Logger... check formatter
#if DEBUG
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
#endif


            //Murad :: Fluent API configuration goes here
            modelBuilder.Configurations.Add(new PositionHierarchyMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new OrganizationHierarchyMap());
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
            modelBuilder.Configurations.Add(new MuradConfiguration());
        }




    }
}
