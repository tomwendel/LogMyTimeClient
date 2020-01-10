using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using LogMyTime;
using LogMyTime.Entities;

namespace DemoClient.ViewModels
{
    public sealed class StopWatchViewModel : INotifyPropertyChanged
    {
        private readonly Client _client;

        public ObservableCollection<Customer> Customers { get; }

        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
                UpdateProjects(value?.Id);
            }
        }

        public ObservableCollection<Project> Projects { get; }

        private Project _selectedProject;

        public Project SelectedProject
        {
            get => _selectedProject;
            set
            {
                _selectedProject = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Activity> Activities { get; }

        private Activity _selectedActivity;

        public Activity SelectedActivity
        {
            get => _selectedActivity;
            set
            {
                _selectedActivity = value;
                OnPropertyChanged();
            }
        }

        private ActionCommand _startWatch;

        public ICommand StartWatch => _startWatch;

        private ActionCommand _stopWatch;

        public ICommand StopWatch => _stopWatch;

        public StopWatchViewModel()
        {
            Customers = new ObservableCollection<Customer>();
            Projects = new ObservableCollection<Project>();
            Activities = new ObservableCollection<Activity>();

            var key = ConfigurationManager.AppSettings["ApiKey"];
            _client = new Client(key);

            _startWatch = new ActionCommand(StartExecute);
            _stopWatch = new ActionCommand(StopExecute);
            _startWatch.Enabled = true;

            Init();
        }

        private async void Init()
        {
            await _client.Refresh(CancellationToken.None);
            App.Current.Dispatcher.Invoke(() =>
            {
                Customers.Clear();
                foreach (var client in _client.GetCustomers())
                {
                    Customers.Add(client);
                }

                SelectedCustomer = Customers.FirstOrDefault();

                Activities.Clear();
                foreach (var task in _client.GetActivities())
                {
                    Activities.Add(task);
                }

                SelectedActivity = Activities.FirstOrDefault();
            });
        }

        private void StartExecute(object parameter)
        {
            _startWatch.Enabled = false;
            _stopWatch.Enabled = true;
        }

        private void StopExecute(object parameter)
        {
            _startWatch.Enabled = true;
            _stopWatch.Enabled = false;
        }

        private void UpdateProjects(int? clientId)
        {
            if (clientId.HasValue)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    Projects.Clear();
                    foreach (var project in _client.GetProjects().Where(p => p.ClientId == clientId))
                    {
                        Projects.Add(project);
                    }

                    SelectedProject = Projects.FirstOrDefault();
                });
            }
            else
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    Projects.Clear();
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
