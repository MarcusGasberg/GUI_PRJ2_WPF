using GUI_PRJ2_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI_PRJ2_Library
{
    public class ApparatMenuViewModel : BaseViewModel
    {
        /// <summary>
        /// Command to go to add page
        /// </summary>
        public ICommand ToAddPageCommand { get; set; }
        /// <summary>
        /// Command to go to action page
        /// </summary>
        public ICommand ToActionPageCommand { get; set; }
        public ApparatMenuViewModel()
        {
            //create commands
            ToAddPageCommand = new RelayCommand(() => ToAddPage());
            ToActionPageCommand = new RelayCommand(() => ToActionPage());
        }
        public void ToActionPage()
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.ActionMenu;
        }

        public void ToAddPage()
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.AddMenu;
        }
    }
}
