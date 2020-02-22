using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD
{
    class Input
    {
        public static string[] GetInput(List<string> listOption, Dictionary<String,Character> CharList)
        {
            do
            {
                Console.Write(MainMenuString(listOption, CharList));
                string[] userInput = Console.ReadLine().ToLower().Trim().Split(" ");
                if (listOption.Contains(userInput[0].ToLower()))
                {
                    return (userInput);
                } else if (userInput[0] == "help" || userInput[0] == "h")
                {
                    //call general help function
                    Console.WriteLine("General Help Call");
                } else
                {
                    if (Array.Exists(userInput, element => element == "help" || element == "-h"))
                    {
                        foreach (var option in listOption)
                        {
                            if (Array.Exists(userInput, element => element == option))
                            {
                                Console.WriteLine(HelpCall(userInput, listOption));
                                continue;
                                //helpcall and write what it returns (string)
                            }
                        }
                    } else
                        Console.WriteLine($"{userInput[0]} not recognized");
                }
            } while (true);
        }

        private static string MainMenuString(List<string> listOptions, Dictionary<String, Character> CharList)
        {
            var builder = new StringBuilder();
            int equalSpacing = 30;
            builder.Append('=', equalSpacing)
                .AppendLine()
                .Append(' ', 10)
                .Append("Main Menu")
                .Append(' ', 10)
                .AppendLine()
                .Append("Current Options: ");
            foreach (var option in listOptions)
            {
                builder.Append(option);
                builder.Append(", ");
            }
            builder.AppendLine()
                .AppendLine()
                .Append("Current Character List:\n");
            if (CharList.Count > 0)
            {
                foreach (KeyValuePair<String, Character> kvp in CharList)
                {
                    builder.Append($"{kvp.Key} (init)={kvp.Value.initiative} ");
                    if (kvp.Value.type == "npc")
                    {
                        builder.Append($"(hp)={kvp.Value.baseHP}\n");
                    } else
                    {
                        builder.Append("\n");
                    }
                }
            }
            else
                builder.Append("None");
            builder.AppendLine()
                .Append('=', equalSpacing)
                .AppendLine();
            builder.Append(">>> ");
            return builder.ToString();
        }

        private static string HelpCall(string[] userInput, List<string> listOption)
        {
            foreach (var item in userInput)
            {
                if (listOption.Contains(item))
                {
                    return (HelpReturn(item));
                }
            }
            return ("I didnt get that please try again");

        }

        private static string HelpReturn(string helpItem)
        {
            var helpBuilder = new StringBuilder();
            helpBuilder.AppendLine()
                .Append($"Help menu for {helpItem}:");
            switch (helpItem)
            {
                case "startcom":
                    helpBuilder.AppendLine()
                        .Append("Arranges based on the current initiative order and begins combat")
                        .AppendLine()
                        .Append("\t-->Clears the screen and displays creatures in initiative order\n")
                        .Append("\t-->Use 'n' to progress tracker to next creature\n")
                        .Append("\t-->'q' to quit out of initiative\n");
                    return helpBuilder.ToString();
                case "rollinit":
                    helpBuilder.AppendLine()
                        .Append("Rolls initiative for all the creatures marked as 'npc' in the current character list\n")
                        .Append("Uses the characters dexterity modifer in the Character class to modify this number\n");
                    return helpBuilder.ToString();
                case "setinit":
                    helpBuilder.AppendLine()
                        .Append("Fires up a new interface for changing the initiative of a creature. Provides:\n")
                        .Append("\t-->Information on creatures in the initiative order\n")
                        .Append("\t-->Allows the changing of initiative with <creature name> <new initiative>\n");
                    return helpBuilder.ToString();
                case "addchar":
                    helpBuilder.AppendLine()
                        .Append("Takes either 2 modifiers or no modifiers\n")
                        .Append("\t-->If called with: addchar <type> <name> will quickly create a character of type and name\n")
                        .Append("\t-->If called with no type or name will then ask for the 2 modifers\n");
                    return helpBuilder.ToString();
                case "remchar":
                    helpBuilder.AppendLine()
                        .Append("Not implemented but will remove the char of name called with it\n");
                    return helpBuilder.ToString();
                default:
                    helpBuilder.Append("Not implemented yet for current item");
                    return helpBuilder.ToString();
            }
        }
    }
}
            //var listOption = new List<string> { "startcom", "rollinit", "quit", "q", "setinit", "addchar", "remchar", "remallnpc" };