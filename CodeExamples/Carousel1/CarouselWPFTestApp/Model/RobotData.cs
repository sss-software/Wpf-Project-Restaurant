using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarouselWPFTestApp
{
    public class RobotData : INPCBase
    {
        private string robotName;
        private string imageUrl;

        public RobotData(string robotName, string imageUrl)
        {
            this.robotName = robotName;
            this.imageUrl = imageUrl;
        }


        public string RobotName
        {
            get { return robotName; }
            set
            {
                if (robotName != value)
                {
                    robotName = value;
                    NotifyPropertyChanged("RobotName");
                }
            }
        }

        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                if (imageUrl != value)
                {
                    imageUrl = value;
                    NotifyPropertyChanged("ImageUrl");
                }
            }
        }

    }
}
