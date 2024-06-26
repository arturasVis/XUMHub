﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using XUMHUB.Commands;
using XUMHUB.Core;
using XUMHUB.Services;
using XUMHUB.Stores;
using XUMHUB.View;

namespace XUMHUB.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public ICommand MinimizeCommand { get; }
        public ICommand MaximizeCommand { get; }
        public ICommand CloseCommand { get; }
        private readonly NavigationStore navigationStore;
        public ICommand DashboardViewCommnad { get; }
        public ICommand ReturnsViewCommnad { get; }

        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore navigationStore,NavigationService<DashboardViewModel> dashboardNavigationSerivice,NavigationService<ReturnsListingViewModel> returnsNavigationSerive)
        {
            this.navigationStore = navigationStore;
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            MinimizeCommand = new RelayCommand(s => OnMinimize());
            MaximizeCommand = new RelayCommand(s =>OnMaximize());
            CloseCommand = new RelayCommand(s => OnClose());
            DashboardViewCommnad = new NavigateCommand<DashboardViewModel>(dashboardNavigationSerivice);
            ReturnsViewCommnad = new NavigateCommand<ReturnsListingViewModel>(returnsNavigationSerive);

        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
        private void OnClose()
        {
            Application.Current.MainWindow.Close();
        }

        private void OnMaximize()
        {
            if(Application.Current.MainWindow.WindowState== WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        private void OnMinimize()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
