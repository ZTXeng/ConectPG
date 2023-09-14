using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkPG
{
    [DbConfigurationType(typeof(Configuration))]

    public class MyDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(p => p.Version)
                    .HasColumnName("xmin")
                    .HasColumnType("text")
                    .IsConcurrencyToken()
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            base.OnModelCreating(modelBuilder);
        }
    }

    internal class Configuration : DbConfiguration
    {
        public Configuration()
        {
            SetMigrationSqlGenerator("Npgsql", () => new SqlGenerator());
        }
    }

    public class SqlGenerator : NpgsqlMigrationSqlGenerator
    {
        private readonly string[] systemColumnNames = { "oid", "tableoid", "xmin", "cmin", "xmax", "cmax", "ctid" };

        protected override void Convert(CreateTableOperation createTableOperation)
        {
            var systemColumns = createTableOperation.Columns.Where(x => systemColumnNames.Contains(x.Name)).ToArray();
            foreach (var systemColumn in systemColumns)
                createTableOperation.Columns.Remove(systemColumn);
            base.Convert(createTableOperation);
        }
    }
}
