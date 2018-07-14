using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Adventure
{
    class Player
    {
        int health;
        
        private List<Item> inventory;

        public Player(int _health)
        {
            inventory = new List<Item>();
            health = _health;
        }


        public List<Item> getInventory()
        {
            return new List<Item>(inventory);
        }

        public void showInventory()
        {
            if ( inventory.Count > 0 )
			{
			Console.WriteLine("\nI carried the following things: \n");

			foreach ( Item item in inventory )
			{
			Console.WriteLine(item.getName);
			}
			}
			else
			{
			Console.WriteLine("\nI had no items with me.\n");
			}
            return;
        }

        public int getHealth()
        {
            return health;
        }

        public int reduceHealth()
        {
            health = health - 10;
            return health;
        }

        public void addItem(Item item)
        {
            inventory.Add(item);
            Console.WriteLine("Debugg item : " + item);
        }

        public void removeItem(Item item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
            }
        }

        public Item playerdropItem(string itemName)
        {
            foreach (Item _item in inventory)
            {
                if(_item.name == itemName)
                {
                    Item pdi = _item;
                    inventory.Remove(pdi);
                    return pdi;
                }
            }
            return null;
        }
    }
}
