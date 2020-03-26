using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TranscriptMgt.Controllers
{
    public class OnlineResultController : Controller
    {
        private TranscriptDbEntities db = new TranscriptDbEntities();
        // GET: OnlineResult
        public ActionResult GetResult()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetResult(string regnumber)
        {
            Session["Message"] = string.Empty;
            var std = db.StudentTables.Where(m => m.Reg_No == regnumber.Trim()).FirstOrDefault();
            var checkmarks = db.MarkSheetTables.Where(m => m.StudentID == std.StudentID).FirstOrDefault();
            if(checkmarks != null)
            {
              return RedirectToAction("GetTranscript", "Transcripts",new { regno = regnumber });
            }
            Session["Message"] = "Record Not found";
            return View();
        }
    }
}