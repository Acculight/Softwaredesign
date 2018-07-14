using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Adventure
{
    public class Room
    {
       private string roomName;
       private string roomDescription;
        private List<Door> doors;
        private List<Item> inventory;
        private List<Npc> npcs;
        
        public Room(string name, string description)
        {
            roomName = name;
            roomDescription = description;
            doors = new List<Door>();
            inventory = new List<Item>();
            npcs = new List<Npc>();
        }

        public void addDoor(Door door)
        {
            doors.Add(door);
        }

        public List<Door> getDoors()
        {
            return new List<Door>(doors);
        }

        public List<Npc> getNpcs()
        {
            return new List<Npc>(npcs);
        }

        public void addNpc(Npc npc)
        {
            npcs.Add(npc);
        }

        public void removeNpc(Npc npc)
        {
            if(npcs.Contains(npc))
            {
                npcs.Remove(npc);
            }
        }

        public List<Item> getInventory()
        {
            return new List<Item>(inventory);
        }

        public void addItem(Item item)
        {
            inventory.Add(item);
        }

        public void removeItem(Item item)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
            }
        }

        public string getTitle()
        {
            return roomName;
        }

        public string getDescription()
        {
            return roomDescription;
        }

        public void setDescription(string description)
        {
            roomDescription = description;
        }
    }
}
