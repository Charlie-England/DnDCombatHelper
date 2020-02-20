using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD.SwitchCases
{
    public class AddChar
    {
        public static void AddNewChar(List<Character> CharList, string[] userSelection)
        {
            //Function: Small class that cleans up input before adding a new Character object to the reference List charList
            //accepts a string array with type and name already checked, checks to see if the user input p or player, if not default is npc
            //adds a new character to the reference type of charList which updates the list on the program file as well (reference type)
            var type = "";
            if (userSelection[1] == "p" || userSelection[1] == "player")
                type = "player";
            else
                type = "npc";
            CharList.Add(new Character(type, userSelection[2]));
        }
    }
}
            

