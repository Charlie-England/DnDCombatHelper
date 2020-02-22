using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD.SwitchCases
{
    public class RemoveNpc
    {
        public static void RemoveAllNpc(Dictionary<string, Character> GivenCharList)
        {
            var removeList = new List<string>();
            foreach (KeyValuePair<string, Character> kvp in GivenCharList)
            {
                if (kvp.Value.type == "npc")
                    removeList.Add(kvp.Value.name);
            }
            foreach (var name in removeList)
            {
                GivenCharList.Remove(name);
            }
        }
    }
}
