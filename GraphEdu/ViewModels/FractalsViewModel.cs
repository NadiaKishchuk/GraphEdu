using System;

using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Navigation;
using GraphEdu.Command;
namespace GraphEdu.ViewModels
{
     class FractalsViewModel : INotifyPropertyChanged
    {
        public ICommand VisitLazycodet_Command { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public FractalsViewModel()
        {
            Hyperlink_RequestNavigate_Command = new RelayCommand((o) =>
            {
                var e = (RequestNavigateEventArgs)o;
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
                e.Handled = true;
                Debug.Print("execute command");
            });
        }
        public RelayCommand Hyperlink_RequestNavigate_Command { get; set; }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // for .NET Core you need to add UseShellExecute = true
            // see https://docs.microsoft.com/dotnet/api/system.diagnostics.processstartinfo.useshellexecute#property-value
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        private void bttnTarget_MouseLeave(object sender, RequestNavigateEventArgs e)
        {
            var popup = sender as System.Windows.Controls.Primitives.Popup;
            popup.IsOpen = false;
        }
        private void bttnTarget_MouseEnter(object sender, RequestNavigateEventArgs e)
        {
            var popup = sender as System.Windows.Controls.Primitives.Popup;
            popup.IsOpen = true;
        }
    }
}
