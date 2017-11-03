namespace SolucionElMonteCuatro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationElMonteCuatross : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CondenaDelitoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CondenaID = c.Int(nullable: false),
                        DelitoID = c.Int(),
                        Condena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Condenas", t => t.CondenaID, cascadeDelete: true)
                .ForeignKey("dbo.Delitoes", t => t.DelitoID)
                .Index(t => t.CondenaID)
                .Index(t => t.DelitoID);
            
            CreateTable(
                "dbo.Condenas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicioCondena = c.DateTime(nullable: false),
                        FechaCondena = c.DateTime(nullable: false),
                        PresoID = c.Int(),
                        JuezId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Juezs", t => t.JuezId)
                .ForeignKey("dbo.Presoes", t => t.PresoID)
                .Index(t => t.PresoID)
                .Index(t => t.JuezId);
            
            CreateTable(
                "dbo.Juezs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Rut = c.String(),
                        Sexo = c.Int(nullable: false),
                        Domicilio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Presoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rut = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Domicilio = c.String(),
                        Sexo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Delitoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        CondenaMinima = c.Int(nullable: false),
                        CondenaMaxima = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CondenaDelitoes", "DelitoID", "dbo.Delitoes");
            DropForeignKey("dbo.Condenas", "PresoID", "dbo.Presoes");
            DropForeignKey("dbo.Condenas", "JuezId", "dbo.Juezs");
            DropForeignKey("dbo.CondenaDelitoes", "CondenaID", "dbo.Condenas");
            DropIndex("dbo.Condenas", new[] { "JuezId" });
            DropIndex("dbo.Condenas", new[] { "PresoID" });
            DropIndex("dbo.CondenaDelitoes", new[] { "DelitoID" });
            DropIndex("dbo.CondenaDelitoes", new[] { "CondenaID" });
            DropTable("dbo.Delitoes");
            DropTable("dbo.Presoes");
            DropTable("dbo.Juezs");
            DropTable("dbo.Condenas");
            DropTable("dbo.CondenaDelitoes");
        }
    }
}
