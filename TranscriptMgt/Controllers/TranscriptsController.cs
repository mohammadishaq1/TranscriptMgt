using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranscriptMgt.Models;

namespace TranscriptMgt.Controllers
{
    public class TranscriptsController : Controller
    {
        // GET: Transcripts
        public ActionResult GetTranscript()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetTranscript(int? id)
        {
            TranscriptMV transcript = new TranscriptMV();
            return View();
        }
    }
}