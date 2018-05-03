using GUI_PRJ2_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI_PRJ2
{
    public class BasePage<VM> : Page
        where VM: BaseViewModel, new()
    {
        #region Private Members
        /// <summary>
        /// View model associated with this page
        /// </summary>
        private VM viewModel_ { get; set; }
        #endregion

        #region Public Properties
        public VM ViewModel
        {
            get => (VM)viewModel_;
            set
            {
                //if nothing has changed return
                if (viewModel_ == value)
                    return;
                //update value
                viewModel_ = value;

                //Fire the view model changed method
                DataContext = viewModel_;
            }
        }
        #endregion

        #region Default Constructor
        public BasePage()
        {
            //Create a default view model
            ViewModel = new VM();
        }
        #endregion
    }
}
