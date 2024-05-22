using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VotingApp.Models;

namespace VotingApp.Repository
{
    public static class CandidateList
    {
        static List<Candidate> candidateList = null;
        static CandidateList()
        {
            candidateList = new List<Candidate>();
        }

        public static List<Candidate> SelectCandidateList()
        {
            return candidateList;
        }

        public static void InsertCandidateList(string candidateName)
        {
            Candidate candidate = new Candidate();
            var highestId = candidateList.Any() ? candidateList.Max(x => x.Id) : 1;
            candidate.Id = highestId + 1;
            candidate.Name = candidateName;
            candidate.Votes = 0;
            candidateList.Add(candidate);
        }

        public static void IncreaseVote(int candidateId)
        {
            var candidate = SelectCandidateList().Where(v => v.Id == candidateId).FirstOrDefault();
            if (candidate != null)
            {
                candidate.Votes += 1;
            }
        }
    }
}