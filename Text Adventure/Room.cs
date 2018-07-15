using System;
using System.Collections.Generic;

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

        public void AddDoor(Door door)
        {
            doors.Add(door);
        }

        public List<Door> GetDoors()
        {
            return new List<Door>(doors);
        }

        public List<Npc> GetNpcs()
        {
            return new List<Npc>(npcs);
        }

        public void AddNpc(Npc npc)
        {
            npcs.Add(npc);
        }

        public void RemoveNpc(Npc npc)
        {
            if(npcs.Contains(npc))
            {
                npcs.Remove(npc);
            }
        }

        public List<Item> GetInventory()
        {
            return new List<Item>(inventory);
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

        public string GetTitle()
        {
            return roomName;
        }

        public string GetDescription()
        {
            return roomDescription;
        }
    }
}
