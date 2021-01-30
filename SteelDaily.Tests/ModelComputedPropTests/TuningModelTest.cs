using System;
using Xunit;
using SteelDaily.Models;

namespace SteelDaily.Tests
{
    public class TuningModelTest
    {
        [Fact]
        public void Computed_Fretboard_At_Zero_Should_Match_Notes()
        {
            var TestTuning = new Tuning()
            { 
                Id = 1, 
                Name = "E9", 
                Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb" 
            };
            
            string stringTen = TestTuning.Notes.Split(',', ' ')[0];
            //Assert.Equal("B", stringTen);
            Assert.Equal(stringTen, TestTuning.Fretboard[0][0].ToString());


        }
        [Fact]
        public void Computed_Fretboard_At_One_One_Should_Be_Zero_One_Plus_One()
        {
            var TestTuning = new Tuning()
            {
                Id = 1,
                Name = "E9",
                Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb"
            };

            string stringTen = TestTuning.Notes.Split(',', ' ')[0];
            Assert.Equal("Eb", TestTuning.Fretboard[1][1].ToString());


        }
        [Fact]
        public void Computed_Fretboard_At_One_Zero_Should_Be_Zero_Zero_Plus_One()
        {
            //the tests turning the corner from 12 to 1 or B to C
            var TestTuning = new Tuning()
            {
                Id = 1,
                Name = "E9",
                Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb"
            };

            string stringTen = TestTuning.Notes.Split(',', ' ')[0];
            Assert.Equal("C", TestTuning.Fretboard[1][0].ToString());
        }
        [Fact]
        public void Computed_Fretboard_At_One_Zero_Should_Be_Thirteen_Zero()
        {
            //the tests turning the corner from 12 to 1 or B to C
            var testTuning = new Tuning()
            {
                Id = 1,
                Name = "E9",
                Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb"
            };

            string stringTen = testTuning.Notes.Split(',', ' ')[0];
            Assert.Equal("C", testTuning.Fretboard[13][0].ToString());
        }
        [Fact]
        public void Computed_Fretboard_At_One_Nine_Should_Be_Thirteen_Nine()
        {
            //the tests turning the corner from 12 to 1 or B to C
            var testTuning = new Tuning()
            {
                Id = 1,
                Name = "E9",
                Notes = "B,D,E,Gb,Ab,B,E,Ab,Eb,Gb"
            };
            string stringTen = testTuning.Notes.Split(',', ' ')[0];
            Assert.Equal("E", testTuning.Fretboard[13][8].ToString());
        }
    }
}