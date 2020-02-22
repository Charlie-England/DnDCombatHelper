using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD.SwitchCases
{
    public class AddCampaignPlayers
    {
        public static void AddPlayers(Dictionary<String, Character> CharList, string[] userSelection)
        {
            string campaign = userSelection[1];
                //takes a campaign and will add players to that at 0 initiative 
            if (campaign == "ghosts")
            {
                //add players for ghosts of saltmarsh
                CharList.Add("kezil", new Character("player", "kezil"));
                CharList.Add("selryn", new Character("player", "selryn"));
                CharList.Add("clark", new Character("player", "clark"));
                CharList.Add("tika", new Character("player", "tika"));
            }
            else if (campaign == "tald")
            {
                //add players for taldorei free campaign
                CharList.Add("pliny", new Character("player", "pliny"));
                CharList.Add("amman", new Character("player", "amman"));
                CharList.Add("doug", new Character("player", "doug"));
                CharList.Add("alima", new Character("player", "alima"));
            }
            else
            {
                Console.WriteLine("Campaign was not able to be determined, please re-enter: ");
            }
        }
    }
}
