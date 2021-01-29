﻿using Microsoft.EntityFrameworkCore;
using SteelDaily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteelDaily.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Tuning> Tuning { get; set; }
        public DbSet<Scale> Scale { get; set; }
        public DbSet<Key> Key { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<MusicTheory> MusicTheory { get; set; }
        public Result Result { get; set; }
    }
}
