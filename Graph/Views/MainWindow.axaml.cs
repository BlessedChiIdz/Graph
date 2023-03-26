using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Graph.ViewModels;
using System;

namespace Graph.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        InitializeComponent();
        DataContext = new MainWindowViewModel(this);
        }
    }
}
