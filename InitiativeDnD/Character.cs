using System;
using System.Collections.Generic;
using System.Text;

namespace InitiativeDnD
{
    public class Character
    {
        public string type, name;
        public int initiative, strength, dexterity, constitution, wisdom, intelligence, charisma, baseHP;
        public Dictionary<int, int> DictNPCs;
        public Character(string type, string name)
        {
            this.type = type;
            this.name = name;
            this.initiative = 0;
            //attributes
            this.strength = 10;
            this.dexterity = 17;
            this.constitution = 10;
            this.wisdom = 10;
            this.intelligence = 10;
            this.charisma = 10;
            this.baseHP = 0;
            if (type == "npc")
            {
                //Dict w/
                    //key = iterating number signifying which npc
                    //value = current hp of that npc
                this.DictNPCs = new Dictionary<int, int>();
                this.DictNPCs.Add(1, this.baseHP);
            }
        }

        public void SetInitiative(int newInit)
        {
            this.initiative = newInit;
        }

        public void SetAttribute(string attribute, int newScore)
        {
            switch (attribute)
            {
                case "strength":
                    this.strength = newScore;
                    break;
                case "dexterity":
                    this.dexterity = newScore;
                    break;
                case "constitution":
                    this.constitution = newScore;
                    break;
                case "wisdom":
                    this.wisdom = newScore;
                    break;
                case "intelligence":
                    this.intelligence = newScore;
                    break;
                case "charisma":
                    this.charisma = newScore;
                    break;
                default:
                    Console.WriteLine("Failure on setting attribute");
                    break;
            }
        }

        public void SetBaseHP(int newHP)
        {
            this.baseHP = newHP;
            //loop to update baseHP for each key:value pair in dictionary
            for (int i = 1; i <= this.DictNPCs.Count; i++)
            {
                this.DictNPCs[i] = this.baseHP;
            }
        }

        private int GetModifer(int attributeNum)
        {
            return ((attributeNum % 10) / 2);
        }

        public void RollInitiative()
        {
            if (this.type == "npc")
            {
                var randomInt = new Random();
                int chosenInt = randomInt.Next(1, 21);
                this.initiative = (GetModifer(this.dexterity) + chosenInt);
            }
        }

        public void AddMoreNpcs(int numAdd)
        {
            for (int i = 0; i < numAdd; i++)
            {
                this.DictNPCs.Add(i + 2, this.baseHP);
            }
        }

        public void modifyHP(string usrInput, int keyNum, int hpChange)
        {
            if (usrInput == "addhp")
                this.DictNPCs[keyNum] += hpChange;
            else if (usrInput == "subhp")
                this.DictNPCs[keyNum] -= hpChange;
        }

    }
}
