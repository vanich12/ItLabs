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

namespace ItLabs.ViewModels
{
    internal class RegisterViewModel : INotifyPropertyChanged
    {
        private static readonly string FullNamePattern = @"^[А-ЯЁ][а-яёА-ЯЁ]*$";
        private static readonly string PhonePattern = @"^(?:\+7|8)(?:\d{10})$";
        private static readonly string EmailPattern = @"^[^@]{1,}@[^@]{1,}\.[a-zA-Z]{2,}$";

        private string _fullName;
        private string _phoneNumber;
        private string _email;
        private string _errorMessage;
        private bool _isRegistered;
        private string _phoneMessage;
        private string _emailMessage;
        private string _fullNameMessage;

        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }
        public string FullNameMessage
        {
            get => _fullNameMessage;
            set
            {
                _fullNameMessage = value;
                OnPropertyChanged();
            }
        }
        public string EmailMessage
        {
            get => _emailMessage;
            set
            {
                _emailMessage = value;
                OnPropertyChanged();
            }
        }
        public string PhoneMessage
        {
            get => _phoneMessage;
            set
            {
                _phoneMessage = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public bool IsRegistered
        {
            get => _isRegistered;
            set
            {
                _isRegistered = value;
                OnPropertyChanged();
            }
        }

        public RegisterViewModel()
        {
            SendingFormCommand = new RelayCommand(SendForm);
            OpenPdfIWTCommand = new RelayCommand(OpenPdfFile1);
            OpenPdfREDCommand = new RelayCommand(OpenPdfFile2);
        }

        private bool ValidateData(string pattern, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }

        private void SendForm()
        {
            PhoneMessage = null;
            EmailMessage = null;
            FullNameMessage = null;

            IsRegistered = ValidateData(PhonePattern, _phoneNumber) && ValidateData(EmailPattern, _email) && ValidateData(FullNamePattern, _fullName);

            if (!ValidateData(PhonePattern, _phoneNumber))
            {
                PhoneMessage = "Некорректный номер телефона";
            }

            if (!ValidateData(EmailPattern, _email))
            {
                EmailMessage = "Email должен содержать символ @ и домен.";
            }
            if (!ValidateData(FullNamePattern, _fullName))
            {
                FullNameMessage = "Введите ФИО";
            }
        }

        private void OpenPdfFile1()
        {
            string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Source", "Каталог_RED.pdf");
            OpenPDF(pdfPath);
        }

        private void OpenPdfFile2()
        {
            string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Source", "Каталог_IWT.pdf");
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
                ErrorMessage = ex.Message;
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
    }
}
