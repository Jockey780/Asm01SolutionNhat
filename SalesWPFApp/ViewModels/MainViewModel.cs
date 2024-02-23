﻿using SalesWPFApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SalesWPFApp.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption 
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        // commands
        public ICommand ShowUserViewCommand { get; }
        public ICommand ShowProductiewCommand { get; }

        public MainViewModel()
        {
            
        }
    }
}
