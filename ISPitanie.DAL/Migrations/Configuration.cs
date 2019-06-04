namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;
    using DAL.DTO;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.PitanieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.PitanieContext context)
        {
            UnitDTO[] units = new[]
            {
                new UnitDTO()
                {
                    Id = 1,
                    Name = "דנאלל"
                }
            };

            context.Units.AddOrUpdate(units);
            context.SaveChanges();
        }
    }
}