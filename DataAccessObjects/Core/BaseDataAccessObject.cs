using GoldenLotteryAPI.Core;
using GoldenLotteryAPI.ModelFilters.Core;
using GoldenLotteryAPI.Models.Core;

namespace GoldenLotteryAPI.DataAccessObjects.Core
{
    public class BaseDataAccessObject<T, F, I> : IDataAccessObject<T, F, I> where T : BaseModel where F : BaseModelFilter
    {
        public MySQLContext<T> MySQLConnection { get; set; } = new MySQLContext<T>();

        public virtual void Insert(T model)
        {
            using var context = MySQLConnection;
            context.Table.Add(model);
            context.SaveChanges();
        }

        public virtual void Update(T model)
        {
            using var context = MySQLConnection;
            context.Table.Update(model);
            context.SaveChanges();
        }

        public virtual void Delete(I id)
        {
            using var context = MySQLConnection;
            context.Table.Remove(context.Table.Find(id) ?? throw new RegisterNotFoundException());
            context.SaveChanges();
        }

        public virtual List<T> ListByFilter(F filter)
        {
            using var context = MySQLConnection;
            return [.. (from t in context.Table select t).OrderByDescending(x => x.DateInserted).Skip((filter.RecordsPerPage * filter.Page) - filter.RecordsPerPage).Take(filter.RecordsPerPage)];
        }

        public virtual T GetById(I id)
        {
            using var context = MySQLConnection;
            return context.Table.Find(id) ?? throw new RegisterNotFoundException();
        }
    }
}
