using EntityLayer.MemberShip;
using EntityLayer.Reservation;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //public DbSet<Author> Authors { get; set; }
        //public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles{ get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<SubReservation> SubReservations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Statu> Status { get; set; }
        public DbSet<Transition> Transitions { get; set; }
        public DbSet<TransitionHistoric> TransitionHistorics { get; set; }
    }
}