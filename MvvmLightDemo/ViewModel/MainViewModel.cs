using GalaSoft.MvvmLight;
using Labs.Model;

namespace Labs.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly IFooterService _footerService;
        private readonly ISampleService _samplerService;

        private readonly IInstrumentService _instrService;
        private readonly ISetupService _setupService;
        private readonly ITestingService _testingService;
        private readonly IWriteupService _writeupService;
        private readonly IExceptionService _exceptionsService;
        private readonly INavService _navService;
        private readonly IScheduleService _scheduleService;
        
        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        private Footer _footer = null;
        public Footer FooterModel
        {
            get
            {
                return _footer;
            }
            set
            {
                Set(ref _footer, value);
            }

        }
        private Sample _sample = null;
        public Sample SampleModel
        {
            get
            {
                return _sample;
            }
            set
            {
                Set(ref _sample, value);
            }

        }



        private Instrument _instrument = null;
        public Instrument InstrumentModel
        {
            get
            {
                return _instrument;
            }
            set
            {
                Set(ref _instrument, value);
            }

        }

        private Setup _setup = null;
        public Setup SetupModel
        {
            get
            {
                return _setup;
            }
            set
            {
                Set(ref _setup, value);
            }

        }

        private Testing _testing = null;
        public Testing TestingModel
        {
            get
            {
                return _testing;
            }
            set
            {
                Set(ref _testing, value);
            }

        }

        private Writeup _writeup = null;
        public Writeup WriteupModel
        {
            get
            {
                return _writeup;
            }
            set
            {
                Set(ref _writeup, value);
            }

        }


        private Exceptions _exceptions = null;
        public Exceptions ExceptionsModel
        {
            get
            {
                return _exceptions;
            }
            set
            {
                Set(ref _exceptions, value);
            }

        }

        private Nav _navm = null;
        public Nav NavModel
        {
            get
            {
                return _navm;
            }
            set
            {
                Set(ref _navm, value);
            }

        }

        private Schedule _schedule = null;
        public Schedule ScheduleModel
        {
            get
            {
                return _schedule;
            }
            set
            {
                Set(ref _schedule, value);
            }

        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService, 
            IFooterService footerService, 
            ISampleService sampleService, 
            IInstrumentService instruService, 
            ISetupService setupService,
            ITestingService testingService,
            IWriteupService writeupService, 
            IExceptionService exceptionService,
            INavService navService,
            IScheduleService scheduleService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });

            _footerService = footerService;
            _footerService.GetModel(
                (item,error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    FooterModel = item;
                }
                );


            _samplerService = sampleService;
            _samplerService.GetModel(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    SampleModel = item;
                }
                );

            _instrService = instruService;
            _instrService.GetModel(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    InstrumentModel = item;
                }
                );

            _setupService = setupService;
            _setupService.GetModel(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    SetupModel = item;
                }
                );

            _testingService = testingService;
            _testingService.GetModel(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    TestingModel = item;
                }
                );

            _writeupService = writeupService;
            _writeupService.GetModel(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WriteupModel = item;
                }
                );


            _exceptionsService = exceptionService;
            _exceptionsService.GetModel(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    ExceptionsModel = item;
                }
                );

            _navService = navService;
            _navService.GetModel(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    NavModel = item;
                }
                );


            _scheduleService = scheduleService;
            _scheduleService.GetModel(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    ScheduleModel = item;
                }
                );




        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}