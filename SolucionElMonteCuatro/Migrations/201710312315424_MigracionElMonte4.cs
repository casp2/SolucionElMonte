namespace SolucionElMonteCuatro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionElMonte4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CondenaDelitoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Condena = c.Int(nullable: false),
                        CondenaId_Id = c.Int(),
                        DelitoId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Condenas", t => t.CondenaId_Id)
                .ForeignKey("dbo.Delitoes", t => t.DelitoId_Id)
                .Index(t => t.CondenaId_Id)
                .Index(t => t.DelitoId_Id);
            
            CreateTable(
                "dbo.Condenas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicioCondena = c.DateTime(nullable: false),
                        FechaCondena = c.DateTime(nullable: false),
                        JuezId_Id = c.Int(),
                        PresoID_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Juezs", t => t.JuezId_Id)
                .ForeignKey("dbo.Presoes", t => t.PresoID_Id)
                .Index(t => t.JuezId_Id)
                .Index(t => t.PresoID_Id);
            
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
            DropForeignKey("dbo.CondenaDelitoes", "DelitoId_Id", "dbo.Delitoes");
            DropForeignKey("dbo.CondenaDelitoes", "CondenaId_Id", "dbo.Condenas");
            DropForeignKey("dbo.Condenas", "PresoID_Id", "dbo.Presoes");
            DropForeignKey("dbo.Condenas", "JuezId_Id", "dbo.Juezs");
            DropIndex("dbo.Condenas", new[] { "PresoID_Id" });
            DropIndex("dbo.Condenas", new[] { "JuezId_Id" });
            DropIndex("dbo.CondenaDelitoes", new[] { "DelitoId_Id" });
            DropIndex("dbo.CondenaDelitoes", new[] { "CondenaId_Id" });
            DropTable("dbo.Delitoes");
            DropTable("dbo.Presoes");
            DropTable("dbo.Juezs");
            DropTable("dbo.Condenas");
            DropTable("dbo.CondenaDelitoes");
        }
    }
}
