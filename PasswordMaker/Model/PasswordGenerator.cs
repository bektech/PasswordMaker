using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PasswordMaker.Common;

namespace PasswordMaker.Model
{
    public class PasswordGenerator : ObservableObject
    {
        private enum Choice
        {
            Uppercase, Lowercase, Number
        }

        private readonly string alphabet = "abcdefghijklmnopqrstuvwxyz";
        private readonly Random random;
        private List<Choice> choices;
        private StringBuilder passwordBuilder;

        public PasswordGenerator()
        {
            random = new Random();
            passwordBuilder = new StringBuilder();
            choices = new List<Choice>();
        }

        public string MakePassword(int passwordLength, bool useUppercase, bool useLowercase, bool useNumber)
        {
            passwordBuilder.Clear();
            ConfigureChoices(useUppercase, useLowercase, useNumber);

            Choice choice;
            for (int _ = 0; _ < passwordLength; _++)
            {
                choice = choices[random.Next(choices.Count)];
                switch (choice)
                {
                    case Choice.Uppercase:
                        passwordBuilder.Append(AddUppercase());
                        break;
                    case Choice.Lowercase:
                        passwordBuilder.Append(AddLowercase());
                        break;
                    case Choice.Number:
                        passwordBuilder.Append(AddNumber());
                        break;
                    default:
                        break;
                }
            }
            return passwordBuilder.ToString();
        }

        private void ConfigureChoices(bool useUppercase, bool useLowercase, bool useNumber)
        {
            choices.Clear();
            if (useUppercase)
                choices.Add(Choice.Uppercase);
            if (useLowercase)
                choices.Add(Choice.Lowercase);
            if (useNumber)
                choices.Add(Choice.Number);
        }

        private char AddLowercase()
        {
            return alphabet[random.Next(alphabet.Length)];
        }

        private char AddUppercase()
        {
            return alphabet.ToUpper()[random.Next(alphabet.Length)];
        }

        private int AddNumber()
        {
            return random.Next(1, 10);
        }
    }
}
