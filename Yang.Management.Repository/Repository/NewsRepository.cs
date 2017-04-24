using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Management.Entity;
using Yang.Management.Entity.DataEntity;
using Yang.Management.Entity.ViewEntity;

namespace Yang.Management.Repository.Repository
{
    public class NewsRepository : INewsRepository
    {
        public DataContext context = new DataContext();
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public int Delete(string[] ids)
        {
            List<News> list = this.context.News.Where(c => ids.Any(b => b.Equals(c.Id))).ToList();
            this.context.News.RemoveRange(list);
            this.context.SaveChanges();
            return 1;
        }

        public List<NewsEntity> GetAllList()
        {
            return this.context.News.Select(c => new NewsEntity { Title = c.Title, Id = c.Id }).ToList();
        }

        public NewsDetailEntity GetDetail(string id)
        {
            BaseQuery query = new BaseQuery("SELECT Id,Title,Contents,Description,CreateTime,CreateUserId,(Select name from UserInfo where Id = nw.CreateUserId) as CreateUserName FROM News as nw where Id=@id", new { id = id });
            return DapperContext.BaseGetByParam<NewsDetailEntity>(query);
        }

        public News GetItem(string id)
        {
            return this.context.News.Where(c => c.Id.Equals(id)).FirstOrDefault();
        }

        public ListEntity<NewsEntity> GetList(string key, int pageIndex, int pageSize)
        {
            List<NewsEntity> list = new List<NewsEntity>();
            int total = this.context.News.Where(c => c.Title.Contains(key)).Count();
            if (total <= 0)
            {
                return new ListEntity<NewsEntity>(list, total, pageIndex, pageSize);
            }

            list = this.context.News.Where(c => c.Title.Contains(key)).OrderBy(c => c.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(c => new NewsEntity {Id=c.Id,Title=c.Title,Description=c.Description,Type=c.NewsTypeId,CreateTime=c.CreateTime.Value.ToString() }).ToList();

            return new ListEntity<NewsEntity>(list, total, pageIndex, pageSize);
        }

        public ListEntity<NewsEntity> GetListByType(string type, int pageIndex, int pageSize)
        {
            List<NewsEntity> list = new List<NewsEntity>();
            int total = this.context.News.Where(c => c.NewsTypeId.Contains(type)).Count();
            if (total <= 0)
            {
                return new ListEntity<NewsEntity>(list, total, pageIndex, pageSize);
            }

            list = this.context.News.Where(c => c.NewsTypeId.Contains(type)).OrderBy(c => c.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(c => new NewsEntity { Id = c.Id, Title = c.Title, Description = c.Description, Type = c.NewsTypeId, CreateTime = c.CreateTime.Value.ToString() }).ToList();

            return new ListEntity<NewsEntity>(list, total, pageIndex, pageSize);
        }

        public void Save(News entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            var dbclass = this.context.News.Where(c => c.Id == entity.Id).FirstOrDefault();
            if (dbclass == null)
            {
                dbclass = new News();
                dbclass.Id = Guid.NewGuid().ToString();
                this.context.News.Add(dbclass);
            }

            dbclass.CreateTime = entity.CreateTime == null ? dbclass.CreateTime : entity.CreateTime;
            dbclass.CreateUserId = entity.CreateUserId == null ? dbclass.CreateUserId : entity.CreateUserId;
            dbclass.Title = entity.Title == null ? dbclass.Title : entity.Title;
            dbclass.Description = entity.Description == null ? dbclass.Description : entity.Description;
            dbclass.NewsTypeId = entity.NewsTypeId == null ? dbclass.NewsTypeId : entity.NewsTypeId;
            dbclass.Contents = entity.Contents == null ? dbclass.Contents : entity.Contents;

            this.context.SaveChanges();
        }
    }
}
