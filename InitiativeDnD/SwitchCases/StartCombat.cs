using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD.SwitchCases
{
    public class StartCombat
    {
        public static void StartCom(List<Character> charList)
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
                builder.Append('=', 30)
                    .AppendLine()
                    .Append("Initiative Order:")
                    .AppendLine();
                List<Character> orderedCharList = GetInitiative(charList);
                //foreach loop which appends who is the current character to show on the console
                foreach (var character in orderedCharList)
                {
                    builder.Append($"{character.initiative}:{character.name}");
                    if (character == orderedCharList[currentInit])
                    {
                        builder.Append(" <--- Current");
                        if (character.type == "npc")
                        //update string builder to append list of npcs of type and hp
                        {
                            foreach (KeyValuePair<int, int> kvp in character.DictNPCs)
                            {
                                npcHPBuilder.Append($"{character.name} {kvp.Key} | hp: {kvp.Value}\n");
                            }
                        }
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
                        orderedCharList[currentInit].modifyHP(userInputArray[0], Convert.ToInt32(userInputArray[1]), Convert.ToInt32(userInputArray[2]));
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

        private static List<Character> GetInitiative(List<Character> charList)
        {
            //implement dictionary here
            var initiativeOrder = new List<int>();
            var orderedCharList = new List<Character>();
            foreach (var character in charList)
            {
                initiativeOrder.Add(character.initiative);
            }
            initiativeOrder.Sort();
            initiativeOrder.Reverse();
            foreach (int i in initiativeOrder)
            {
                foreach (var character in charList)
                {
                    if (character.initiative == i)
                    {
                        if (!orderedCharList.Contains(character))
                            orderedCharList.Add(character);
                    }

                }
            }
            return orderedCharList;
        }
    }
}

