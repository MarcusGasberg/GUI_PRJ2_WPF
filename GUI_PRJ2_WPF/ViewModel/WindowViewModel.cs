using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GUI_PRJ2_Library;

namespace GUI_PRJ2
{
    /// <summary>
    /// View model for the custom flat window
    /// </summary>
    class WindowViewModel : BaseViewModel
    {
        #region Private Members
        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window window_;

        /// <summary>
        /// The margin around the wiondow to allow for a drop shadow
        /// </summary>
        private int outerMarginSize_ = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int windowRadius_ = 10;

        #endregion
        #region Public Properties


        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;
        /// <summary>
        /// The smallest height the window can go to
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// The Size of the resize border around the window,
        /// </summary>
        public int ResizeBorder { get; set; } = 4;

        /// <summary>
        /// The Padding of the inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder); } }

        /// <summary>
        /// The size of the resize border arround the window taking into account the outer margin
        /// </summary>

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// The margin around the wiondow to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return window_.WindowState == WindowState.Maximized ? 0 : outerMarginSize_;
            }
            set
            {
                outerMarginSize_ = value;
            }
        }

        /// <summary>
        /// The margin thickness around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness
        {
            get
            {
                return new Thickness(OuterMarginSize);
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return window_.WindowState == WindowState.Maximized ? 0 : windowRadius_;
            }
            set
            {
                windowRadius_ = value;
            }
        }

        /// <summary>
        /// The Corner radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the tile bar/ caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 32;

        #endregion
        #region Commands
        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }
        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }
        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }
        /// <summary>
        /// The command to show the sytem menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            window_ = window;

            //Listen out for window resizing
            window_.StateChanged += (sender, e) =>
            {
                //Fire off events for all properties that are affected by a resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            //Create Commands
            MinimizeCommand = new RelayCommand(() => window_.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => window_.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => window_.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(window_, window_.PointToScreen(Mouse.GetPosition(window_))));
            
        }
        #endregion
        #region Private Helpers
    
        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            //Position of the mouse relative to the window
            var position = Mouse.GetPosition(window_);
            //Add the window position so its a "ToScree"
            return new Point(position.X + window_.Left, position.Y + window_.Top);
        }
        #endregion
    }
}
