using System;
using System.Collections.Generic;
using InitiativeDnD.SwitchCases;

namespace InitiativeDnD
{
    class Program
    {
        static void Main(string[] args)
        {
            //var CharList = new List<Character>();
            var CharList = new Dictionary<string, Character>();
            var listOption = new List<string> { "startcom", "rollinit", "remallnpc", "setinit", "addchar", "remchar", "remallnpc", "addplayers", "remall", "addmore", "sethp", "clear", "quit", "q", "test" };
            string[] userSelection;
            do
            {
                var CharListNames = new List<string>(CharList.Keys);
                Console.Clear();
                userSelection = Input.GetInput(listOption, CharList);
                switch (userSelection[0].Trim().ToLower())
                {
                    case "addchar":
                        var acceptableInputType = new List<string>() { "n", "npc", "p", "player" };
                        //calls the addchar class that will add a npc or player based on input from user
                        if (acceptableInputType.Contains(userSelection[1].Trim().ToLower())) //check to make sure user input acceptable string in console
                        {
                            if (!CharListNames.Contains(userSelection[2]))
                                AddChar.AddNewChar(CharList, userSelection);
                        }
                        break;
                    case "startcom":
                        StartCombat.StartCom(CharList);
                        break;
                    case "rollinit":
                        foreach (var character in CharList.Values)
                        {
                            if (character.type == "npc")
                            {
                                character.RollInitiative();
                            }
                        }
                        break;
                    case "setinit":
                        var SetInit = new SetInitiative();
                        SetInit.SetInitLogic(CharList, CharListNames, userSelection);
                        break;
                    case "addplayers":
                        AddCampaignPlayers.AddPlayers(CharList, userSelection);
                        break;
                    case "remall":
                        CharList = new Dictionary<string, Character>();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "sethp":
                        SetHp.SetAllHp(CharList, userSelection[1], userSelection[2]);
                        break;
                    case "addmore":
                        AddMoreNPC.AddMore(CharList, userSelection[1], userSelection[2]);
                        break;
                    case "test":
                        string[] campaign = { "blank", "tald" };
                        CharList.Add("zombie", new Character("npc", "zombie"));
                        CharList["zombie"].SetBaseHP(15);
                        CharList["zombie"].SetInitiative(12);
                        CharList["zombie"].AddMoreNpcs(3);
                        AddCampaignPlayers.AddPlayers(CharList, campaign);
                        CharList["pliny"].SetInitiative(21);
                        CharList["amman"].SetInitiative(13);
                        CharList["doug"].SetInitiative(8);
                        CharList["alima"].SetInitiative(17);
                        break;
                    //case "remchar":
                    //    RemoveCharacter();
                    //    break;
                    case "remallnpc":
                        RemoveNpc.RemoveAllNpc(CharList);
                        break;
                    case "q":
                        break;
                    case "quit":
                        break;
                    default:
                        Console.WriteLine("Default");
                        break;
                }
            } while (!Equals(userSelection[0],"q") && !Equals(userSelection[0],"quit"));
        }

    }
}
