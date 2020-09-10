using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EasyFixMVC.Models;

namespace EasyFixMVC.DAL 
{   //constructor
    public class EasyFixContext : DbContext {
        public EasyFixContext(DbContextOptions<EasyFixContext> options) : base(options) {}
        
        public DbSet<FaultCode> FaultCodes { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}