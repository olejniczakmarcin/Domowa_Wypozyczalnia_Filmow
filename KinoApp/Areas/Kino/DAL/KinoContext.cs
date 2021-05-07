using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using KinoApp.Areas.Kino.Models;
using System.Linq.Expressions;
using KinoApp.Areas.Kino.Data;

namespace KinoApp.Areas.Kino.DAL
{
    public class KinoContext : DbContext
    {
        public KinoContext() : base("KinoAPPEntities")
        { 
        }

        public DbSet<Users> UserBase { get; set; }
        public DbSet<Employee> EmployBase { get; set; }

        public DbSet<MovieDescription> movieDesc { get; set; }
        public DbSet<UsersMovie> usersMovies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
        public Users GetUsers(Expression<Func<Users, bool>> func)
        {
            return UserBase.Where(func).FirstOrDefault();
        }

        public IQueryable<MovieDescription> GetMovieDescription(Expression<Func<MovieDescription, bool>> func)
        {
            return movieDesc.Where(func);
        }

        public int CountMovieDescription()
        {
            return movieDesc.Count(x => x.MovieId > 0);
        }

        public  int CountUsersMovie()
        {
            return usersMovies.Count(x => x.MovieId > 0);
        }

        public IQueryable<UsersMovie> GetUsersMovies(Expression<Func<UsersMovie, bool>> func)
        {
            return usersMovies.Where(func);
        }
        public void AddUsers(Users newUser)
        {
            UserBase.Add(newUser);
            SaveChanges();
        }

        public int CountUsers()
        {
            return UserBase.Where(x => x.UserId > 0).Count();
        }

        public string[] LogginData(string login, string pass)
        {
            string[] tmpTab = { string.Empty, string.Empty, string.Empty };
            
            var user = UserBase.Where(x => x.Login == login || x.Password == pass).FirstOrDefault();
            if (user != null && user.Password == pass && user.Login == login)
            {
                tmpTab[0] = user.Login;
                tmpTab[1] = user.Password;
                tmpTab[2] = user.UserId.ToString();
                return tmpTab;
            }
            if (user != null && user.Password != pass && user.Login == login)
            {
                tmpTab[0] = user.Login;
                return tmpTab;
            }
            if (user != null && user.Password == pass && user.Login != login)
            {
                tmpTab[1] = user.Password;
                return tmpTab;
            }

            return tmpTab;

        }

        public MovieDescription GetOneMovieDescription(int id)
        {
            return movieDesc.Where(x => x.MovieId == id).FirstOrDefault();
        }
    }
}