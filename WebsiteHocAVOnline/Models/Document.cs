using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteHocAVOnline.Models
{
    public class Document
    {

        DBThiTrucTuyenEntities db = null;

        public Document()
        {
            db = new DBThiTrucTuyenEntities();
        }

        public IEnumerable<TaiLieu> NumberPagePagination(int page, int pageSize)
        {
            return db.TaiLieux.OrderByDescending(model => model.IDTaiLieu).ToList().ToPagedList(page, pageSize);
        }

    }
}