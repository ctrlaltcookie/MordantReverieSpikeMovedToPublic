using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace WPFPrototypeReverie.Libraries
{
    public class GameProgressTracker
    {
        private Dictionary<string, bool> scenesPlayed;
        private Dictionary<string, bool> defaultScenes;

        public GameProgressTracker()
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\Jack\source\repos\WPFPrototypeReverie\sceneList.json"))
            {
                string json = sr.ReadToEnd();
                defaultScenes = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, bool>>(json);
            }
            if (File.Exists(@"C:\Users\Jack\source\repos\WPFPrototypeReverie\gameSave.json"))
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Jack\source\repos\WPFPrototypeReverie\gameSave.json"))
                {
                    string json = sr.ReadToEnd();
                    scenesPlayed = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, bool>>(json);
                }
            }
            else
            {
                scenesPlayed = defaultScenes;
            }
        }

        public void MarkSceneViewed(string sceneName)
        {
            scenesPlayed[sceneName] = true;
        }

        public List<string> ViewedScenes()
        {
            Dictionary<string, bool> viewedScenes = scenesPlayed
                .Where(k => k.Value == true)
                .ToDictionary(kv => kv.Key, kv => kv.Value);
            return new List<string>(viewedScenes.Keys);
        }

        public string LastViewedScene()
        {
            Dictionary<string, bool> missedScenes =  scenesPlayed
                .Where(k => k.Value == false)
                .ToDictionary(kv => kv.Key, kv => kv.Value);
            List<string> missedSceneKeys = missedScenes.Keys.ToList();
            int lowestKey = missedSceneKeys.Count;
            foreach (string key in missedSceneKeys)
            {
                var strippedKey = key.Remove(0, 5);
                int keyNumber = Convert.ToInt32(strippedKey);
                if (keyNumber < lowestKey)
                {
                    lowestKey = keyNumber;
                }
            }
            return $"scene{lowestKey}";
        }

        public void SaveGame()
        {
            string save = Newtonsoft.Json.JsonConvert.SerializeObject(scenesPlayed);
            using (StreamWriter sr = new StreamWriter(@"C:\Users\Jack\source\repos\WPFPrototypeReverie\gameSave.json"))
            {
                sr.WriteAsync(save);
            }
        }

        public void ResetGame()
        {
            scenesPlayed = defaultScenes;
        }
    }
}
