using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            while(game.running)
            {
                game.Update();
            }
        }

    }



//Klasse MainGame
class Game
    {
       Room currentRoom;
       Npc currentNpc;
       Player player;
       public bool running = true;
       private bool gameOver = false;

        public Game()
        {
            //Map

            //Driveway
            Room r1 = new Room("Driveway", "A long road led to the noble entrance doors of 'Battenberg Mannor'. Tall, well maintained hedges surrounded the place. My car was standing in front of the large marble stairs.");
            Item car = new Item("My car", "My car, an old --- that has seen better days.", false);
            r1.addItem(car);
            

            //Entrance Hall
            Room r2 = new Room("Entrance Hall", "A large room, with several columns and a floor made out of marvel. 2 police officers are gathering around a lifeless body.");
            Evidence body = new Evidence("The dead body of the victim", "The dead Body of a young woman. She was stabbed in the chest with a fancy dagger, but it seems to have missed hear heart.");
            Item dagger = new Item("A fancy dagger", "The dagger was completely made out of stone. Strange symbols were engraved in the blade. They looked familiar to me, althoug i was shure that i had never seen them bevore.", false);
            r2.addItem(dagger);
            r2.addEvidence(body);
            
            //Dining Hall
            Room r3 = new Room("Dining Hall", "A long table filled the middle of the room");
            Evidence note = new Evidence("A hand written note", "On the note is written: 'Meet me in the library' It is signed with ne letter 'C'.");
            r2.addEvidence(note);

            //Kitchen
            Room r4 = new Room("Kitchen", "A white stained room, that looks like a kitchen that is used by experienced people.");
            Npc cook = new Npc("Agate Murror", "A well feeded woman, with short brown hair. She is wearing a typical white kitchen uniform and looks quite bussy", false, "'I don't know what happened. I have been in the kitchen the whole day. I was looking for a thief. In the last days, food has been disappearing and i am going to find out why!'", 100);
            r4.addNpc(cook);

            r1.addDoor(new Door(Door.Directions.North, r2, "north"));
            r2.addDoor(new Door(Door.Directions.West, r3, "west"));
            r2.addDoor(new Door(Door.Directions.North, r4, "north"));
            r3.addDoor(new Door(Door.Directions.East, r2, "east"));
            r4.addDoor(new Door(Door.Directions.South, r3, "south"));

            currentRoom = r1;
            currentNpc = cook;

            //Intro
            Console.WriteLine("It was one of those rainy days in London, when i, Ian Griffort, private Detective, got called to help by the local Police.");
            Console.WriteLine("The Hausmädchen had been found dead. Stabbed by in the back.");
            Console.WriteLine("It took about an hour, then i arrived at Battenberg Manor.");
            Console.WriteLine("The Police had already finished it's investigation but it ended without a result.");
            Console.WriteLine("It was on me, to find out what happened here.");
            Console.WriteLine("\n" + "\n");
            Console.WriteLine("I arrived at the ");
            showRoom();

            Console.WriteLine("For a list of commands type 'h' or 'help'.");
        }

        //commands
        public void commands(string command)
        {
            //command: "help"
            if((command == "help") || (command == "h"))
            {
                Console.WriteLine("help(l), look(l), look at <Npc or Item>, inventory(i), take <Item>, attack <Npc>, use <Item>, move <Direction>");
                return;
            }

            //command: "look"
            if((command == "look") || (command == "l"))
            {
                showRoom();
                return;
            }

            //command: "inventory"
            if ((command == "inventory") || (command == "i"))
            {
                player.getInventory();
                return;
            }
 
            //command: "take"
            if((command.Length >= 4) & (command.Substring(0, 3) == "take"))
            {

                if (command == "take")
                {
                    Console.WriteLine("\nName a specific item to take.\n");
                    return;
                }

                if ((currentRoom.getInventory().Exists(x => x.getName == command.Substring(5))) || (currentRoom.getInventory().Exists(x => x.getUseable == true)))
                {
                    player.addItem(currentRoom.playertakeItem(command.Substring(5)));
                    Console.WriteLine("\nI picked up the" + command.Substring(5) + ".\n");
                    return;
                }

                if ((currentRoom.getInventory().Exists(x => x.getName == command.Substring(5))) || (currentRoom.getInventory().Exists(x => x.getUseable == false)))
                {
                    Console.WriteLine("\nI was unable to take the" + command.Substring(5) + ".\n");
                    return;
                }
                
                else
                {
                    Console.WriteLine("\nThere was no" + command.Substring(5) + "\n.");
                    return;
                }
            }

            //command: "look at"
            if((command.Length >= 7) & (command.Substring(0, 6) == "look at"))
            {
                if(command == "look at")
                {
                    Console.WriteLine("\nI was not shure what i wanted to look at.\n");
                    return;
                }

                if(currentRoom.getInventory().Exists(x => x.getName == command.Substring(8)))
                {
                    Console.WriteLine("\n" + currentRoom.getInventory().Find(x => x.getName.Contains(command.ToLower().Substring(8))).getDescription + "\n");
                    return;
                }
                if(player.getInventory().Exists(x => x.getName == command.Substring(8)))
                {
                    Console.WriteLine("\n" + player.getInventory().Find(x => x.getName.Contains(command.ToLower().Substring(8))).getDescription + "\n");
                    return;
                }
                else
                {
                Console.WriteLine("\nThere was no such item\n");
                return;
                }
            }
            
/*
            //command: "attack"
            if((command.Length >= 6) || (command.Substring(0, 5) == "attack"))
                 {
                     attack(command);
                     return;
                 }
            
 
            //command: "use" - "with"
            if((command.Length >= 3) || (command.Substring(0, 2)) == "use")
            {
                if(command == "use")
                {
                    Console.WriteLine("\nI am not shure what i wanted to use then.\n");
                    return;
                }

                if(player.getInventory().Exists(x => x.getName == command.ToLower().Substring(4)))
                {
                    Console.WriteLine("\nUse " + command.Substring(4) + " with?\n");
                    string secondItem = Console.ReadLine();
                    if(currentRoom.getInventory().Exists(x => x.getName == secondItem))
                    {
                        if((secondItem == "itemname") || (command.Substring(4) == "rock"))
                        {
                           // ereignisse einfügen
                        }
                    }
                    return;
                }
            }
*/          
            //talk to
            if((command.Length >= 7) & (command.Substring(0, 6) == "talk to"))
            {
                if(command == "talk to")
                {
                    Console.WriteLine("\nI started talking, but it was no one there.");
                    return;
                }

                if(currentRoom.getNpcs().Exists(x => x.Name == command.ToLower().Substring(8)))
                {
                    currentNpc = currentRoom.getNpcs().Find(x => x.Name == command.ToLower().Substring(8));
                    Console.WriteLine(currentNpc.Name + ": " + currentNpc.getAnswer());
                    return;
                }
                return;
            }

            //move
            if((command.Length >= 4) & (command.Substring(0, 4) == "move"))
            {
                if(command == "move")
                {
                    Console.WriteLine("\nI was not shure where i should go.");
                    return;
                }
                if(currentRoom.getDoors().Exists(x => x.getdirectionName() == command.ToLower().Substring(5)))
                {
                    move(command.ToLower().Substring(5));
                    return;
                }
                return;
            }
            
            Console.WriteLine("\nI am pretty shure i did not do that (invalid command).\n");
            return;
        }

            //Method: "Move"
            private bool move(string command)
            {
                foreach(Door door in currentRoom.getDoors())
                {
                    if((command == door.ToString().ToLower() || (command == door.getmoveShortcuts().ToLower())))
                    {
                        currentRoom = door.getLeadsTo();
                        Console.WriteLine("\nI stepped into the " + door.ToString() + " to the:\n");
                        showRoom();
                        return true;
                    }
                }
                return false;
            } 

            //Method: "UpdateGame"
            public void Update()
            {
                string currentCommand = Console.ReadLine().ToLower();
                if((currentCommand == "quit") || (currentCommand == "q"))
                {
                    Console.WriteLine("Obviously i am boring you with my story. Well then, fare well...");
                    Console.WriteLine("\n-The game ended-");
                    running = false;
                    return;
                }

                if(!gameOver)
                {
                    commands(currentCommand);
                }
                else
                {
                    Console.WriteLine("\n-The game ended-");
                }
            }

            //Method: "attack"
            public void attack(string command)
            {
                if(command == "attack")
                {
                    Console.WriteLine("\nI knew i had to attack, but whom?\n");
                    return;
                 }

                if(currentRoom.getNpcs().Find(x => x.Name.Contains(command.ToLower().Substring(6))).fightable == true)
                {
                    
                }
            }

        //Method: "ShowRoom"
            public void showRoom()
        {
            Console.WriteLine("\n" + currentRoom.getTitle() + "\n");
            Console.WriteLine(currentRoom.getDescription());

            if(currentRoom.getInventory().Count > 0)
            {
                Console.WriteLine("\nIn the " + currentRoom.getTitle() + " were:" );
                for(int i = 0; i < currentRoom.getInventory().Count; i++)
                {
                    Console.WriteLine(currentRoom.getInventory()[i].getName);
                }
            }

            if(currentRoom.getNpcs().Count > 0)
            {
                Console.WriteLine("\nAnd i remember ");
                for(int i = 0; i < currentRoom.getNpcs().Count; i++)
                {
                    Console.WriteLine(currentRoom.getNpcs()[i].Name);
                }
                Console.Write(" being in the " + currentRoom.getTitle());
            }

            Console.WriteLine("\nThe " + currentRoom.getTitle() + " had an Exit in the\n");
			foreach (Door doors in currentRoom.getDoors())
			{
				Console.WriteLine(doors.getDirections());
			}
            Console.WriteLine();
            return;
        }
    }



