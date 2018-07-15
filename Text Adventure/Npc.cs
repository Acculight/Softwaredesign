using System;
using System.Collections.Generic;

namespace Text_Adventure
{
    public class Npc
    {
        private string name;
        private bool fightable;
        private string description;
        private string answer;
        private int health;
        private Room currentRoom;
        private List<Item> inventory;

        public Npc(string _name, string _description, bool _fightable, string _answer, int _health, Room _currentRoom)
        {
            name = _name;
            fightable = _fightable;
            description = _description;
            answer = _answer;
            health = _health;
            currentRoom = _currentRoom;
            inventory = new List<Item>();
        }
    
        public void ChangeCurrentRoom(Room room)
        {
            currentRoom = room;
            return;
        }

        public Room GetCurrentRoom()
        {
            return currentRoom;
        }

        public string GetName()
        {
            return name;
        }

        public bool GetFightable()
        {
            return fightable;
        }

        public string GetDescription()
        {
            return description;
        }

        public string GetAnswer()
        {
            return answer;
        }

        public int GetHealth()
        {
            return health;
        }

        public void ReduceHealth()
        {
            health = health - 15;
        }

        public List<Item> GetInventory()
        {
            return inventory;
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            inventory.Remove(item);
        }
    }
}
