using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteHocAVOnline.Models
{
    public class Learnning
    {

        DBThiTrucTuyenEntities db = null;

        public Learnning()
        {
            db = new DBThiTrucTuyenEntities();
        }

        public IEnumerable<Learning> NumberPagePagination(int page, int pageSize)
        {
            return db.Learnings.OrderByDescending(model => model.ID_BaiHoc).ToList().ToPagedList(page, pageSize);
        }

    }
}