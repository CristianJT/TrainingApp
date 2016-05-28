namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkoutMovements", "MovimientoAlternativo", c => c.String());
            AddColumn("dbo.WorkoutMovements", "Unbroken", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkoutMovements", "Detalle", c => c.String());
            AddColumn("dbo.Workouts", "SubTipo", c => c.Int(nullable: false));
            AddColumn("dbo.Workouts", "GrupoTipo", c => c.Int(nullable: false));
            AddColumn("dbo.Workouts", "Detalle", c => c.String());
            AlterColumn("dbo.Workouts", "RepeticionesExtra", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workouts", "RepeticionesExtra", c => c.Int());
            DropColumn("dbo.Workouts", "Detalle");
            DropColumn("dbo.Workouts", "GrupoTipo");
            DropColumn("dbo.Workouts", "SubTipo");
            DropColumn("dbo.WorkoutMovements", "Detalle");
            DropColumn("dbo.WorkoutMovements", "Unbroken");
            DropColumn("dbo.WorkoutMovements", "MovimientoAlternativo");
        }
    }
}
