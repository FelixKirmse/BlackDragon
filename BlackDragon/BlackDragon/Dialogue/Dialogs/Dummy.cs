using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Providers;
using BlackDragon.Managers;
using BlackDragonEngine.Dialogue;
using BlackDragonEngine.Managers;

namespace BlackDragon.Dialogue.Dialogs
{
    class DummyDialogTest1 : DialogScript
    {
        public DummyDialogTest1()
        { 
            Text = "McDonalds, bada bab bab baaa..\n"
                    +"I'm loving it!";
            MugShot = MugShotProvider.DummyMugShotNormal;
            NextDialog = "Test2";
            SpeakerName = "Ronald";
        }
    }

    class DummyDialogTest2 : DialogScript 
    {
        public DummyDialogTest2()
        {
            Text = "Greetings " + GameVariableProvider.SaveState.PlayerName + "\n"
                +"You have 1 new message:\n"
                +"Bitch, I'm a bus.";
            MugShot = MugShotProvider.DummyMugShotAngry;
            NextDialog = "STOPDIALOG";
            SpeakerName = "BattleToad";
        }
    }
}
