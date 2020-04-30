using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinUsers.Model;
using XamarinUsers.Services;

namespace XamarinUsers.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region public properties

        private ObservableCollection<User> _userObservableCollection;
        public ObservableCollection<User> UserObservableCollection
        {
            get => _userObservableCollection;
            set
            {
                _userObservableCollection = value;
                OnPropertyChanged(nameof(UserObservableCollection));
            }
        }

        private bool _isActivityIndicatorRunning;
        public bool IsActivityIndicatorRunning
        {
            get => _isActivityIndicatorRunning;
            set
            {
                _isActivityIndicatorRunning = value;
                OnPropertyChanged(nameof(IsActivityIndicatorRunning));
            }
        }

        private bool _isAddUserModalOpened;
        public bool IsAddUserModalOpened
        {
            get => _isAddUserModalOpened;
            set
            {
                _isAddUserModalOpened = value;
                OnPropertyChanged(nameof(IsAddUserModalOpened));
            }
        }

        private bool _isErrorMessageVisible;
        public bool IsErrorMessageVisible
        {
            get => _isErrorMessageVisible;
            set
            {
                _isErrorMessageVisible = value;
                OnPropertyChanged(nameof(IsErrorMessageVisible));
            }
        }

        private string _firstNameText;
        public string FirstNameText
        {
            get => _firstNameText;
            set
            {
                _firstNameText = value;
                OnPropertyChanged(nameof(FirstNameText));
            }
        }

        private string _lastNameText;
        public string LastNameText
        {
            get => _lastNameText;
            set
            {
                _lastNameText = value;
                OnPropertyChanged(nameof(LastNameText));
            }
        }

        private string _phoneText;
        public string PhoneText
        {
            get => _phoneText;
            set
            {
                _phoneText = value;
                OnPropertyChanged(nameof(PhoneText));
            }
        }

        #endregion

        #region commands

        public Command SaveCommand { get; private set; }
        public Command CancelCommand { get; private set; }

        #endregion

        #region public methods

        public async Task GetAllUsers()
        {
            IsActivityIndicatorRunning = true;
            var userList = await userService.GetUsers();
            if (userList != null)
                UserObservableCollection = new ObservableCollection<User>(userList);

            IsActivityIndicatorRunning = false;
        }

        public void AddNewUser()
        {
            if (string.IsNullOrEmpty(FirstNameText) || string.IsNullOrEmpty(LastNameText) || string.IsNullOrEmpty(PhoneText))
            {
                IsErrorMessageVisible = true;
                return;
            }

            User user = new User
            {
                FirstName = FirstNameText,
                LastName = LastNameText,
                PhoneNumber = PhoneText,
                Status = "Active"
            };

            UserObservableCollection.Add(user);

            IsAddUserModalOpened = false;

            CleanEntryFields();
        }

        #endregion

        #region Constructor

        public MainPageViewModel(IUserService userService)
        {
            this.userService = userService;

            Task.Run(async () => await GetAllUsers());

            SaveCommand = new Command(() => AddNewUser());
            CancelCommand = new Command(() => { IsAddUserModalOpened = false; CleanEntryFields(); });
        }

        #endregion

        #region Private properties

        private IUserService userService;

        #endregion

        #region OnPropertyChanged methods

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region private methods

        private void CleanEntryFields()
        {
            FirstNameText = string.Empty;
            LastNameText = string.Empty;
            PhoneText = string.Empty;

            IsErrorMessageVisible = false;
        }

        #endregion
    }
}
