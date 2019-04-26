using API.Db.Model;
using API.DbFactory.Interfaces;
using API.Repository.Interfaces;

namespace API.Repository.Classes
{
    public class GenericRepository : IGenericRepository
    {
        private LicentaEntities dbContext;

        protected IDbFactory DbFactory {
            get;
            private set;
        }

        public GenericRepository(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
        }

        public GenericRepository(LicentaEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        protected LicentaEntities DbContext {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }


        public void Dispose()
        {
            this.dbContext.Dispose();
        }

        public int SaveChanges()
        {
            if (this.dbContext != null)
            {
                return this.dbContext.SaveChanges();
            }
            return 0;
        }
    }
}