//Klasse Room
public class Room
    {
       private string roomName;
       private string roomDescription;
        private List<Door> doors;
            private List<Item> inventory;
            private List<Npc> npcs;
            private List<Evidence> evidence;
        
        public Room(string name, string description)
        {
            roomName = name;
            roomDescription = description;
            doors = new List<Door>();
            inventory = new List<Item>();
            npcs = new List<Npc>();
            evidence = new List<Evidence>(); 
        }

        public void addDoor(Door door)
        {
            doors.Add(door);
        }

        public void sealDoor(Door door)
        {
            if(doors.Contains(door))
            {
                doors.Remove(door);
            }
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

        public void addEvidence(Evidence _evidence)
        {
            evidence.Add(_evidence);
        }

        public Evidence npcaddEvidence(string evidenceName)
        {
            foreach (Evidence _evidence in evidence)
            {
                if(_evidence.name == evidenceName)
                {
                    Evidence pte = _evidence;
                    evidence.Remove(pte);
                    return pte;
                }
            }
            return null;
        }

        public void removeEvidence(Evidence _evidence)
        {
            if(evidence.Contains(_evidence))
            {
                evidence.Remove(_evidence);
            }
        }

        public List<Evidence> getEvidence()
        {
            return new List<Evidence>(evidence);
        }

        public Evidence playertakeEvidence(string evidenceName)
        {
            foreach (Evidence _evidence in evidence)
            {
                if(_evidence.name == evidenceName)
                {
                    Evidence pte = _evidence;
                    evidence.Remove(pte);
                    return pte;
                }
            }
            return null;
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

        public Item playertakeItem(string itemName)
        {
            foreach (Item _item in inventory)
            {
                if(_item.name == itemName)
                {
                    Item pti = _item;
                    inventory.Remove(pti);
                    return pti;
                }
            }
            return null;
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



//Klasse Npc
public class Npc
    {
        private string name;
        public bool fightable;
        private string description;
        public string answer;
        private List<Evidence> evidence;
        int health;


        public Npc(string _name, string _description, bool _fightable, string _answer, int _health)
        {
            name = _name;
            fightable = _fightable;
            description = _description;
            answer = _answer;
            health = _health;
        }

        public string Name
        {
            get {return name;}
        }

        public bool Fightable
        {
            get {return fightable;}
        }

        public string Description
        {
            get {return description;}
        }

        public string getAnswer()
        {
            return answer;
        }

        public void changeAnswer(string _answer)
        {
            answer = _answer;
        }

        public int getHealth()
        {
            return health;
        }

    }



//Klasse Item
public class Item
    {
        public string name;
        private bool useable;
        private bool needsItem;
        private string description;

        public Item(string _name, string _description, bool _useable)
        {
            name = _name;
            useable = _useable;
            description = _description;
        }

        public string getName
        {
            get {return name;}
        }

        public bool getUseable
        {
            get {return useable;}
        }

        public string getDescription
        {
            get {return description;}
        }
    }



//Klasse Door
public class Door
    {
        public enum Directions
        {
            Undefiend, North, East, South, West
        }

        public static string[] moveShortcuts = {"Null", "N", "E", "S", "W"};

        private Room leadsTo;
        private Directions direction;
        private string directionName;

        public Door(Directions _direction, Room newLeadsTo, string _directionName)
        {
            direction = _direction;
            leadsTo = newLeadsTo;
            directionName = _directionName;
        }

        public void setDirection(Directions _direction)
        {
            direction = _direction;
        }

        public Directions getDirections()
        {
            return direction;
        }

        public string getmoveShortcuts()
        {
            return moveShortcuts[(int)direction].ToLower();
        }

        public void setleadsTo(Room _leadsTo)
        {
            leadsTo = _leadsTo;
        }

        public Room getLeadsTo()
        {
            return leadsTo;
        }

        public string getdirectionName()
        {
            return directionName;
        }

    }



//Klasse Player
class Player
    {
        int health;
        
        private List<Item> inventory;

        public Player()
        {
            inventory = new List<Item>();
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



//Klasse Evidence
public class Evidence
    {
        public string name;
        private string description;

        public Evidence(string _name, string _description)
        {
            name = _name;
            description = _description;
        }

        public string Name
        {
            get {return name;}
        }

        public string Description
        {
            get {return description;}
        }
    }
