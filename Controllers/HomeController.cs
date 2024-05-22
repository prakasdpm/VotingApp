using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VotingApp.Repository;

namespace VotingApp.Controllers
{
    public class HomeController : Controller
    {
        VoterRepository voterRepository = new VoterRepository();
        CandidateRepository candidateRepository = new CandidateRepository();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetHomePageData()
        {
            var voters = voterRepository.SelectVoterList();
            var candidates = candidateRepository.SelectCandidateList();
            var nonVoters = voterRepository.SelectNonVoters();
            return Json(new { voters, candidates, nonVoters });
        }

        [HttpPost]
        public JsonResult AddData(string type, string name)
        {
            dynamic lst;
            if(type == "voter")
            {
                voterRepository.InsertVoterList(name);
                lst = voterRepository.SelectVoterList();
            }
            else
            {
                candidateRepository.InsertCandidateList(name);
                lst = candidateRepository.SelectCandidateList();
            }
            return Json(new { lst });
        }

        [HttpPost]
        public JsonResult AddVote(string candidateId, string voterId)
        {
            voterRepository.VoteToCandidate(Convert.ToInt32(voterId));
            candidateRepository.IncreaseVote(Convert.ToInt32(candidateId));
            return Json(new { data = "Success" });
        }

        [HttpPost]
        public JsonResult GetNonVoters()
        {
            var nonVoters = voterRepository.SelectNonVoters();
            return Json(new { nonVoters });
        }

        [HttpPost]
        public JsonResult GetCandidates()
        {
            var candidates = candidateRepository.SelectCandidateList();
            return Json(new { candidates });
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}