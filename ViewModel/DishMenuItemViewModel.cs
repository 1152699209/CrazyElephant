using CrazyElephant.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.ViewModel
{
    public class DishMenuItemViewModel : INotifyPropertyChanged
    {

        public Dish Dish { get; set; }

        public bool isSelected;

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsSelected)));
            }
        }
    }
}
