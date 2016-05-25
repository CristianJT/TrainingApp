namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 80),
                        Elemento = c.Int(nullable: false),
                        Descripcion = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkoutMovements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkoutId = c.Int(nullable: false),
                        MovementId = c.Int(nullable: false),
                        Repeticiones = c.Int(nullable: false),
                        PesoEjecutado = c.Single(),
                        PesoAlternativo1 = c.Single(),
                        Distancia = c.Decimal(precision: 18, scale: 2),
                        Altura = c.Decimal(precision: 18, scale: 2),
                        Restriccion = c.Boolean(nullable: false),
                        RestriccionTipo = c.String(),
                        Adaptacion = c.Boolean(nullable: false),
                        AdaptacionTipo = c.String(),
                        Minuto = c.Int(),
                        Completo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movements", t => t.MovementId, cascadeDelete: true)
                .ForeignKey("dbo.Workouts", t => t.WorkoutId, cascadeDelete: true)
                .Index(t => t.WorkoutId)
                .Index(t => t.MovementId);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(nullable: false),
                        Nombre = c.String(maxLength: 50),
                        Fecha = c.DateTime(nullable: false),
                        TiempoMaximoMinuto = c.Int(nullable: false),
                        TiempoMaximoSegundo = c.Int(nullable: false),
                        Rx = c.Single(),
                        Rondas = c.Int(),
                        VueltasCompletas = c.Int(),
                        RepeticionesExtra = c.Int(),
                        RondasGrupoEjercicio = c.Int(),
                        TiempoFinalizacionMinuto = c.Int(),
                        TiempoFinalizacionSegundo = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Fecha);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkoutMovements", "WorkoutId", "dbo.Workouts");
            DropForeignKey("dbo.WorkoutMovements", "MovementId", "dbo.Movements");
            DropIndex("dbo.Workouts", new[] { "Fecha" });
            DropIndex("dbo.WorkoutMovements", new[] { "MovementId" });
            DropIndex("dbo.WorkoutMovements", new[] { "WorkoutId" });
            DropTable("dbo.Workouts");
            DropTable("dbo.WorkoutMovements");
            DropTable("dbo.Movements");
        }
    }
}
