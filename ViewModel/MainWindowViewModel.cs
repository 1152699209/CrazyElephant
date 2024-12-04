using CrazyElephant.Command;
using CrazyElephant.Model;
using CrazyElephant.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CrazyElephant.ViewModel
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        //has a
        //is a
        //property copy
        #region 属性


        public ICommand PlaceOrderCommand
        {
            get;
        }

        private ICommand isSelectedCommand;

        public ICommand IsSelectedCommand
        {
            get;
        }

        private Dish dish;
        public Dish Dish
        {
            get { return dish; }
            set { dish = value; OnPropertyChanged(nameof(Dish)); }
        }
        private Restaurant resturant;

        public Restaurant Restaurant
        {
            get { return resturant; }
            set { resturant = value; OnPropertyChanged(nameof(Restaurant)); }
        }
        private int count;
        public int Count
        {
            get { return count; }   
            set { count = value; OnPropertyChanged(nameof(Count)); }
        }
        public bool isSelected;
        public bool IsSelected 
        {
            get{ return isSelected; }
            set{ IsSelected = value;OnPropertyChanged(nameof(IsSelected)); }
        }
        private List<DishMenuItemViewModel> dishMenu;

        public List<DishMenuItemViewModel> DishMenu
        {
            get { return dishMenu; }
            set { dishMenu = value; OnPropertyChanged(nameof(DishMenu)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public MainWindowViewModel()
        {
            this.LoadDishMenu();
            this.LoadResturant();
            PlaceOrderCommand = new ButtonOrderCommand(PlaceOrderCommandExecute);
            IsSelectedCommand = new ChkIsSelectedCommand(SelectMenuItemCommandExecute);
        }
        private void LoadResturant()
        {
            this.Restaurant = new Restaurant();
            this.Restaurant.Name = "Hahaha";
            this.Restaurant.Address = "S省X市C区J路111号";
            this.Restaurant.PhoneNumber = "181 **** 3186";
        }

        private void LoadDishMenu()
        {
            XmlDataService ds = new XmlDataService();
            var dishes = ds.GetAllDishes();
            this.dishMenu = new List<DishMenuItemViewModel>();
            foreach (var dish in dishes)
            {
                DishMenuItemViewModel item = new DishMenuItemViewModel();
                item.Dish = dish;
                this.DishMenu.Add(item);
            }
        }

        private void SelectMenuItemCommandExecute()
        {
            this.Count = this.DishMenu.Count(i => i.IsSelected == true);
        }

        private void PlaceOrderCommandExecute()
        {
            var selectedDishes = this.dishMenu.Where(i => i.IsSelected == true).Select(i => i.Dish.Name).ToList();
            IOrderService orderSevice = new MockOrderService();
            orderSevice.PlaceOrder(selectedDishes);
            MessageBox.Show("订餐成功！");
        }

    }
}
