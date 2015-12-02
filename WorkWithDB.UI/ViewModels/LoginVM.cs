﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using JetBrains.Annotations;
using WorkWithDB.DAL.Abstract;

namespace WorkWithDB.UI.ViewModels
{
    public class LoginVM
    {
        public String Login { get; set; }


        public PasswordBox Password
        {
            get;
            set;
        }

        public RelayCommand OkCommand
        {
            get
            {
                return new RelayCommand(
                    (_) =>
                    {
                        var login = Login;
                        var password = Password.Password;

                        using (var uow = UnitOfWorkFactory.CreateInstance())
                        {
                            var userRepository = uow.BlogUserRepository;
                            var user = userRepository.GetByLoginPassword(login, password);
                            if (user == null)
                            {
                                MessageBox.Show("Incorrect credentials");
                                return;
                            }

                            StateHolder.CurrentUser = user;

                        }
                    },
                    (_)=>Login!=null && Login.Length>0 && Password!=null && Password.Password.Length>0
                );
            }
        }



    }
}