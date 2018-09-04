namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Markets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aerolinea = c.String(),
                        Date = c.String(),
                        OriginCode = c.String(),
                        DestinationCode = c.String(),
                        OriginName = c.String(),
                        DestinationName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Markets");
        }
    }
}
