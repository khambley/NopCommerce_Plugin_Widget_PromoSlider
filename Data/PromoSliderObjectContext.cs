using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Data;

namespace Nop.Plugin.Widget.PromoSlider.Data
{
    public class PromoSliderObjectContext : DbContext, IDbContext
    {
        public bool ProxyCreationEnabled
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool AutoDetectChangesEnabled
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public PromoSliderObjectContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PromoSliderMap());
            modelBuilder.Configurations.Add(new PromoImageMap());
            base.OnModelCreating(modelBuilder);
        }
        //like dbContext, it creates a SQL script to create the tables
        public string CreateDatabaseInstallationScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }
        public void Install()
        {
            Database.SetInitializer<PromoSliderObjectContext>(null);
            Database.ExecuteSqlCommand(CreateDatabaseInstallationScript());
            SaveChanges();
        }
        //This method is used in case we delete the Slider plugin, drops the tables, same for schema changes
        public void Uninstall()
        {
            this.DropPluginTable("PromoSlider_PromoImages");
            this.DropPluginTable("PromoSlider_PromoSliders");
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            //change this to...for repository
            return base.Set<TEntity>();
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = default(int?), params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Detach(object entity)
        {
            throw new NotImplementedException();
        }
    }
}
