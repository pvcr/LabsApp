using Labs.Model;
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
    /// Interaction logic for SamplesCtrl.xaml
    /// </summary>
    public partial class SamplesCtrl : UserControl
    {
        public int DisplayValue
        {
            get { return (int)GetValue(DisplayValueProperty); }
            set { SetValue(DisplayValueProperty, value); }
        }
               
        public static readonly DependencyProperty DisplayValueProperty =
            DependencyProperty.Register("DisplayValue", typeof(int), typeof(SamplesCtrl), new FrameworkPropertyMetadata(0, OnDisplayValuePropertyChanged));


        public string DisplayMethodName
        {
            get { return (string)GetValue(DisplayMethodNameProperty); }
            set { SetValue(DisplayMethodNameProperty, value); }
        }

        public static readonly DependencyProperty DisplayMethodNameProperty =
            DependencyProperty.Register("DisplayMethodName", typeof(string), typeof(SamplesCtrl), 
                  new FrameworkPropertyMetadata("Default",OnMethodNamePropertyChanged));

        public string DisplayDueDate
        {
            get { return (string)GetValue(DisplayDueDateProperty); }
            set { SetValue(DisplayDueDateProperty, value); }
        }

        public static readonly DependencyProperty DisplayDueDateProperty =
            DependencyProperty.Register("DisplayDueDate", typeof(string), typeof(SamplesCtrl), new FrameworkPropertyMetadata("DueDate", OnDueDatePropertyChanged));

        private static void OnDisplayValuePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            SamplesCtrl control = source as SamplesCtrl;
            control.DisplayValue = Convert.ToInt32(e.NewValue);
            //control.methodName.Text = e.NewValue.ToString();
            //DateTime time = (DateTime)e.NewValue;
            // Put some update logic here...
        }

        private static void OnMethodNamePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            SamplesCtrl control = source as SamplesCtrl;
            control.methodName.Text = e.NewValue.ToString();
            //DateTime time = (DateTime)e.NewValue;
            // Put some update logic here...
        }

        private static void OnDueDatePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            SamplesCtrl control = source as SamplesCtrl;
            control.dueDate.Text = e.NewValue.ToString();
            //DateTime time = (DateTime)e.NewValue;
            // Put some update logic here...
        }


        //private static object OnCoerceTimeProperty(DependencyObject sender, object data)
        //{
        //    if ((DateTime)data > DateTime.Now)
        //    {
        //        data = DateTime.Now;
        //    }
        //    return data;
        //}

        //private static bool OnValidateTimeProperty(object data)
        //{
        //    return data is DateTime;
        //}
        public SamplesCtrl()
        {
            InitializeComponent();
            Loaded += SamplesCtrl_Loaded;
        }

        public SamplesCtrl(SamplesCtrl c)
        {
            InitializeComponent();
            this.samplesLayoutRoot.Height = c.samplesLayoutRoot.Height;
            this.samplesLayoutRoot.Width = c.samplesLayoutRoot.Height;
            //this.circleUI.Fill = c.circleUI.Fill;
        }

        private void SamplesCtrl_Loaded(object sender, RoutedEventArgs e)
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
                if (Path.GetFileName(file) == "laboratory-icon32.png")
                {
                    for (int i = 0; i < DisplayValue; i++)
                    {
                        imgContainer.Children.Add(GetDisplayImage(file));
                    }
                }
            
               
            }
            //MyImages = images;
            //ImageList.ItemsSource = images;


        }

        private UIElement GetDisplayImage(string path)
        {
            //var bm = new BitmapImage(new Uri(path));
            //var im = new Image
            //{
            //    Source = bm,
            //    Height = bm.PixelHeight,
            //    Width = bm.PixelWidth

            //};
            //return im;


            var im = new SingleSampleCtrl { MethodName=DisplayMethodName,SampleCount=1 };
           
            return im;
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData(DataFormats.StringFormat, "10");
                //data.SetData("Double", circleUI.Height);
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

    }
}
