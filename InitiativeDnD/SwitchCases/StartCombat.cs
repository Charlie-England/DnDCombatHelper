using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD.SwitchCases
{
    public class StartCombat
    {
        public static void StartCom(Dictionary<string,Character> charList)
        {
            Console.Clear();
            string userInput;
            string[] userInputArray;
            var currentInit = 0;
            string errorPrevious = "";
            do
            {
                var builder = new StringBuilder();
                var npcHPBuilder = new StringBuilder();
                npcHPBuilder.Append("NPC List:\n");
                builder.Append('=', 30)
                    .AppendLine()
                    .Append("Initiative Order:")
                    .AppendLine();
                List<Character> orderedCharList = GetInitiative(charList);
                //foreach loop which appends who is the current character to show on the console
                foreach (var character in orderedCharList)
                {
                    if (character.type == "npc")
                    {
                        foreach (KeyValuePair<int, int> kvp in character.DictNPCs)
                        {
                            var isDead = "";
                            if (kvp.Value <= 0)
                            {
                                isDead = "->Dead/Unconscious";
                            }
                            npcHPBuilder.Append($"{character.name} {kvp.Key} | hp: {kvp.Value}{isDead}\n");
                        }
                    }
                    builder.Append($"{character.initiative}:{character.name}");
                    if (character == orderedCharList[currentInit])
                    {
                        builder.Append(" <--- Current");
                    }
                    builder.AppendLine();
                }
                builder.Append('=', 30);
                npcHPBuilder.Append('=', 30);
                //Add character list with current hp totals
                Console.WriteLine(builder.ToString());
                Console.WriteLine(npcHPBuilder.ToString());
                Console.WriteLine("Type 'n' for next in initiative");
                if (errorPrevious != "")
                    Console.WriteLine(errorPrevious);
                userInput = Console.ReadLine().Trim().ToLower();
                userInputArray = userInput.Split(" ");
                Console.Clear();
                errorPrevious = "";
                if (userInputArray[0] == "n")
                {
                    if (currentInit >= orderedCharList.Count - 1)
                    {
                        currentInit = 0;
                    }
                    else
                    {
                        currentInit++;
                    }
                }
                else if (userInputArray[0] == "addhp" || userInputArray[0] == "subhp")
                    try
                    {
                        charList[userInputArray[1]].modifyHP(userInputArray[0], Convert.ToInt32(userInputArray[2]), Convert.ToInt32(userInputArray[3]));
                        //orderedCharList[currentInit].modifyHP(userInputArray[0], Convert.ToInt32(userInputArray[1]), Convert.ToInt32(userInputArray[2]));
                    }
                    catch (Exception)
                    {
                        errorPrevious = "Exception occured";
                    }
                else
                {
                    continue;
                }
            } while (userInput != "q" && userInput != "quit");
        }

        private static List<Character> GetInitiative(Dictionary<string,Character> CharList)
        {
            //implement dictionary here
            var orderedCharList = new List<Character>();
            foreach (KeyValuePair<string, Character> kvp in CharList)
            {
                while (true) 
                {
                    if (orderedCharList.Count > 0)
                    {
                        for (int i = 0; i < orderedCharList.Count; i++)
                        {
                            if (kvp.Value.initiative < orderedCharList[i].initiative)
                            {
                                orderedCharList.Insert(i, kvp.Value);
                                break;
                            }
                        }
                        if (!orderedCharList.Contains(kvp.Value))
                            orderedCharList.Add(kvp.Value);
                    }
                    else
                    {
                        orderedCharList.Add(kvp.Value);
                    }
                    break;
                }
            }
            orderedCharList.Reverse();
            return orderedCharList;
        }
    }
}

