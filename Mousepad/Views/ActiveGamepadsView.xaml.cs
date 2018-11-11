using System.Windows;
using Mousepad.ViewModels;

namespace Mousepad.Views
{
    public partial class ActiveGamepadsView : Window
    {
        public ActiveGamepadsView(ActiveGamepadsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            SizeChanged += (sender, args) =>
            {
                Top = SystemParameters.WorkArea.Height - args.NewSize.Height;
                Left = SystemParameters.WorkArea.Width - args.NewSize.Width;
            };
            Activated += (sender, args) =>
            {
                Top = SystemParameters.WorkArea.Height - Height;
                Left = SystemParameters.WorkArea.Width - Width;
            };
            Deactivated += (sender, args) =>
            {
                Hide();
            };
        }
    }
}
