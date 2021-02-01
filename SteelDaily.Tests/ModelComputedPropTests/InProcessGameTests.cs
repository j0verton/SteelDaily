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
                Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb"
            };
            var Result1 = new Result()
            {
                Id = 1,
                Key = "C",
                TuningId = 1,
                Tuning = TestTuning,
                Questions = "11,2,8,8,7,4,18,5",
                Answers = "2,1,b7,4"
            };
            ////ans = D/2
            //Result1.Questions.Add(new List<int> { 11, 2 });
            ////ans = C/1
            //Result1.Questions.Add(new List<int> { 8, 8 });
            ////ans = B/b7
            //Result1.Questions.Add(new List<int> { 7, 4 });
            ////ans = F/4
            //Result1.Questions.Add(new List<int> { 18, 5 });

            var Game = new InProcessGame()
            {
                Result = Result1
            };


            Assert.Equal("4", Game.AnswerList.LastOrDefault());

        }
    }
}
