using ItLabs.Command;
using ItLabs.Services;
using ItLabs.Utilities;
using ItLabs.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace ItLabs.ViewModels
{
    public class ConfirmationViewModel : ViewModelBase, INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private string _code1;
        private string _code2;
        private string _code3;
        private string _errorMessage;
        private bool _isConfirmed;
        private INavigationService _navigationService;
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public bool HasErrors => _errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool IsConfirmed
        {
            get { return _isConfirmed; }
            set
            {
                _isConfirmed = value;
                OnPropertyChanged();
            }
        }
        public string Code1
        {
            get => _code1;
            set
            {
                if (_code1 != value && value.Length <= 1)
                {
                    _code1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Code2
        {
            get => _code2;
            set
            {
                if (_code2 != value && value.Length <= 1)
                {
                    _code2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Code3
        {
            get => _code3;
            set
            {
                if (_code3 != value && value.Length <= 1)
                {
                    _code3 = value;
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

        public ICommand ConfirmCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ConfirmationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ConfirmCommand = new RelayCommand(Confirm);
        }

        private void Confirm()
        {
            _errors.Clear();
 
            ValidateProperty(nameof(Code1), Code1, "");
            ValidateProperty(nameof(Code2), Code2, "");
            ValidateProperty(nameof(Code3), Code3, "");

            OnErrorsChanged(nameof(Code1));
            OnErrorsChanged(nameof(Code2));
            OnErrorsChanged(nameof(Code3));

   
                string fullCode = $"{Code1}{Code2}{Code3}";
                if (Regex.IsMatch(fullCode, "^000$"))
                {
                    if (!HasErrors)
                    {
                        _navigationService.NavigateTo<QRCatalogPage>();
                    }
                }
                else if (fullCode.Length != 3 || !IsDigit(fullCode))
                {
                    ErrorMessage = "Код должен состоять из трех цифр.";
                }
                else
                {
                    ErrorMessage = $"Код: {fullCode} - не верен";
                }
        }

        private void ValidateProperty(string propertyName, string value, string errorMessage)
        {
            if (string.IsNullOrEmpty(value) || !IsDigit(value))
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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private bool IsDigit(string text)
        {
            return !string.IsNullOrEmpty(text) && char.IsDigit(text, 0);
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (propertyName != null && _errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            return null;
        }
    }
}
