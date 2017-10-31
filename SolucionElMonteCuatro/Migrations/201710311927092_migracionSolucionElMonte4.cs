namespace SolucionElMonteCuatro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionSolucionElMonte4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CondenaDelitos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Condena = c.Int(nullable: false),
                        CondenaId_Id = c.Int(),
                        DelitoId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Condenas", t => t.CondenaId_Id)
                .ForeignKey("dbo.Delitos", t => t.DelitoId_Id)
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
                .ForeignKey("dbo.Jueces", t => t.JuezId_Id)
                .ForeignKey("dbo.Presos", t => t.PresoID_Id)
                .Index(t => t.JuezId_Id)
                .Index(t => t.PresoID_Id);
            
            CreateTable(
                "dbo.Jueces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Rut = c.String(),
                        Domicilio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Presos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rut = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Domicilio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Delitos",
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
            DropForeignKey("dbo.CondenaDelitos", "DelitoId_Id", "dbo.Delitos");
            DropForeignKey("dbo.CondenaDelitos", "CondenaId_Id", "dbo.Condenas");
            DropForeignKey("dbo.Condenas", "PresoID_Id", "dbo.Presos");
            DropForeignKey("dbo.Condenas", "JuezId_Id", "dbo.Jueces");
            DropIndex("dbo.Condenas", new[] { "PresoID_Id" });
            DropIndex("dbo.Condenas", new[] { "JuezId_Id" });
            DropIndex("dbo.CondenaDelitos", new[] { "DelitoId_Id" });
            DropIndex("dbo.CondenaDelitos", new[] { "CondenaId_Id" });
            DropTable("dbo.Delitos");
            DropTable("dbo.Presos");
            DropTable("dbo.Jueces");
            DropTable("dbo.Condenas");
            DropTable("dbo.CondenaDelitos");
        }
    }
}
