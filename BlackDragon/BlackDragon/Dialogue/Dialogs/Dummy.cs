using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackDragon.Providers;

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
            Text = "Bitch, I'm a bus.";
            MugShot = MugShotProvider.DummyMugShotAngry;
            NextDialog = "STOPDIALOG";
            SpeakerName = "BattleToad";
        }
    }
}
