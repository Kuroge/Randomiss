using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Randomiss
{
    public class ClipboardAction
    {
        private ObservableCollection<string> copyType = new ObservableCollection<string> { "copy to clipboard", "copy password #1" };

        private int copyNumber = 0;

        public List<string> GeneratedPasswords { get; set; }

        public int SelectedIndex { get; set; }
        public ObservableCollection<string> CopyType { get => copyType; set => copyType = value; }
        public int CopyNumber { get => copyNumber; set => copyNumber = value; }

        public ClipboardAction(List<string> generatedPasswords)
        {
            this.GeneratedPasswords = generatedPasswords;
        }

        public string Copy()
        {
            switch (SelectedIndex)
            {
                case 0:
                    Clipboard.SetText(string.Join("\r\n ", GeneratedPasswords));
                    return "Copied to clipboard! :)";
                case 1:
                    Clipboard.SetText(GeneratedPasswords[CopyNumber]);
                    if (CopyNumber + 1 == GeneratedPasswords.Count)
                    {
                        CopyNumber = 0;
                        CopyType.RemoveAt(1);
                        CopyType.Add($"copy password #{CopyNumber + 1}");
                        return "All passwords copied! :D";
                    }
                    else
                    {
                        CopyType.RemoveAt(1);
                        CopyType.Add($"copy password #{CopyNumber + 1}");
                        SelectedIndex = 1;
                        CopyNumber++;
                        return $"Password #{CopyNumber}";
                    }

                default:
                    break;
            }
            return "error";
        }

    }
}
