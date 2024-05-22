using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VotingApp.Models;

namespace VotingApp.Repository
{
    public static class VoterList
    {
        static List<Voter> voterList = null;
        static VoterList()
        {
            voterList = new List<Voter>();
        }

        public static List<Voter> SelectVoterList()
        {
            return voterList;
        }

        public static List<Voter> SelectNonVoters()
        {
            return voterList.Where(v => v.HasVoted == false).ToList();
        }

        public static void InsertVoterList(string voterName)
        {
            Voter voter = new Voter();
            var highestId = voterList.Any() ? voterList.Max(x => x.Id) : 1;
            voter.Id = highestId + 1;
            voter.Name = voterName;
            voter.HasVoted = false;
            voterList.Add(voter);
        }

        public static void VoteToCandidate(int voterId)
        {
            var voter = SelectVoterList().Where(v => v.Id == voterId).FirstOrDefault();
            if (voter != null)
            {
                voter.HasVoted = true;
            }
        }
    }
}