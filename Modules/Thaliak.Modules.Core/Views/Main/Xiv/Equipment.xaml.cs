﻿using System;
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

using System.ComponentModel.Composition;

namespace Thaliak.Modules.Core.Views.Main.Xiv {
    /// <summary>
    /// Interaction logic for Equipment.xaml
    /// </summary>
    [Export("EquipmentView")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class Equipment : UserControl {
        public Equipment() {
            InitializeComponent();
        }

        [Import]
        TitledNavigationTarget ViewModel {
            set { this.DataContext = value; }
        }
    }
}
