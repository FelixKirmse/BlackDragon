﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.IO;
using BlackDragon.Helpers;
using System.Runtime.Serialization.Formatters.Binary;
using BlackDragon.Providers;
using System.Security.Cryptography;

namespace BlackDragon.Managers
{
    static class SaveManager
    {
        public static SaveState SaveState { get; set; }

        public static void Initialize()
        {
            SaveState = new SaveState();
        }

        public static void SaveSaveState()
        {
            FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Project Black Dragon\saves\" + GetMD5Hash(SaveState.PlayerName), FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, SaveState);
            fs.Close();
        }

        public static void LoadSaveState(string playerName)
        {
            FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\Project Black Dragon\saves\" + playerName + ".svs", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            SaveState = (SaveState)formatter.Deserialize(fs);
        }

        public static string GetMD5Hash(string TextToHash)
        {
            //Prüfen ob Daten übergeben wurden.
            if ((TextToHash == null) || (TextToHash.Length == 0))
            {
                return string.Empty;
            }

            //MD5 Hash aus dem String berechnen. Dazu muss der string in ein Byte[]
            //zerlegt werden. Danach muss das Resultat wieder zurück in ein string.
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] textToHash = Encoding.Default.GetBytes(TextToHash);
            byte[] result = md5.ComputeHash(textToHash);

            return System.BitConverter.ToString(result);
        } 
    }
}