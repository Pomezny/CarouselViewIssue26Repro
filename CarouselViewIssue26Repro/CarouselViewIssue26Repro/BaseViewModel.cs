using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CarouselViewIssue26Repro
{
    /// <summary>
    /// Just to consolidate OnPropertyChanged, nothing interesting here
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
