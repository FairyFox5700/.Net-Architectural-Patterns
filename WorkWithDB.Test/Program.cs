﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Api.Models.Requests;
using WorkWithDB.DAL.Abstract;

using WorkWithDB.DAL.Rest;
using WorkWithDB.DAL.Rest.Repository;
using WorkWithDB.DAL.SqlServer;
using WorkWithDB.Entity;

namespace WorkWithDB.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (IUnitOfWork scope = new SqlServerAdoNetUnitOfWork())
            //{
            //    var id = scope.BlogUserRepository.Insert(new BlogUser() { Name = "Bogdan", Nick = "winnie2", UserPassword = "!QAZ2wsx#EDC4rfv" });
            //    var allUsers = scope.BlogUserRepository.GetAll();
            //     id = allUsers.Select(u => u.Id).FirstOrDefault();
            //    var user = scope.BlogUserRepository.GetById(id);

            //    scope.Commit();
            //}
            using (RestUnitOfWork scope = new RestUnitOfWork())
            {
                //scope.AuthRepository.Register(new RegisterModel()
                //{
                //    Name = "Vasya Pupkin",
                //    Nick = "Vasya",
                //    Password = "qwerty"
                //});
                var user = scope.AuthRepository.Login( "user","qwerty");

                var posts = scope.BlogPostRepository.GetAllWithUserNick();
            }
        }
    }
}
