using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MainWIndowCustom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ThumbW_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var CurrentWindow = Window.GetWindow((DependencyObject)e.Source);
            if (CurrentWindow.Width + e.HorizontalChange > 0)
            {
                CurrentWindow.Width += e.HorizontalChange;
            }
        }

        private void ThumbE_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var CurrentWindow = Window.GetWindow((DependencyObject)e.Source);
            if (CurrentWindow.Width - e.HorizontalChange > CurrentWindow.MinWidth)
            {
                CurrentWindow.Left += e.HorizontalChange;
                CurrentWindow.Width -= e.HorizontalChange;
            }

        }
        private void ThumbS_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var CurrentWindow = Window.GetWindow((DependencyObject)e.Source);
            if (CurrentWindow.Height + e.VerticalChange > 0)
            {
                CurrentWindow.Height += e.VerticalChange;
            }
        }
        private void ThumbN_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var CurrentWindow = Window.GetWindow((DependencyObject)e.Source);
            if (CurrentWindow.Height - e.VerticalChange > 0)
            {
                CurrentWindow.Top += e.VerticalChange;
                CurrentWindow.Height -= e.VerticalChange;
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            var CurrentWindow = Window.GetWindow((DependencyObject)e.Source);
            CurrentWindow.Close();

        }

        private void ButtonMinimalize_Click(object sender, RoutedEventArgs e)
        {
            var CurrentWindow = Window.GetWindow((DependencyObject)e.Source);
            CurrentWindow.WindowState = WindowState.Minimized;
        }

        private void ButtonMiaximize_Click(object sender, RoutedEventArgs e)
        {
             var CurrentWindow = Window.GetWindow((DependencyObject)e.Source);
             if (CurrentWindow.WindowState == WindowState.Normal)
             {
                var LastMaxHeight = CurrentWindow.MaxHeight;
                var LastMaxWidth = CurrentWindow.MaxWidth;
                System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.FromPoint(new System.Drawing.Point((int)CurrentWindow.Left, (int)CurrentWindow.Top));
                CurrentWindow.MaxHeight = screen.WorkingArea.Size.Height + 14;
                CurrentWindow.MaxWidth = screen.WorkingArea.Size.Width + 14;
                CurrentWindow.WindowState = WindowState.Maximized;
                CurrentWindow.MaxHeight = LastMaxHeight;
                CurrentWindow.MaxWidth = LastMaxWidth;

            }
             else if (CurrentWindow.WindowState == WindowState.Maximized)
             {
                 CurrentWindow.WindowState = WindowState.Normal;
             }
      
    
           
        }

        private void TopBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var CurrentWindow = Window.GetWindow((DependencyObject)e.Source);
            /* (CurrentWindow.WindowState == WindowState.Maximized)
            {
                CurrentWindow.Top = Mouse.GetPosition(CurrentWindow).Y;
                CurrentWindow.WindowState = WindowState.Normal;
            }*/

            CurrentWindow.DragMove();
        }



        /*   private void TopBar_MouseUp(object sender, MouseEventArgs e)
             {
                var CurrentWindow = Window.GetWindow((DependencyObject)e.Source);
                 if (CurrentWindow.WindowState == WindowState.Normal)
                 {
                     if (CurrentWindow.Top == 0)
                     {
                         CurrentWindow.MaxHeight = SystemParameters.WorkArea.Height;
                         CurrentWindow.WindowState = WindowState.Maximized;
                     }
                 }
                 if (CurrentWindow.Top < 0) throw new Exception("dasdsa");
                 CurrentWindow.Top = 0;
                 CurrentWindow.MaxHeight = SystemParameters.WorkArea.Height;
             }*/
    }
}
