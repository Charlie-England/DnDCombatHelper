using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD.SwitchCases
{
    class SetInitiative
    {
        public void SetInitLogic(Dictionary<string, Character> CharList,List<string> CharListNames, string[] userInputArray)
        {
            if (userInputArray.Length > 2 && CharListNames.Contains(userInputArray[1].Trim().ToLower()))
            {
                CharList[userInputArray[1]].initiative = Convert.ToInt32(userInputArray[2]);
            }
            else
            {
                Console.WriteLine("Error, could not set initiative");
            }
        }
    }
}
