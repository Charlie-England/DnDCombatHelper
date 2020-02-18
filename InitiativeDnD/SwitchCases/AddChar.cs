using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD.SwitchCases
{
    public class AddChar
    {
        public static Character AddNewChar(List<Character> charList, string[] userSelection)
        {
            var type = "";
            var name = "";
            if (userSelection.Length > 2)
            {
                if (userSelection[1] == "n" || userSelection[1] == "npc")
                {
                    type = "npc";
                } else if (userSelection[1] == "p" || userSelection[1] == "player")
                {
                    type = "player";
                }
                var pass1 = 1;
                name = userSelection[2];
                do
                {
                    pass1 = 1;
                    foreach (var character in charList)
                    {
                        if (character.name == name)
                            pass1 = 0;
                    }
                    if (pass1 == 1)
                    {
                        return new Character(type, name);
                    }
                    else
                    {
                        Console.WriteLine("Name already in use");
                    }
                    Console.WriteLine("Input new character name: ");
                    name = Console.ReadLine().Trim().ToLower();
                } while (pass1 != 1);
                
            }
            else
            {
                //get input from user
                string userInputQ;
                while (true)
                {
                    Console.WriteLine("npc or player? q at anytime to quit");
                    var userInput = Console.ReadLine().Trim();
                    if (userInput == "q")
                        return new Character("npc", "na");
                    if (userInput == "npc" || userInput == "n")
                        type = "npc";
                    else if (userInput == "player" || userInput == "p")
                        type = "player";
                    else
                        Console.WriteLine("I didnt get that, try again");
                    if (!String.IsNullOrEmpty(type))
                        break;
                }
                while (true)
                {
                    Console.WriteLine($"Enter name of {type}:");
                    var userInput = Console.ReadLine().Trim();
                    if (userInput == "q")
                        return new Character("npc", "na");
                    var pass = 1;
                    foreach (var character in charList)
                    {
                        if (character.name == userInput)
                        {
                            pass = 0;
                        }
                    }
                    if (pass == 1)
                    {
                        name = userInput.Trim().ToLower();
                    }
                    else
                    {
                        Console.WriteLine("Name already in use");
                    }
                }


            }
            return new Character(type, name);
        }
    }
}
            

