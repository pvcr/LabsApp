using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labs.UserControls
{
    /// <summary>
    /// Interaction logic for SetupCtrl.xaml
    /// </summary>
    public partial class SetupCtrl : UserControl
    {
        public SetupCtrl()
        {
            InitializeComponent();
        }

        public SetupCtrl(SetupCtrl c)
        {
            InitializeComponent();
            this.setupCtrlWp.Height = c.setupCtrlWp.Height;
            this.setupCtrlWp.Width = c.setupCtrlWp.Height;
            //this.setupLblUI.Content = c.setupLblUI.Content;
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
        
            // If an element in the panel has already handled the drop,
            // the panel should not also handle it.
            if (e.Handled == false)
            {
                //Panel _panel = (Panel)sender;
                UIElement _element = (UIElement)e.Data.GetData("Object");

                InstrumentCtrl insc = _element as InstrumentCtrl;

                if (insc != null)
                {
                    //insc.Foreground= Brushes.Black;
                    insc.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#004BA9")); ;

                    ScaleTransform scaleTransform1 = new ScaleTransform(0.75, 0.75, 75, 75);
                    insc.RenderTransform = scaleTransform1;


                    if (_element != null)
                    {
                        // Get the panel that the element currently belongs to,
                        // then remove it from that panel and add it the Children of
                        // the panel that its been dropped on.
                        Panel _parent = (Panel)VisualTreeHelper.GetParent(_element);

                        if (_parent != null)
                        {
                            if (e.KeyStates == DragDropKeyStates.ControlKey &&
                                e.AllowedEffects.HasFlag(DragDropEffects.Copy))
                            {
                                SetupCtrl _circle = new SetupCtrl((SetupCtrl)_element);
                                // _panel.Children.Add(_circle);
                                // set the value to return to the DoDragDrop call
                                e.Effects = DragDropEffects.Copy;
                            }
                            else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                            {
                                _parent.Children.Remove(_element);
                                //_panel.Children.Add(_element); 
                                setupCtrlWp.Children.Clear();
                                setupCtrlWp.Children.Add(_element);
                                // set the value to return to the DoDragDrop call
                                e.Effects = DragDropEffects.Move;
                            }
                        }
                    }
                }//if not Instrument control
            }


            e.Handled = true;
        }
    }
}
