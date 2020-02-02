using FluentMigrator;
namespace HoA.DBMigration
{
    [Migration(2)]
    public class Order : Migration
    {
        private Entity.Order order = new Entity.Order();
        public override void Up()
        {
            Create.Table(order.GetType().Name)
                .WithColumn("ID").AsInt32().PrimaryKey().Identity()
                .WithColumn("ProductId").AsInt32()
                .WithColumn("CustomerId").AsInt32();
        }

        public override void Down()
        {
            Delete.Table(order.GetType().Name);
        }
    }
}
