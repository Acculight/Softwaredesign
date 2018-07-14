using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Npc(string _name, string _description, bool _fightable, string _answer, int _health, Room _currenRoom)
        {
            name = _name;
            fightable = _fightable;
            description = _description;
            answer = _answer;
            health = _health;
            currentRoom = _currenRoom;
            inventory = new List<Item>();
        }
    
        public void changeCurrentRoom(Room room)
        {
            currentRoom = room;
            return;
        }

        public Room getCurrentRoom()
        {
            return currentRoom;
        }

        public string getName()
        {
            return name;
        }

        public bool getFightable()
        {
            return fightable;
        }

        public string getDescription()
        {
            return description;
        }

        public string getAnswer()
        {
            return answer;
        }

        public int getHealth()
        {
            return health;
        }

        public void reduceHealth()
        {
            health = health - 15;
        }

        public List<Item> getInventory()
        {
            return inventory;
        }

        public void addItem(Item item)
        {
            inventory.Add(item);
        }

        public void removeItem(Item item)
        {
            inventory.Remove(item);
        }
    }
}
