using System;
using System.Collections.Generic;

namespace Text_Adventure
{
    class Player
    {
        private int health;
        private List<Item> inventory;

        public Player(int _health)
        {
            inventory = new List<Item>();
            health = _health;
        }


        public List<Item> GetInventory()
        {
            return new List<Item>(inventory);
        }

        public void ShowInventory()
        {
            if ( inventory.Count > 0 )
			{
			    Console.WriteLine("\nI carried the following things: \n");

			    foreach ( Item item in inventory )
			    {
			        Console.WriteLine(item.GetName());
			    }
			}
			else
			{
			    Console.WriteLine("\nI had no items with me.\n");
			}
            return;
        }

        public int GetHealth()
        {
            return health;
        }

        public int ReduceHealth()
        {
            health = health - 10;
            return health;
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
            }
        }

        public Item PlayerdropItem(string itemName)
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
