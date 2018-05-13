using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CarouselViewIssue26Repro
{
    public class ItemViewModel : BaseViewModel
    {


        private string caption;
        public string Caption
        {
            get
            {
                return caption;
            }
            set
            {
                caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        private string anotherCaption;
        public string AnotherCaption
        {
            get
            {
                return anotherCaption;
            }
            set
            {
                anotherCaption = value;
                OnPropertyChanged(nameof(AnotherCaption));
            }
        }


    }
}
