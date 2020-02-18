using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD.SwitchCases
{
    public class RemoveNpc
    {
        public static List<Character> RemoveAllNpc(List<Character> GivenCharList)
        {
            var returnList = new List<Character>();
            foreach (var character in GivenCharList)
            {
                if (character.type == "player")
                {
                    returnList.Add(character);
                }
            }
            return (returnList);
        }
    }
}
