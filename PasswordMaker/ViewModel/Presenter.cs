using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PasswordMaker.Common;
using PasswordMaker.Model;

namespace PasswordMaker.ViewModel
{
    public class Presenter : ObservableObject
    {
        private readonly PasswordGenerator passwordMaker;
        public Command GeneratePassword { get; private set; }

        #region Constructor
        public Presenter()
        {
            PasswordLength = 8;
            UseLowercase = false;
            UseUppercase = false;
            useNumber = false;
            GeneratePassword = new Command(CreatePassword, () => UseLowercase || UseUppercase || UseNumber);
            passwordMaker = new PasswordGenerator();
        }
        #endregion

        private string passwordString;
        public string PasswordString
        {
            get { return passwordString; }
            set
            {
                passwordString = value;
                OnPropertyChanged(nameof(PasswordString));
            }
        }

        private int passwordLength;
        public int PasswordLength
        {
            get { return passwordLength; }
            set { passwordLength = value; OnPropertyChanged(nameof(PasswordLength)); }
        }

        private bool useLowercase;
        public bool UseLowercase
        {
            get { return useLowercase; }
            set { useLowercase = value; OnPropertyChanged(nameof(UseLowercase)); }
        }

        private bool useUppercase;
        public bool UseUppercase
        {
            get { return useUppercase; }
            set { useUppercase = value; OnPropertyChanged(nameof(UseUppercase)); }
        }

        private bool useNumber;
        public bool UseNumber
        {
            get { return useNumber; }
            set { useNumber = value; OnPropertyChanged(nameof(UseNumber)); }
        }

        private void CreatePassword()
        {
            PasswordString = passwordMaker.MakePassword(PasswordLength, UseUppercase, UseLowercase, UseNumber);
        }
    }
}
