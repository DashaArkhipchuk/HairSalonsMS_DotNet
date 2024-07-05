using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetCoursework.View.Serialization
{
    public static class Serialization
    {
        public static void JsonSave<T>(T obj, string file)
        {

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };


            try
            {
                string json = JsonConvert.SerializeObject(obj, settings);
                File.WriteAllText(file, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public static T? JsonLoad<T>(string file)
        {
            T? obj = default(T);
            try
            {
                string jsonString = File.ReadAllText(file);

                obj = JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return obj;
        }
    }
}
