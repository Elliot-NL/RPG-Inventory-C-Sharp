using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_File___Interface_2
{
    class Program
    {
        /// <summary>
        /// Interfaces are contract models for classes 
        /// which aid in making classes simpler & safer
        /// </summary>
        interface items
        {
            string name { get; set; }
            int goldValue { get; set; }
            void equip();
            void sell();
        }
        interface damagable
        {
            int durability { get; set; }
            void takedamage(int _amount);  
        }
        interface quest
        {
            void TurnIn();
           
        }
        class sword : items, damagable, quest
        {
            public string name { get; set; }
            public int goldValue { get; set; }
            public int durability { get; set; }
            public sword(string _name )
            {
                name = _name;
                goldValue = 100;
                durability = 30;
            }
            public void equip()
            {
                Console.WriteLine(name + " equiped ");
            }
            public void sell()
            {
                Console.WriteLine($"{name} { " sold for "} { goldValue}");
            }
            public void takedamage(int _dmg)
            {
                durability -= _dmg;
                if(durability < 0)
                {
                    durability = 0;
                }
                Console.WriteLine(name + " damaged by " + _dmg +
                    " it now has the durability of " + durability);

            }
            public void TurnIn()
            {
              Console  .WriteLine(name + " Turned In");
            }
        }
        class Axe : items, damagable, quest
        {
            //No reference to quest
            public string name { get; set; }
            public int goldValue { get; set; }
            public int durability { get; set; }
            public Axe(string _name)
            {
                name = _name;
                goldValue = 70;
                durability = 50;
            }
            public void equip()
            {
                Console.WriteLine(name + " equiped ");
            }
            public void sell()
            {
                Console.WriteLine($"{name} { " sold for "} { goldValue}");
            }
            public void takedamage(int _dmg)
            {
                durability -= _dmg;
                if (durability < 0)
                {
                    durability = 0;
                }
                Console.WriteLine(name + " damaged by " + _dmg +
                    " it now has the durability of " + durability);
            }
            public void TurnIn()
            {
                Console.WriteLine(name + " Turned In(It was an Axe)");
            }
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            sword sw = new sword("Doom Bringer");
            sw.sell();
            sw.equip();
            sw.takedamage(20);
            sw.TurnIn();

            Console.WriteLine();

            Axe ax = new Axe("Fury Axe");
            ax.sell();
            ax.equip();
            ax.takedamage(40);

            Console.WriteLine();

            //Create Inventory
            items[] inventory = new items[2];
            inventory[0] = sw;
            inventory[1] = ax;

            //Turn in all items
            for(int i = 0; i < inventory.Length; i++)
            {
                quest questItem = inventory[i] as quest;
                if (questItem != null)
                {
                    questItem.TurnIn();
                }
            }

            Console.ReadLine();
            
        }
    }
}
