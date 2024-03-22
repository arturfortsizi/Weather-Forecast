using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace Weather_Forecast
{
    class JSON_Save
    {
        string pathFile = "data.json";

        //Сохранить файл
        public void JSONSave(bool theme_bool)
        {
            string jsonTheme = JsonConvert.SerializeObject(theme_bool);
            File.WriteAllText(pathFile, jsonTheme);
            MessageBox.Show($"{jsonTheme},{pathFile}");
        }

        //Загрузить файл
        public bool JSONLoad()
        {
            string jsonSave = File.ReadAllText(pathFile);
            return JsonConvert.DeserializeObject<bool>(jsonSave);
        }
    }
}
