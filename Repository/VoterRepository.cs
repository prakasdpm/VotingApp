using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VotingApp.Models;

namespace VotingApp.Repository
{
    public class VoterRepository
    {
        public List<Voter> SelectVoterList()
        {
            return VoterList.SelectVoterList();
        }

        public void InsertVoterList(string voterName)
        {
            VoterList.InsertVoterList(voterName);
        }

        public void VoteToCandidate(int voterId)
        {
            VoterList.VoteToCandidate(voterId);
        }

        public List<Voter> SelectNonVoters()
        {
           return VoterList.SelectNonVoters();
        }
    }
}