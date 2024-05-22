using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VotingApp.Models;

namespace VotingApp.Repository
{
    public class CandidateRepository
    {
        public List<Candidate> SelectCandidateList()
        {
            return CandidateList.SelectCandidateList();
        }

        public void InsertCandidateList(string candidateName)
        {
            CandidateList.InsertCandidateList(candidateName);
        }

        public void IncreaseVote(int candidateId)
        {
            CandidateList.IncreaseVote(candidateId);
        }
    }
}