using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace CarouselViewIssue26Repro
{
    public class MainViewModel : BaseViewModel
    {
        private int currentIndex;
        public int CurrentIndex
        {
            get
            {
                return currentIndex;
            }
            set
            {
                currentIndex = value;
                OnPropertyChanged(nameof(CurrentIndex));
            }
        }

        private ObservableCollection<ItemViewModel> items;
        public ObservableCollection<ItemViewModel> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public Command<ItemViewModel> RemoveButtonCommand { get; set; }
        public Command AddButtonCommand { get; set; }
        public Command RemoveCurrentButtonCommand { get; set; }


        private string log = "";
        public string Log
        {
            get { return log; }
            set
            {
                log = value;
                OnPropertyChanged(nameof(Log));
            }
        }


        public MainViewModel()
        {
            this.RemoveButtonCommand = new Command<ItemViewModel>(RemoveButtonCommand_Execute);
            this.AddButtonCommand = new Command(AddButtonCommand_Execute);
            this.RemoveCurrentButtonCommand = new Command(RemoveCurrentButtonCommand_Execute);
        }

        protected void RemoveButtonCommand_Execute(ItemViewModel item)
        {
            Items.Remove(item);
            Log += $"Removed item {item.AnotherCaption}\n";
        }

        protected void AddButtonCommand_Execute()
        {
            var item = new ItemViewModel()
            {
                Caption = "Newly added",
                AnotherCaption = DateTime.Now.ToString("H:mm:ss")
            };
            Items.Add(item);
            Log += $"Added item at {item.AnotherCaption}\n";
        }

        protected void RemoveCurrentButtonCommand_Execute()
        {
            Items.RemoveAt(CurrentIndex);
            Log += $"Removed item at index {CurrentIndex}\n";
        }

        public void LoadSampleData()
        {
            var sample = new ObservableCollection<ItemViewModel>();
            sample.Add(new ItemViewModel() { Caption = "This is first item", AnotherCaption = "1" });
            sample.Add(new ItemViewModel() { Caption = "This is second item", AnotherCaption = "2" });
            sample.Add(new ItemViewModel() { Caption = "This is third item", AnotherCaption = "3" });
            sample.Add(new ItemViewModel() { Caption = "This is fourth item", AnotherCaption = "4" });
            sample.Add(new ItemViewModel() { Caption = "This is fifth item", AnotherCaption = "5" });
            Items = sample;
            Log += "Loaded sample data\n";
        }

    }
}
