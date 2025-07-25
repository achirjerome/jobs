using Jobs.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
namespace Jobs.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor takes options and passes to base
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets represent tables in the database
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationDocument> ApplicationDocuments { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Department> Departments { get; set; }        
        public DbSet<ApplicantAccount> ApplicantAccounts { get; set; }
        public DbSet<VerificationToken> VerificationTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example configurations:

            //// Ensure ApplicantName + Email are                
            //modelBuilder.Entity<Application>()
            //    .Property(a => a.ApplicantFirstName)
            //    .Is();

            //modelBuilder.Entity<Application>()
            //    .Property(a => a.ApplicantSurName)
            //    .Is();

            //modelBuilder.Entity<Application>()
            //    .Property(a => a.Email)
            //    .Is();

            //modelBuilder.Entity<Application>()
            //    .Property(a => a.PhoneNumber)
            //    .Is();

            //modelBuilder.Entity<Application>()
            //    .Property(a => a.Qualifications)
            //    .Is();

            //modelBuilder.Entity<Application>()
            //    .Property(a => a.WorkExperiences)
            //    .Is();

            // Configure relationships
            modelBuilder.Entity<Application>()
                .HasMany(a => a.UploadedDocuments)
                .WithOne(d => d.Application)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Application>()
                .HasMany(a => a.Qualifications)
                .WithOne(q => q.Application)
                .HasForeignKey(q => q.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Application>()
                .HasMany(a => a.WorkExperiences)
                .WithOne(w => w.Application)
                .HasForeignKey(w => w.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            // Add unique constraint example: Job.Title should be unique within a category (optional)
            modelBuilder.Entity<Job>()
                .HasIndex(j => new { j.Title, j.CategoryId })
                .IsUnique();

            modelBuilder.Entity<JobCategory>().HasData(
                new JobCategory
                {
                    Id = 1,
                    Name = "Technology",
                    Description = "Jobs related to software, hardware, IT, etc."
                },
                new JobCategory
                {
                    Id = 2,
                    Name = "Administration",
                    Description = "Administrative and office management roles"
                },
                new JobCategory
                {
                    Id = 3,
                    Name = "Academic",
                    Description = "Teaching and research positions"
                }
            );

            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Human Resources", Code = "HR" },
                new Department { Id = 2, Name = "Finance", Code = "FIN" },
                new Department { Id = 3, Name = "Information Technology", Code = "IT" },
                new Department { Id = 4, Name = "Marketing", Code = "MKT" },
                new Department { Id = 5, Name = "Operations", Code = "OPS" }
            );
            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    Id = 1,
                    Title = "Software Engineer",
                    Description = "Bachelor's degree in Computer Science or related field,3+ years of experience in software development, Proficiency in C#, .NET, and ASP.NET Core,Knowledge of front-end frameworks like React or Angular, Experience with relational databases (e.g., SQL Server, MySQL), Understanding of RESTful APIs, Strong problem-solving and debugging skills",
                    CategoryId = 1, // assume you also seed this category below
                    DepartmentId = 3, // assume this department exists in Departments table
                    StartDate = DateTime.UtcNow.AddDays(-20),
                    ClosingDate = DateTime.UtcNow.AddDays(10),
                    Active = true
                },
                new Job
                {
                    Id = 2,
                    Title = "Project Manager",
                    Description = "Bachelor's degree in Business, Management, or related field, 5+ years of project management experience, PMP or PRINCE2 certification preferred, Strong leadership and team management skills, Excellent communication and organizational skills, Proficiency with project management tools (e.g., MS Project, Jira), Ability to manage budgets and project timelines",
                    CategoryId = 2,
                    DepartmentId = 1, // assume this department exists in Departments table
                    StartDate = DateTime.UtcNow.AddDays(-15),
                    ClosingDate = DateTime.UtcNow.AddDays(15),
                    Active = true
                }
            );

            modelBuilder.Entity<Document>().HasData(
               // Documents for Software Engineer
               new Document { Id = 1, DocumentName = "Resume", JobId = 1 },
               new Document { Id = 2, DocumentName = "Cover Letter", JobId = 1 },
               new Document { Id = 3, DocumentName = "Degree", JobId = 1 },

               // Documents for Project Manager
               new Document { Id = 4, DocumentName = "Resume", JobId = 2 },
               new Document { Id = 5, DocumentName = "Cover Letter", JobId = 2 },
               new Document { Id = 6, DocumentName = "Degree", JobId = 2 },
               new Document { Id = 7, DocumentName = "Project Plan Sample", JobId = 2 }
            );

            modelBuilder.Entity<Application>().HasData(
                new Application
                {
                    Id = 1,
                    JobId = 1, // assume this job exists in Jobs table
                    ApplicantFirstName = "John",
                    ApplicantSurName = "Doe",
                    DateofBirth = new DateTime(1990, 5, 21),
                    Nationality = "Nigerian",
                    StateofOrigin = "Benue",
                    LGA = "Makurdi",
                    Email = "john.doe@example.com",
                    PhoneNumber = "+2348012345678",
                    AppliedOn = DateTime.UtcNow.AddDays(-10),
                    Status = "Pending"
                    // UploadedDocuments, Qualifications, WorkExperiences can't be seeded directly here;
                    // seed them separately by setting ApplicationId = 1
                },
                new Application
                {
                    Id = 2,
                    JobId = 2, // another job
                    ApplicantFirstName = "Jane",
                    ApplicantSurName = "Smith",
                    DateofBirth = new DateTime(1988, 8, 15),
                    Nationality = "Nigerian",
                    StateofOrigin = "Lagos",
                    LGA = "Ikeja",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "+2348098765432",
                    AppliedOn = DateTime.UtcNow.AddDays(-5),
                    Status = "Shortlisted"
                }
            );

            modelBuilder.Entity<ApplicationDocument>().HasData(
                new ApplicationDocument
                {
                    Id = 1,
                    ApplicationId = 1,
                    DocumentName = "CV_JohnDoe.pdf",
                    FilePath = "/uploads/cv_johndoe.pdf"
                },
                new ApplicationDocument
                {
                    Id = 2,
                    ApplicationId = 1,
                    DocumentName = "CoverLetter_JohnDoe.pdf",
                    FilePath = "/uploads/coverletter_johndoe.pdf"
                }
            );

            modelBuilder.Entity<Qualification>().HasData(
                new Qualification
                {
                    Id = 1,
                    ApplicationId = 1,
                    Title = "B.Sc. Computer Science",
                    Institution = "University of Abuja",
                    DateObtained = new DateTime(2015, 1, 1),
                }
            );

            modelBuilder.Entity<WorkExperience>().HasData(
                new WorkExperience
                {
                    Id = 1,
                    ApplicationId = 1,
                    CompanyName = "TechSoft Ltd.",
                    Position = "Software Developer",
                    FromDate = new DateTime(2015, 1, 1),
                    ToDate = new DateTime(2018, 12, 31)
                },
                new WorkExperience
                {
                    Id = 2,
                    ApplicationId = 1,
                    CompanyName = "InnovateX",
                    Position = "Senior Developer",
                    FromDate = new DateTime(2019, 1, 1),
                    ToDate = null // currently working
                }
            );


        }
    }
}
