using FluentMigrator;

namespace HoA.DBMigration
{
    [Migration(1)]
    public class Customer : Migration
    {
        private HoA.Entity.Customer customer = new Entity.Customer();
        public override void Up()
        {
            Create.Table(customer.GetType().Name)
                .WithColumn("ID").AsInt32().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(100)
                .WithColumn("LastName").AsString(100)
                .WithColumn("AddressLine1").AsString(500)
                .WithColumn("AddressLine2").AsString(500)
                .WithColumn("City").AsString(100)
                .WithColumn("State").AsString(100)
                .WithColumn("Country").AsString(100)
                .WithColumn("PostalCode").AsString(10);
        }

        public override void Down()
        {
            Delete.Table(customer.GetType().Name);
        }
    }
}
