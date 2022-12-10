﻿using SapphirApp.Converter;
using SapphirApp.Core;
using SapphirApp.Data.Context;
using SapphirApp.Data.Repository;
using SapphirApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SapphirApp.ViewModels
{
    public class UsersVM : ObserveObject
    {
        private SapphirApplicationContext context = new SapphirApplicationContext();
        private UserRepository Repository;
        private List<UsersLists> _usersList = new List<UsersLists>();
        private UsersLists _user = new UsersLists();
        public UsersLists User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
   
       
        public List<UsersLists> UsersLists
        {
            get=> _usersList;
            set
            {
                _usersList = value;
                OnPropertyChanged(nameof(UsersLists));
            }
        }
        public ICommand EditUser { get; }
        public UsersVM()
        {
            
            Repository = new UserRepository(context);
            UsersLists = UserListConverter.Converter(Repository.GetAll());
            EditUser = new RelayCommand(EditSelectUser);
        }
        private void EditSelectUser(object obj)
        {
            MessageBox.Show(User.FullName);
        }
    }
}