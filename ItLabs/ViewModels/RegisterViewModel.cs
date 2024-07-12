using ItLabs.Command;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Xml.Serialization;
using System.IO;
using ItLabs.Converters;
using System.Globalization;
using System.Windows.Controls;
using System.Collections;
using ItLabs.Services;
using ItLabs.Views;
using System.Windows.Navigation;
using Unity;
using SharpCompress.Common;
using ItLabs.Utilities;

namespace ItLabs.ViewModels
{

    public class RegisterViewModel :ViewModelBase ,INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private static readonly string FullNamePattern = @"^[А-ЯЁа-яё]+(\s+[А-ЯЁа-яё]+){0,2}$";
        private static readonly string PhonePattern = @"^(?:\+7|8)(\d{10})$";
        private static readonly string EmailPattern = @"^[^@]+@[^@]+\.[a-zA-Z]{2,}$";
        private readonly INavigationService _navigationService;


        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public bool HasErrors => _errors.Count > 0;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

       

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            return null;
        }

        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged();
                    ValidateProperty(nameof(FullName), _fullName.Trim(), FullNamePattern, "Введите ФИО");
                }
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged();
                    ValidateProperty(nameof(PhoneNumber), _phoneNumber.Trim(), PhonePattern, "Некорректный номер телефона");
                }
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                    ValidateProperty(nameof(Email), _email.Trim(), EmailPattern, "Email должен содержать символ @ и домен.");
                }
            }
        }

        private void ValidateProperty(string propertyName, string value, string pattern, string errorMessage)
        {
          
             if (string.IsNullOrEmpty(value) || !Regex.IsMatch(value.Trim(), pattern))
             {
                AddError(propertyName, errorMessage);
             }
            else
            {
                RemoveError(propertyName, errorMessage);
            }
        }

        private void AddError(string propertyName, string errorMessage)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                _errors[propertyName] = new List<string>();
            }
            if (!_errors[propertyName].Contains(errorMessage))
            {
                _errors[propertyName].Add(errorMessage);
                OnErrorsChanged(propertyName);
            }
        }

        private void RemoveError(string propertyName, string errorMessage)
        {
            if (_errors.ContainsKey(propertyName) && _errors[propertyName].Contains(errorMessage))
            {
                _errors[propertyName].Remove(errorMessage);
                if (_errors[propertyName].Count == 0)
                {
                    _errors.Remove(propertyName);
                }
                OnErrorsChanged(propertyName);
            }
        }

        public RegisterViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SendingFormCommand = new RelayCommand(SendForm);
            OpenPdfIWTCommand = new RelayCommand(OpenPdfFile1);
            OpenPdfREDCommand = new RelayCommand(OpenPdfFile2);
        }
        public RegisterViewModel() : this(null) { }

        private bool ValidateData(string pattern, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }

        private void OpenPdfFile1()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(basePath, @"..\..\"));
            string pdfPath = Path.Combine(projectDirectory, "Source", "Каталог_IWT.pdf");

            OpenPDF(pdfPath);
        }

        private void OpenPdfFile2()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(basePath, @"..\..\"));
            string pdfPath = Path.Combine(projectDirectory, "Source", "Каталог_RED.pdf");

            OpenPDF(pdfPath);
        }

        private void OpenPDF(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = path,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        public ICommand SendingFormCommand { get; }
        public ICommand OpenPdfIWTCommand { get; }
        public ICommand OpenPdfREDCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        private bool CanSendForm()
        {
            return !HasErrors;
        }
        private void SendForm()
        {
            if (CanSendForm() && !string.IsNullOrEmpty(_email) && !string.IsNullOrEmpty(_fullName) && !string.IsNullOrEmpty(_phoneNumber))
            {
                _navigationService?.NavigateTo<ConfirmationPage>();
            }
        }

        private string ValidateUsingRule(string value, string pattern, string errorMessage)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "Поле не может быть пустым.";
            }

            var regex = new Regex(pattern);
            if (!regex.IsMatch(value))
            {
                return errorMessage;
            }

            return null;
        }
    }
}
