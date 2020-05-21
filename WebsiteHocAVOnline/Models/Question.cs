using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteHocAVOnline.Models
{
    public class Question
    {
        DBThiTrucTuyenEntities db = null;

        public Question()
        {
            db = new DBThiTrucTuyenEntities();
        }

        public IEnumerable<CauHoi> NumberPagePagination(int page, int pageSize)
        {
            return db.CauHois.OrderByDescending(model => model.IDCauHoi).ToList().ToPagedList(page, pageSize);
        }
    }
}