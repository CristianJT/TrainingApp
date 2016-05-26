namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkoutMovements", "PesoAlternativo", c => c.Single());
            AddColumn("dbo.WorkoutMovements", "RondaNumero", c => c.Int());
            AddColumn("dbo.WorkoutMovements", "MinutoNumero", c => c.Int());
            DropColumn("dbo.WorkoutMovements", "PesoAlternativo1");
            DropColumn("dbo.WorkoutMovements", "Minuto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkoutMovements", "Minuto", c => c.Int());
            AddColumn("dbo.WorkoutMovements", "PesoAlternativo1", c => c.Single());
            DropColumn("dbo.WorkoutMovements", "MinutoNumero");
            DropColumn("dbo.WorkoutMovements", "RondaNumero");
            DropColumn("dbo.WorkoutMovements", "PesoAlternativo");
        }
    }
}
