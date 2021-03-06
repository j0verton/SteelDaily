﻿using System;
using Xunit;
using SteelDaily.Models;
using SteelDaily.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace SteelDaily.Tests
{
    public class InProcessGameTests
    {
        [Fact]
        public void Correct_Answer_Should_Create_Correct_Outcome()
        {
            var TestTuning = new Tuning()
            {
                Id = 1,
                Name = "E9",
                Notes = "Gb,Eb,Ab,E,B,Ab,Gb,E,D,B"
            };
            var Result1 = new Result()
            {
                Id = 1,
                TuningId = 1,
                Tuning = TestTuning,
                Questions = "11,1,8,7,7,3,15,5",
                Answers = "Two,One,FlatSeven,Two"
            };
            //these answers are all off b/c not accouting for 0 index in the second value... 2 is string 3
            ////ans = D/2
            //Result1.Questions.Add(new List<int> { 11, 2 });
            ////ans = C/1
            //Result1.Questions.Add(new List<int> { 8, 8 });
            ////ans = B/b7
            //Result1.Questions.Add(new List<int> { 7, 4 });
            ////ans = E/3
            //Result1.Questions.Add(new List<int> { 15, 5 });

            var Game = new InProcessGame()
            {
                Result = Result1
            };

            Assert.True(Game.Outcomes[0]);
            //Assert.True(Game.Outcomes[1]);
            //Assert.True(Game.Outcomes[2]);
            //Assert.True(Game.Outcomes[3]);

        }
    }
}
