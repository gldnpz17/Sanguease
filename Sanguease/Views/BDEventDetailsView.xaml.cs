﻿using Sanguease.ViewModels.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sanguease.Views
{
    /// <summary>
    /// Interaction logic for BDEventDetails.xaml
    /// </summary>
    public partial class BDEventDetailsView : UserControl
    {
        public BDEventDetailsView(IBDEventDetailsViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}