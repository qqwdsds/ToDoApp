using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using Newtonsoft.Json;

namespace ToDoApp.IOData
{
    class FileIOManager
    {
        private string PATH;
        public FileIOManager(string path)
        {
            PATH = path;
        }

        public BindingList<ToDoModel> OutputData()
        {
            if (!File.Exists(PATH))
                return new BindingList<ToDoModel>();

            using (StreamReader reader = new StreamReader(PATH))
            {
                string input = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(input);
            }

        }

        public void SaveData(BindingList<ToDoModel> listOfData)
        {
            using (StreamWriter writer = new StreamWriter(PATH))
            {
                string outputData = JsonConvert.SerializeObject(listOfData);
                writer.WriteLine(outputData);
            }
        }
    }
}
