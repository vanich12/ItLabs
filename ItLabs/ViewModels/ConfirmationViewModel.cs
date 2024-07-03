using ItLabs.Command;
using ItLabs.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace ItLabs.ViewModels
{
    public class ConfirmationViewModel : INotifyPropertyChanged
    {
        private string _code1;
        private string _code2;  
        private string _code3;
        public string _errorMessage;
        private bool _isConfirmed;
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
                if (_code1!=value && value.Length <=1)
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
        public ConfirmationViewModel() 
        {
            ConfirmCommand = new RelayCommand(Confirm);
        }
        public bool CanConfirm()
        {
           return IsDigit(_code1) && IsDigit(_code2) && IsDigit(_code3);
        }
        private void SetErrorMessage(string message)
        {
            ErrorMessage = message;
        }
        private void Confirm()
        {
            string fullCode = $"{Code1}{Code2}{Code3}";
            if (Regex.IsMatch(fullCode, "^000$"))
            {
                ErrorMessage = "Код состоит из трех нулей.";
                _isConfirmed = true;
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

        public ICommand ConfirmCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool IsDigit(string text)
        {
            return string.IsNullOrEmpty(text) || char.IsDigit(text, 0);
        }
    }
}
