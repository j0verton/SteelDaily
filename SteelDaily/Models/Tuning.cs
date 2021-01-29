﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Models
{
    public class Tuning : MusicTheory
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Notes { get; set; }


        public List<List<ChromaticScale>> Fretboard 
        {
            get {
                List<List<ChromaticScale>> fretboard = new List<List<ChromaticScale>>();
                List<string> fretZeroString = Notes.Split(',').ToList();
                var fretZero = new List<ChromaticScale>();
                foreach (string noteString in fretZeroString)
                {
                    fretZero.Add((ChromaticScale)Enum.Parse(typeof(ChromaticScale), noteString));
                }
                Fretboard.Add(fretZero);
                for (var i = 0; i < 22; i++)
                {
                    var fret = new List<ChromaticScale>();
                    foreach (ChromaticScale note in Fretboard[i])
                    {
                        ChromaticScale newNote = note + 1;
                        if (Convert.ToInt32(newNote) == 13)
                        {
                            newNote = (ChromaticScale)1;
                        }
                        fret.Add(newNote);
                    };
                    fretboard.Add(fret);
                }
                return Fretboard;
            }
        }


    }
}