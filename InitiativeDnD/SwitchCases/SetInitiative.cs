using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD.SwitchCases
{
    class SetInitiative
    {
        public void SetInitLogic(List<Character> CharList, string[] userInputArray)
        {
            var charListNames = new List<string>();
            foreach (var character in CharList)
            {
                charListNames.Add(character.name);
            }
            if (userInputArray.Length > 2 && charListNames.Contains(userInputArray[1]))
            {
                foreach (var character in CharList)
                {
                    if (character.name == userInputArray[1])
                        character.initiative = Convert.ToInt32(userInputArray[2]);
                }
            }
            else
            {
                Console.WriteLine("Set initiative: example <wolf 15> | q to quit");
                string userInput;
                do
                {
                    Console.Write("Current Characters: <<< | ");
                    foreach (var character in CharList)
                    {
                        Console.Write($"{character.name}:{character.initiative} | ");
                    }
                    Console.Write(">>>\n >>> ");
                    userInput = Console.ReadLine().Trim().ToLower();
                    var userInputSplit = userInput.Split(" ");
                    foreach (var character in CharList)
                    {
                        if (character.name == userInputSplit[0])
                        {
                            character.SetInitiative(Convert.ToInt32(userInputSplit[1]));
                            Console.WriteLine($"{userInputSplit[0]} set to {character.initiative}");
                            break;
                        }
                    }
                    Resources.DoubleLine();
                } while (!Equals(userInput, "q"));
            }
        }
    }
}
