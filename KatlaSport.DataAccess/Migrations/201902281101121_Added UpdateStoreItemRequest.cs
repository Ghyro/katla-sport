namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// AddedUpdateStoreItemRequest for Database
    /// </summary>
    public partial class AddedUpdateStoreItemRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.product_store_items", "product_store_item_is_confirmed", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.product_store_items", "product_store_item_is_confirmed");
        }
    }
}
