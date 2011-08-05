using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Dialogue;
using BlackDragon.Dialogue.Dialogs;

namespace BlackDragon.Providers
{
    static class DialogDictionaryProvider
    {
        public static Dictionary<string, DialogScript> DummyDialog = new Dictionary<string, DialogScript>();

        public static void Initialize()
        {
            DummyDialog.Add("Test1", new DummyDialogTest1());
            DummyDialog.Add("Test2", new DummyDialogTest2());
        }
    }
}
