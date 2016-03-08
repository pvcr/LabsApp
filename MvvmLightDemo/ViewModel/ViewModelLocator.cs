/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Labs.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Labs.Model;

namespace Labs.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
                SimpleIoc.Default.Register<IFooterService, FooterService>();
                SimpleIoc.Default.Register<ISampleService, SampleService>();

                SimpleIoc.Default.Register<IInstrumentService, InstrumentService>();
                SimpleIoc.Default.Register<ISetupService, SetupService>();
                SimpleIoc.Default.Register<ITestingService, TestingService>();
                SimpleIoc.Default.Register<IWriteupService, WriteupService>();
                SimpleIoc.Default.Register<IExceptionService, ExceptionService>();
                SimpleIoc.Default.Register<INavService, NavService>();
                SimpleIoc.Default.Register<IScheduleService, ScheduleService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}