using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AI_Master_SharedMemory
{
    public static class ReadConfig
    {
        public static String defaultpath = Application.StartupPath + @"\AIMaster";
        public static Boolean ExistConfigFile()
        {
            if (!Directory.Exists(defaultpath))
            {
                return false;
            }
            else
            {
                if (!File.Exists(defaultpath + @"\config.json"))
                    return false;
                else
                    return true;
            }
        }

        public static Boolean SaveConfig(DisplayPictureboxInfo[] camset)
        {
            try
            {
                var JsonStr = JsonConvert.SerializeObject(camset);
                if (!ExistConfigFile())
                {
                    Directory.CreateDirectory(defaultpath + @"\");
                }
                using (FileStream fs = new FileStream(defaultpath + @"\config.json", FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(JsonStr);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static DisplayPictureboxInfo[] GetConfig()
        {
            using (FileStream fs = new FileStream(defaultpath + @"\config.json", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    var JsonStr = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<DisplayPictureboxInfo[]>(JsonStr);
                }
            }
        }
    }
}
