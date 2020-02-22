using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD.SwitchCases
{
    public class SetHp
    {
        public static void SetAllHp(Dictionary<string, Character> CharList, string name, string hp)
        {
			try
			{
				int hpConverted = Convert.ToInt32(hp);
				CharList[name].SetBaseHP(hpConverted);
			}
			catch (Exception)
			{
				Console.WriteLine("Error in setting BaseHP called from SetHP class");
			}
        }
    }
}
