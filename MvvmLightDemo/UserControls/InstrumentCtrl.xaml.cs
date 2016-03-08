using System;
using System.Collections.Generic;
using System.IO;
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
//using System.Windows.Shapes;

namespace Labs.UserControls
{
    /// <summary>
    /// Interaction logic for InstrumentCtrl.xaml
    /// </summary>
    public partial class InstrumentCtrl : UserControl
    {
        //#region DisplayValue
        //public int DisplayValue
        //{
        //    get { return (int)GetValue(DisplayValueProperty); }
        //    set { SetValue(DisplayValueProperty, value); }
        //}

        //public static readonly DependencyProperty DisplayValueProperty =
        //    DependencyProperty.Register("DisplayValue", typeof(int), typeof(InstrumentCtrl),
        //        new FrameworkPropertyMetadata(0, OnDisplayValuePropertyChanged));

        //private static void OnDisplayValuePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        //{
        //    InstrumentCtrl control = source as InstrumentCtrl;
        //    //control.DisplayValue = Convert.ToInt32(e.NewValue);
        //    //DateTime time = (DateTime)e.NewValue;
        //    // Put some update logic here...
        //}
        //#endregion

        //#region DisplayMethodName
        //public string DisplayMethodName
        //{
        //    get { return (string)GetValue(DisplayMethodNameProperty); }
        //    set { SetValue(DisplayMethodNameProperty, value); }
        //}

        //public static readonly DependencyProperty DisplayMethodNameProperty =
        //    DependencyProperty.Register("DisplayMethodName", typeof(string), typeof(InstrumentCtrl),
        //          new FrameworkPropertyMetadata("Default", OnMethodNamePropertyChanged));
        //private static void OnMethodNamePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        //{
        //    InstrumentCtrl control = source as InstrumentCtrl;
        //    //control.DisplayMethodName = e.NewValue.ToString();
        //    //DateTime time = (DateTime)e.NewValue;
        //    // Put some update logic here...
        //}
        //#endregion

        #region DisplayImageName
        public string DisplayImageName
        {
            get { return (string)GetValue(DisplayImageNameProperty); }
            set { SetValue(DisplayImageNameProperty, value); }
        }

        public static readonly DependencyProperty DisplayImageNameProperty =
            DependencyProperty.Register("DisplayImageName", typeof(string), typeof(InstrumentCtrl),
                  new FrameworkPropertyMetadata("lab-icon_2_128.png", OnDisplayImageNamePropertyChanged));

        private static void OnDisplayImageNamePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            InstrumentCtrl control = source as InstrumentCtrl;
            //control.DisplayImageName = e.NewValue.ToString();
            //DateTime time = (DateTime)e.NewValue;
            // Put some update logic here...
        }


        #endregion

        //#region DisplayFlaskImageName
        //public string DisplayFlaskImageName
        //{
        //    get { return (string)GetValue(DisplayFlaskImageNameProperty); }
        //    set { SetValue(DisplayFlaskImageNameProperty, value); }
        //}

        //public static readonly DependencyProperty DisplayFlaskImageNameProperty =
        //    DependencyProperty.Register("DisplayImageName", typeof(string), typeof(InstrumentCtrl),
        //          new FrameworkPropertyMetadata("Default", OnFlaskImageNamePropertyChanged));

        //private static void OnFlaskImageNamePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        //{
        //    InstrumentCtrl control = source as InstrumentCtrl;
        //    //control.DisplayFlaskImageName = e.NewValue.ToString();
        //    //DateTime time = (DateTime)e.NewValue;
        //    // Put some update logic here...
        //}


        //#endregion

        //#region DisplayDueDate
        //public string DisplayDueDate
        //{
        //    get { return (string)GetValue(DisplayDueDateProperty); }
        //    set { SetValue(DisplayDueDateProperty, value); }
        //}

        //public static readonly DependencyProperty DisplayDueDateProperty =
        //    DependencyProperty.Register("DisplayDueDate", typeof(string), typeof(InstrumentCtrl), new FrameworkPropertyMetadata("DueDate", OnDueDatePropertyChanged));

        //private static void OnDueDatePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        //{
        //    InstrumentCtrl control = source as InstrumentCtrl;
        //    //control.DisplayDueDate = e.NewValue.ToString();
        //    //DateTime time = (DateTime)e.NewValue;
        //    // Put some update logic here...
        //}
        //#endregion







        public InstrumentCtrl()
        {
            InitializeComponent();
         
            Loaded += InstrumentCtrl_Loaded;
        }

