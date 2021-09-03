using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordMaker.Model
{
    public class PasswordMaker
    {
        private enum Choice
        {
            Uppercase, Lowercase, Number
        }

        private readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";
        private readonly Random random;
        private List<Choice> choices;

        private StringBuilder passwordString;
        public string PasswordString => passwordString.ToString();

        public bool UseUppercase;
        public bool UseLowercase;
        public bool UseNumber;
        public int PasswordLength;

        public PasswordMaker()
        {
            random = new Random();
            passwordString = new StringBuilder();
            choices = new List<Choice>();
        }

        public void MakePassword()
        {
            ConfigureChoices();

            if (choices.Count == 0)
            {
                passwordString.Append("No options selected!");
                return;
            }

            passwordString.Clear();

            Choice choice;
            for (int _ = 0; _ < PasswordLength; _++)
            {
                choice = choices[random.Next(choices.Count)];
                switch (choice)
                {
                    case Choice.Uppercase:
                        passwordString.Append(AddUppercase());
                        break;
                    case Choice.Lowercase:
                        passwordString.Append(AddLowercase());
                        break;
                    case Choice.Number:
                        passwordString.Append(AddNumber());
                        break;
                    default:
                        break;
                }
            }
        }

        private void ConfigureChoices()
        {
            choices.Clear();
            if (UseUppercase)
                choices.Add(Choice.Uppercase);
            if (UseLowercase)
                choices.Add(Choice.Lowercase);
            if (UseNumber)
                choices.Add(Choice.Number);
        }

        private char AddLowercase() => alphabet[random.Next(alphabet.Length)];

        private char AddUppercase() => alphabet.ToUpper()[random.Next(alphabet.Length)];

        private int AddNumber() => random.Next(1, 10);
    }

}
