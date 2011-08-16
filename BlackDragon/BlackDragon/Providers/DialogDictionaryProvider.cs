using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragonEngine.Dialogue;
using BlackDragon.Dialogue.Dialogs;

namespace BlackDragon.Providers
{
    static class DialogDictionaryProvider
    { 
        public static Dictionary<string, DialogScript> GetDummyDialog()
        {
            Dictionary<string, DialogScript> dummyDialog = new Dictionary<string, DialogScript>();
            dummyDialog.Add("Test1", new DummyDialogTest1());
            dummyDialog.Add("Test2", new DummyDialogTest2());
            return dummyDialog;
        }
    }
}
