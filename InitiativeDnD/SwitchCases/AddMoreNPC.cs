using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD.SwitchCases
{
    public class AddMoreNPC
    {
        public static void AddMore(Dictionary<string, Character> CharList, string name, string numToAdd)
        {
			try
			{
				if (CharList[name].type == "npc")
				{
					int numToAddConverted = Convert.ToInt32(numToAdd);
					CharList[name].AddMoreNpcs(numToAddConverted);
				}
				else
				{
					Console.WriteLine("Cannot add more to a player");
				}
				
			}
			catch (Exception)
			{
				Console.WriteLine("Error in adding more NPCs");
			}
        }
    }
}
