﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingApp.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
    }
}