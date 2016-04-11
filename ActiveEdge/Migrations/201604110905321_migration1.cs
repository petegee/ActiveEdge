namespace ActiveEdge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(precision: 0),
                        Email = c.String(unicode: false),
                        ContactNumber = c.String(unicode: false),
                        AddressLine1 = c.String(unicode: false),
                        AddressLine2 = c.String(unicode: false),
                        Suburb = c.String(unicode: false),
                        City = c.String(unicode: false),
                        ExcerciseFrequency = c.Int(nullable: false),
                        IsSmoker = c.Boolean(nullable: false),
                        CurrentMedications = c.String(unicode: false),
                        PreviousAilments = c.String(unicode: false),
                        GeneralPractionerName = c.String(unicode: false),
                        GPClearance = c.Boolean(nullable: false),
                        HasHadPreviousTherapy = c.Boolean(nullable: false),
                        TouchPreference = c.Int(nullable: false),
                        ContraIndications_Sunburn = c.Boolean(nullable: false),
                        ContraIndications_Headache = c.Boolean(nullable: false),
                        ContraIndications_Astha = c.Boolean(nullable: false),
                        ContraIndications_Diabetes = c.Boolean(nullable: false),
                        ContraIndications_Epilepsy = c.Boolean(nullable: false),
                        ContraIndications_Depression = c.Boolean(nullable: false),
                        ContraIndications_Hemophilia = c.Boolean(nullable: false),
                        ContraIndications_CutsBurnsBruises = c.Boolean(nullable: false),
                        ContraIndications_SeverePain = c.Boolean(nullable: false),
                        ContraIndications_Arteriosclerosis = c.Boolean(nullable: false),
                        ContraIndications_VaricoseVeins = c.Boolean(nullable: false),
                        ContraIndications_Dizziness = c.Boolean(nullable: false),
                        ContraIndications_HighBloodPressure = c.Boolean(nullable: false),
                        ContraIndications_LowBloodPressure = c.Boolean(nullable: false),
                        ContraIndications_Imflamation = c.Boolean(nullable: false),
                        ContraIndications_SleepDisturbance = c.Boolean(nullable: false),
                        ContraIndications_IsPregnant = c.Boolean(nullable: false),
                        ContraIndications_Hernia = c.Boolean(nullable: false),
                        ContraIndications_Cancer = c.Boolean(nullable: false),
                        ContraIndications_ContactLenses = c.Boolean(nullable: false),
                        ContraIndications_MusculoskletalProblems = c.Boolean(nullable: false),
                        ContraIndications_IrritatedSkinRash = c.Boolean(nullable: false),
                        ContraIndications_ColdOrFlu = c.Boolean(nullable: false),
                        ContraIndications_Arthritis = c.Boolean(nullable: false),
                        ContraIndications_StomachUlcers = c.Boolean(nullable: false),
                        ContraIndications_PinsPacemaker = c.Boolean(nullable: false),
                        ContraIndications_HeartDisease = c.Boolean(nullable: false),
                        CurrentStressLevels = c.Int(nullable: false),
                        CurrentPainOrTensionLevels = c.Int(nullable: false),
                        Difficuties = c.String(unicode: false),
                        AreasNotToBeMassaged = c.String(unicode: false),
                        TermsAndConditions_Condition1 = c.Boolean(nullable: false),
                        TermsAndConditions_Condition2 = c.Boolean(nullable: false),
                        TermsAndConditions_Condition3 = c.Boolean(nullable: false),
                        TermsAndConditions_Condition4 = c.Boolean(nullable: false),
                        TermsAndConditions_Condition5 = c.Boolean(nullable: false),
                        TermsAndConditions_Condition6 = c.Boolean(nullable: false),
                        TermsAndConditions_Condition7 = c.Boolean(nullable: false),
                        TermsAndConditions_Condition8 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExerciseTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SoapNoteModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 0),
                        ClientId = c.Int(nullable: false),
                        ClientName = c.String(unicode: false),
                        Feedback = c.String(unicode: false),
                        GoalOrExpectations = c.String(unicode: false),
                        ContributingFactorsToCondition = c.String(unicode: false),
                        PreMassagePalpatation = c.String(unicode: false),
                        PressureScaleRequired = c.String(unicode: false),
                        SessionPlan = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SessionNoteModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionAreaMuscle = c.String(unicode: false),
                        Techniques = c.String(unicode: false),
                        Findings = c.String(unicode: false),
                        SoapNoteModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SoapNoteModels", t => t.SoapNoteModel_Id)
                .Index(t => t.SoapNoteModel_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Email = c.String(maxLength: 256, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ExerciseTypeClients",
                c => new
                    {
                        ExerciseType_Id = c.Int(nullable: false),
                        Client_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExerciseType_Id, t.Client_Id })
                .ForeignKey("dbo.ExerciseTypes", t => t.ExerciseType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .Index(t => t.ExerciseType_Id)
                .Index(t => t.Client_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SessionNoteModels", "SoapNoteModel_Id", "dbo.SoapNoteModels");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ExerciseTypeClients", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.ExerciseTypeClients", "ExerciseType_Id", "dbo.ExerciseTypes");
            DropIndex("dbo.ExerciseTypeClients", new[] { "Client_Id" });
            DropIndex("dbo.ExerciseTypeClients", new[] { "ExerciseType_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SessionNoteModels", new[] { "SoapNoteModel_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.ExerciseTypeClients");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SessionNoteModels");
            DropTable("dbo.SoapNoteModels");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ExerciseTypes");
            DropTable("dbo.Clients");
        }
    }
}
