using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD.SwitchCases
{
    public class AddCampaignPlayers
    {
        public static void AddPlayers(List<Character> charList, string[] userSelection)
        {
            string userInput;
            string campaign = userSelection[1];
                //takes a campaign and will add players to that at 0 initiative 
            if (campaign == "ghosts")
            {
                //add players for ghosts of saltmarsh
                charList.Add(new Character("player", "kezil"));
                charList.Add(new Character("player", "selryn"));
                charList.Add(new Character("player", "clark"));
                charList.Add(new Character("player", "tika"));
            }
            else if (campaign == "tald")
            {
                //add players for taldorei free campaign
                charList.Add(new Character("player", "pliny"));
                charList.Add(new Character("player", "amman"));
                charList.Add(new Character("player", "doug"));
                charList.Add(new Character("player", "alima"));
            }
            else
            {
                Console.WriteLine("Campaign was not able to be determined, please re-enter: ");
            }
        }
    }
}