        private void InstrumentCtrl_Loaded(object sender, RoutedEventArgs e)
        {
            //Sample  dc = DataContext as Sample;
            //methodName.Text = dc.Sample1.MethodName;
            //dueDate.Text = DisplayDueDate;
            LoadImages();
        }

        private void LoadImages()
        {
            string root = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string[] supportedExtensions = new[] { ".bmp", ".jpeg", ".jpg", ".png", ".tiff" };
            var files = Directory.GetFiles(Path.Combine(root, "Images"), "*.*").Where(s => supportedExtensions.Contains(Path.GetExtension(s).ToLower()));

            //List<ImageDetails> images = new List<ImageDetails>();

            foreach (var file in files)
            {
                //ImageDetails id = new ImageDetails()
                //{
                //    Path = file,
                //    FileName = System.IO.Path.GetFileName(file),
                //    Extension = System.IO.Path.GetExtension(file)
                //};

                //BitmapImage img = new BitmapImage();
                //img.BeginInit();
                //img.CacheOption = BitmapCacheOption.OnLoad;
                //img.UriSource = new Uri(file, UriKind.Absolute);
                //img.EndInit();
                //id.Width = img.PixelWidth;
                //id.Height = img.PixelHeight;

                //// I couldn't find file size in BitmapImage
                //FileInfo fi = new FileInfo(file);
                //id.Size = fi.Length;
                //images.Add(id);
                
                if (Path.GetFileName(file) == DisplayImageName)
                    instImgContainer.Children.Add(GetDisplayImage(file));

               


            }
            //MyImages = images;
            //ImageList.ItemsSource = images;


        }

        private UIElement GetDisplayImage(string path)
        {
            var bm = new BitmapImage(new Uri(path));
            var im = new Image
            {
                Source = bm,
                Height = bm.PixelHeight,
                Width = bm.PixelWidth

            };
            return im;
        }



        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, methodName.Text);
                data.SetData("Double", layoutInstrumentCtrlRoot.Height);
                data.SetData("Object", this);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            base.OnGiveFeedback(e);
            // These Effects values are set in the drop target's
            // DragOver event handler.
            if (e.Effects.HasFlag(DragDropEffects.Copy))
            {
                Mouse.SetCursor(Cursors.Cross);
            }
            else if (e.Effects.HasFlag(DragDropEffects.Move))
            {
                Mouse.SetCursor(Cursors.Pen);
            }
            else
            {
                Mouse.SetCursor(Cursors.No);
            }
            e.Handled = true;
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

                SingleSampleCtrl ssc = _element as SingleSampleCtrl;
               

                SamplesCtrl sc = _element as SamplesCtrl;
              

                if (ssc != null || sc != null)
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
                            SingleSampleCtrl _circle = new SingleSampleCtrl((SingleSampleCtrl)_element);
                            // _panel.Children.Add(_circle);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Copy;
                        }
                        else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                        {
                            _parent.Children.Remove(_element);
                            //_panel.Children.Add(_element);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Move;
                        }
                    }
                    if (sc != null)
                    {
                        this.methodName.Text = sc.DisplayMethodName;
                        this.sampleCount.Text = (Convert.ToInt32(this.sampleCount.Text) + sc.DisplayValue).ToString();
                    }
                    if (ssc != null)
                    {
                        this.methodName.Text = ssc.MethodName;
                        this.sampleCount.Text = (Convert.ToInt32(this.sampleCount.Text) + ssc.SampleCount).ToString();
                    }
                }
            }





            // If the DataObject contains string data, extract it.
            //if (e.Data.GetDataPresent(DataFormats.StringFormat))
            //{
            //    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

            //    // If the string can be converted into a Brush, 
            //    // convert it and apply it to the ellipse.
            //    //BrushConverter converter = new BrushConverter();
            //    //if (converter.IsValid(dataString))
            //    //{
            //    //Brush newFill = (Brush)converter.ConvertFromString(dataString);
            //    //circleUI.Fill = newFill;
            //    if (itemsCount == 0) { itemsCount = Convert.ToInt32(dataString); }
            //    instrumentLblUI.Content = (Convert.ToInt32(instrumentLblUI.Content) + itemsCount).ToString();
            //    // Set Effects to notify the drag source what effect
            //    // the drag-and-drop operation had.
            //    // (Copy if CTRL is pressed; otherwise, move.)
            //    if (e.KeyStates.HasFlag(DragDropKeyStates.ControlKey))
            //    {
            //        e.Effects = DragDropEffects.Copy;
            //    }
            //    else
            //    {
            //        e.Effects = DragDropEffects.Move;
            //    }
            //    //}
            //}
            e.Handled = true;
        }
    }
}
