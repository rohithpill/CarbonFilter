using Microsoft.EntityFrameworkCore;

namespace CarbonFilter.Models
{
    public class SurveyDbContext : DbContext
    {

        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            modelBuilder.UseOpenIddict();

            SurveyDBInitializer.InsertCategories(modelBuilder);
            SurveyDBInitializer.InsertDropDowns(modelBuilder);
            SurveyDBInitializer.InsertDropDownOptions(modelBuilder);
            SurveyDBInitializer.InsertQuestions(modelBuilder);
            SurveyDBInitializer.InsertPickListItems(modelBuilder);
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DropDown> DropDowns { get; set; }
        public DbSet<DropDownOption> DropDownOptions { get; set; }
        public DbSet<PickListItem> PickListItems { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<UserResponse> UserResponses { get; set; }

    }
}
