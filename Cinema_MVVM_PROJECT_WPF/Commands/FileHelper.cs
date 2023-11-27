using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Cinema_MVVM_PROJECT_WPF.FileHelpers
{
    public class FileHelper
    {
        public static void ButtonsWriter(List<Brushes> brushes,string fileName)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter("button.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, brushes);
                }
            }
        }

        public static ObservableCollection<Button> ReadButtons(string fileName)
        {
            ObservableCollection<Button> buttons = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader($"{fileName}.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    buttons = serializer.Deserialize<ObservableCollection<Button>>(jr);
                }
            }
            return buttons;
        }
    }
}
