namespace SellPhones.Celulares.Data.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoMarca : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Celular",
                c => new
                    {
                        IdCelular = c.Int(nullable: false, identity: true),
                        Modelo = c.String(nullable: false, maxLength: 50),
                        IdMarca = c.Int(nullable: false),
                        Cor = c.String(nullable: false, maxLength: 30),
                        Preco = c.Single(nullable: false),
                        Imei = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.IdCelular)
                .ForeignKey("dbo.Marca", t => t.IdMarca, cascadeDelete: true)
                .Index(t => t.IdMarca);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Celular", "IdMarca", "dbo.Marca");
            DropIndex("dbo.Celular", new[] { "IdMarca" });
            DropTable("dbo.Marca");
            DropTable("dbo.Celular");
        }
    }
}
