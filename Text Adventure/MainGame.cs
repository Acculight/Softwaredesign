using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Adventure
{
    class MainGame
    {
       Room currentRoom;
       Room lastRoom;
       Npc currentNpc;
       Player player;
       Random attackValueFight;
       private List<Room> allRooms;
       private List<Npc> allNpcs;
       public bool running = true;
       private bool gameOver = false;
       int turnCounter;
       bool caseSolfed = false;

        public MainGame()
        {
            allRooms = new List<Room>();
            allNpcs = new List<Npc>();
            Random random = new Random();
            turnCounter = 0;

            //Initialize Player
            Player mainPlayer = new Player(100);
            player = mainPlayer;

            //Map

            //Driveway
            Room r1 = new Room("Driveway", "A long road led to the noble entrance doors of 'Battenberg Mannor'. Tall, well maintained hedges surrounded the place. My car was standing in front of the large marble stairs.");
            Item car = new Item("car", "My car, an old Hudson that had seen better days.", false);
            r1.addItem(car);
            

            //Entrance Hall
            Room r2 = new Room("Entrance Hall", "A large room, with several columns and a floor made out of marvel. 2 police officers were gathering around a lifeless body.");
            Item dagger = new Item("dagger", "The dagger was completely made out of stone. Strange symbols were engraved in the blade. They looked familiar to me, althoug i was shure that i had never seen them bevore.", true);
            Item body = new Item("Dead body", "The dead Body of a young woman. She was stabbed in the chest with a fancy dagger, but it seems to have missed hear heart.", false);
            Item bloodtraces = new Item("Blood traces", "There were blood traces on the floor. As if the victim would have runned for her life and collapsed here. They seemed to leed to the eastern door.", false);
            Npc butler = new Npc("Alfred Sharp", "Grey hair, a small mustache and a perfectly aligned suit dressed that man. He looked exactly like you would imagine a butler to.", true, "'Well Mr. Grifford, despite this terrible happenings today, i have much work to do. Because of the absence of Lord Charlie Battenberg till tomorrow. And before you ask, i have been in the service Room this whole day, assisting Lady Battenberg. The only stange thing, exept the 'incident', is that my precious cleaning mop is missing since this morning.", 100, r2);
            Npc police = new Npc("The Police", "Two police officers guarded the crime scene.", false, "Well Mr. Grifford, you may start with your investigation. If you should find anything... conclusive, don't hesitade to tell us.", 100, r2);
            r2.addItem(dagger);
            r2.addItem(body);
            r2.addItem(bloodtraces);
            
            //Dining Hall
            Room r3 = new Room("Dining Hall", "A long table filled the middle of the room. It was prepared for one person.");
            Item note = new Item("note", "On the note was written: 'Meet me in the library' It is signed with the letter 'C'.", true);
            Npc lady = new Npc("Lady Battenberg", "She was an elder lady. Light grey hair and a classical long dress finished her look.", false, "Oh, it is terrible! Poor Isabelle... She left this world too early. And what is my husband going to say when he returns... . I nearly forgott, this is the key to my husbands office. You might need it for your investigation.", 100, r3);
            Item key = new Item("Key", "The Key to the office of Lord Battenberg", true);
            lady.addItem(key);
            r2.addItem(note);

            //Kitchen
            Room r4 = new Room("Kitchen", "A white stained room, that looks like a kitchen that is used by experienced people.");
            Npc cook = new Npc("Agate Murror", "A well feeded woman, with short brown hair. She is wearing a typical white kitchen uniform and looks quite bussy", false, "'I don't know what happened. I have been in the kitchen the whole day. I was looking for a thief. In the last days, food has been disappearing and i am going to find out why!'", 100, r4);

            //Floor
            Room r5 = new Room("Floor", "A long floor with several doors.");


            //Library
            Room r6 = new Room("Library", "Tall bookshelfes covered the walls. Cobwebs and dust were all obout the place. Execpt one shelf. It looked well used.");
            Item floor = new Item("wet floor", "The floor seemed to be cleaned not long ago.", false);
            Item book1 = new Item("Book: The Great book of plants", "A book about plants all over the world.", true);
            Item book2 = new Item("Book: Ancient south american mythologie", "It said something about the ancient Atzteks and their rituals and religion. Strange, the dagger that killed the victim, had the same symbols engraved.", true);
            Item book3 = new Item("Book: The art of making money", "Crash course to get rich in only three generations.", true);
            r6.addItem(floor);

            //Office
            Room r7 = new Room("Office", "A large desk with many paper work on it. Lord Battenberg seemed to be very interested in ancient history.");

            //Secret Passage
            Room r8 = new Room("Secret passage", "A long tunnel, with torches. Strange, they were burning.");

            //Secret Chamber
            Room r9 = new Room("Secret chamber", "The chamber was filled with torch light. In the middle was a man, bowed over an altar of stone. It was edged in blood.");
            Npc lord = new Npc("Lord Battenberg", "He was spilled with blood. His face was mad. He wispered strange words in a language i could not understand.", true, "Oh, who are you? Mhh, actually it doesn't matter anyway. You will make a fine addition to my ritual!", 100, r8);

            //Add Doors
            r1.addDoor(new Door(Door.Directions.North, r2, "north", false));
            r2.addDoor(new Door(Door.Directions.South, r1, "south", false));
            r2.addDoor(new Door(Door.Directions.West, r3, "west", false));
            r2.addDoor(new Door(Door.Directions.East, r5, "east", false));
            r3.addDoor(new Door(Door.Directions.North, r4, "north", false));
            r3.addDoor(new Door(Door.Directions.East, r2, "east", false));
            r4.addDoor(new Door(Door.Directions.South, r3, "south", false));
            r5.addDoor(new Door(Door.Directions.West, r2, "west", false));
            r5.addDoor(new Door(Door.Directions.East, r7, "east", true));
            r5.addDoor(new Door(Door.Directions.South, r6, "north", false));
            r6.addDoor(new Door(Door.Directions.South, r5, "south", false));
            r7.addDoor(new Door(Door.Directions.West, r5, "west", false));
            r8.addDoor(new Door(Door.Directions.South, r6, "south", false));
            r8.addDoor(new Door(Door.Directions.North, r9, "north", false));
            r9.addDoor(new Door(Door.Directions.South, r8, "south", false));
            
            allNpcs.Add(butler);
            allNpcs.Add(lady);
            allNpcs.Add(cook);

            allRooms.Add(r1);
            allRooms.Add(r2);
            allRooms.Add(r3);
            allRooms.Add(r4);
            allRooms.Add(r5);
            allRooms.Add(r6);

            //r1.addNpc(allNpcs.Find(x => x.getCurrentRoom().Equals(r1)));
            r2.addNpc(allNpcs.Find(x => x.getCurrentRoom().Equals(r2)));
            r3.addNpc(allNpcs.Find(x => x.getCurrentRoom().Equals(r3)));
            r4.addNpc(allNpcs.Find(x => x.getCurrentRoom().Equals(r4)));
            //r5.addNpc(allNpcs.Find(x => x.getCurrentRoom().Equals(r5)));
            //r6.addNpc(allNpcs.Find(x => x.getCurrentRoom().Equals(r6)));
            //r7.addNpc(allNpcs.Find(x => x.getCurrentRoom().Equals(r7)));
            //r8.addNpc(allNpcs.Find(x => x.getCurrentRoom().Equals(r8)));
            r9.addNpc(allNpcs.Find(x => x.getCurrentRoom().Equals(r9)));

            currentRoom = r1;
            currentNpc = butler;

            //Intro
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("It was one of those rainy days in London, when i, Ian Griffort, private Detective, got called to help by the local Police.");
            Console.WriteLine("The houde maiden had been found dead. Stabbed by in the back.");
            Console.WriteLine("It took about an hour, then i arrived at Battenberg Manor.");
            Console.WriteLine("The Police had already finished it's investigation but it ended without a result.");
            Console.WriteLine("It was on me, to find out what happened there.");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("I arrived at the ");
            showRoom();

            Console.WriteLine("For a list of commands type 'h' or 'help'.");
        }

        //commands
        public void commands(string command)
        {
           // try
            //{

            if((command == "help") || (command == "h"))
            {
                Console.WriteLine("help(l), look(l), look at <Npc or Item>, inventory(i), take <Item>, drop <item>, talk to <Npc>, attack <Npc>, use <Item>, move <Direction>");
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
                player.showInventory();
                return;
            }


            //command: "move"
            if((command.Length >= 4) & (command.Substring(0, 4) == "move"))
            {
                move(command.Substring(5));
                return;
            }

 
            //command: "take"
            if((command.Length >= 4) & (command.Substring(0, 4) == "take"))
            {

                if (command == "take")
                {
                    Console.WriteLine("\nName a specific item to take.\n");
                    return;
                }

                if(command == "take Book: Ancient south american mythologie")
                {
                    Console.WriteLine("The moment i pulled the book out of the shelf, the wall began to move and opened a secret passage way.");
                    currentRoom.addDoor(new Door(Door.Directions.North, allRooms.Find(x => x.getTitle().Equals("Secret passage")), "north", false));
                }

                if ((currentRoom.getInventory().Exists(x => x.getName == command.Substring(5))) & (currentRoom.getInventory().Exists(x => x.getUseable == true)))
                {
                    player.addItem(currentRoom.getInventory().Find(x => x.getName == command.Substring(5)));
                    currentRoom.removeItem(currentRoom.getInventory().Find(x => x.getName == command.Substring(5)));
                    Console.WriteLine("\nI picked up the " + command.Substring(5) + ".\n");
                    return;
                }

                if ((currentRoom.getInventory().Exists(x => x.getName == command.Substring(5))) & (currentRoom.getInventory().Exists(x => x.getUseable == false)))
                {
                    Console.WriteLine("\nI was unable to take the " + command.Substring(5) + ".\n");
                    return;
                }
                
                else
                {
                    Console.WriteLine("\nThere was no " + command.Substring(5) + "\n");
                    return;
                }
            }

            //command: "drop"
            if((command.Length >= 4) & (command.Substring(0, 4) == "drop"))
            {

                if (command == "drop")
                {
                    Console.WriteLine("\nName a specific item to drop.\n");
                    return;
                }

                if (player.getInventory().Exists(x => x.getName == command.Substring(5)))
                {
                    currentRoom.addItem(player.getInventory().Find(x => x.getName == command.Substring(5)));
                    player.removeItem(player.getInventory().Find(x => x.getName == command.Substring(5)));
                    Console.WriteLine("\nI dropped the " + command.Substring(5) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\nI had no " + command.Substring(5) + "to drop.\n");
                    return;
                }
            }


            //command: "attack"
            if((command.Length >= 6) & (command.ToLower().Substring(0, 6) == "attack"))
            {
                if(command == "attack")
                {
                    Console.WriteLine("\nI knew i had to attack, but whom?");
                    return;
                }

                if(currentRoom.getNpcs().Exists(x => x.getName.ToLower().Equals(command.ToLower().Substring(7))))
                {
                    currentNpc = currentRoom.getNpcs().Find(x => x.getName.ToLower() == command.ToLower().Substring(7));
                    attack();
                    return;
                }
                return;
            }
           /* if((command.Length >= 6) & (command.Substring(0, 6) == "attack"))
                 {
                     attack(command);
                     return;
                 }*/


            //command: "look at"
            if((command.Length >= 7) & (command.Substring(0, 7) == "look at"))
            {
                if(command == "look at")
                {
                    Console.WriteLine("\nI was not shure what or whom i wanted to look at.\n");
                    return;
                }

                if(currentRoom.getNpcs().Exists(x => x.getName.ToLower().Equals(command.ToLower().Substring(8))))
                {
                    Console.WriteLine("\n" + currentRoom.getNpcs().Find(x => x.getName.ToLower().Equals(command.ToLower().Substring(8))).getDescription + "\n");
                    return;
                }
                if(currentRoom.getInventory().Exists(x => x.getName == command.Substring(8)))
                {
                    Console.WriteLine("\n" + currentRoom.getInventory().Find(x => x.getName.ToLower().Equals(command.ToLower().Substring(8))).getDescription + "\n");
                    return;
                }
                if(player.getInventory().Exists(x => x.getName == command.Substring(8)))
                {
                    Console.WriteLine("\n" + player.getInventory().Find(x => x.getName.ToLower().Equals(command.ToLower().Substring(8))).getDescription + "\n");
                    return;
                }
                Console.WriteLine("\nIt was nothing there.\n");
                return;
            }
            

            //command: "talk to"
            if((command.Length >= 7) & (command.Substring(0, 7) == "talk to"))
            {
                if(command == "talk to")
                {
                    Console.WriteLine("\nI started talking, but it was no one there.");
                    return;
                }

                if(command.ToLower() == "talk to lord battenberg")
                {
                    currentNpc = currentRoom.getNpcs().Find(x => x.getName.ToLower() == command.ToLower().Substring(8));
                    Console.WriteLine("I drew his attention to me. He locked at me and began smiling: \n" + currentNpc.getAnswer());
                    commands("attack Lord Battenberg");
                    return;
                }
                if((command.ToLower() == "talk to the police") & (caseSolfed == true))
                {
                    Console.WriteLine("I told the police about the madness happening within the secret chamber. The police took care of him and the paper work. The whole happening was found news for the press. But i still can't get loose of this case. His mad eyes, i still fell them looking at me. ");
                }

                if(currentRoom.getNpcs().Exists(x => x.getName.ToLower().Equals(command.ToLower().Substring(8))))
                {
                    currentNpc = currentRoom.getNpcs().Find(x => x.getName.ToLower() == command.ToLower().Substring(8));
                    Console.WriteLine("I asked " + currentNpc.getName + " about the case. He answered:\n" + currentNpc.getAnswer());
                    if(currentNpc.getName == "Lady Battenberg")
                    {
                        npcGiveItem(currentNpc.getInventory().Find(x => x.getName == "Key"), currentNpc);
                        Door door = allRooms.Find(x => x.getTitle() == "Floor").getDoors().Find(y => y.getdirectionName().Equals("east"));
                        door.setLocked(false);
                        Console.WriteLine("She gave me the key to the Office.");
                    }
                    return;
                }
                return;
            }


            //No valid command
            Console.WriteLine("\nI am pretty shure i did not do that. (invalid command).\n");
            return;
          //  }
        
            /*catch
            {
                Console.WriteLine("\nI am pretty shure i did not do that (invalid command).\n");
                return;
            }*/
            }


            //Method: "Move"
            private void move(string command)
            {
                    foreach(Door door in currentRoom.getDoors())
                    {
                        if((command == door.getdirectionName()) || (command == door.getmoveShortcuts().ToLower()))
                        {
                            if(door.getLocked() == false)
                            {
                                lastRoom = currentRoom;
                                currentRoom = door.getLeadsTo();
                                Console.WriteLine("\nI stepped into the ");
                                showRoom();
                                return;
                            }
                            if(door.getLocked() == true)
                            {
                                Console.WriteLine("I wanted to walk through the door. But it was locked.");
                                return;
                            }
                        }     
                }
                return;
            }

            //Method: "Move Npc"
            public void moveNpc(string npc, string room)
            {   
                Npc _currentNpc = allNpcs.Find(x => x.getName.Equals(npc));
                Room npcCurrentRoom = allRooms.Find(y => y.Equals(allNpcs.Find(x => x.getName.Equals(npc)).getCurrentRoom()));
                Room npcNewRoom = allRooms.Find(x => x.getTitle().Equals(room));
                npcCurrentRoom.removeNpc(_currentNpc);
                npcNewRoom.addNpc(_currentNpc);
                _currentNpc.changeCurrentRoom(npcNewRoom);
                return;
            }

            //Method: "Events"
            public void Events()
            {
                if(turnCounter > 15)
                {
                    moveNpc("Alfred Sharp", "Floor");
                }

                /*if(allNpcs.Find(x => x.getName.Equals("Lord Battenberg")).getHealth() <= 0)
                {
                    Console.WriteLine("I killed the mad lord. The police took care of the paper work and the whole happening was found news for the press. But i still can't get loose of this case. His mad eyes, i still feel them looking at me.");
                    gameOver = true;
                }*/

                if(currentRoom.getTitle() == "Secret chamber")
                {
                    caseSolfed = true;
                }
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

                Events();

                if(!gameOver)
                {
                    turnCounter = turnCounter + 1;
                    commands(currentCommand);
                }
                else
                {
                    Console.WriteLine("\n-The game ended-");
                }
            }

            //Method: "attack"
            public void attack()
            { 
                    if(currentNpc.getFightable == true)
                    {
                        while((player.getHealth() > 0) & (currentNpc.getHealth() > 0))
                        { 
                            int attackValuePlayer = attackValueFight.Next(0, 1);
                            int attackValueNpc = attackValueFight.Next(0, 1);
                            Console.WriteLine("The fight began!");
                            Console.WriteLine("I attacked " + currentNpc.getName + ".");

                            if(attackValuePlayer != attackValueNpc)
                            {
                                currentNpc.reduceHealth();
                                Console.WriteLine("That attack did hit!");
                            }
                            else
                            {
                                Console.WriteLine("I remember missing that attack!");
                            }
                            Console.WriteLine("Mhh, i can't remember if i did continue the fight... (j/n)");
                            if(Console.ReadLine() == "n")
                            {
                                currentRoom = lastRoom;
                                Console.WriteLine("I managed to escape the fight into the " + currentRoom.getTitle() + "!");
                                return;
                            }

                            Console.WriteLine(currentNpc.getName + " attacked!");
                            if(attackValueNpc != attackValuePlayer)
                            {
                                player.reduceHealth();
                                Console.WriteLine(currentNpc.getName + "'s attack did hit!");
                                Console.WriteLine("I felt like i had " + player.getHealth() + "% of my strenght remaining.");
                            }
                            else
                            {
                                Console.WriteLine("I remember " + currentNpc.getName + " missing that attack!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("I can't remember fighting against " + currentNpc.getName + ".");
                        return;
                    }

                    if(player.getHealth() > 0)
                    {
                        Console.WriteLine("My enemy trambeled and died. " + currentNpc.getName + " lied dead on the ground.");
                        Item deadEnemy = new Item("Dead body of " + currentNpc.getName, currentNpc.getDescription + " But then " + currentNpc.getName + " lied dead to my feet.", false);
                        currentRoom.addItem(deadEnemy);
                        currentRoom.removeNpc(currentNpc);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("And that is how i died. It is strange when you think about it.");
                        Console.WriteLine("\n-The game ended-");
                        running = false;
                        return;
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
                        Console.WriteLine("a " + currentRoom.getInventory()[i].getName);
                    }
                }

                if(currentRoom.getNpcs().Count > 0)
                {
                    Console.WriteLine("\nAnd i remember ");
                    for(int i = 0; i < currentRoom.getNpcs().Count; i++)
                    {
                        Console.WriteLine(currentRoom.getNpcs()[i].getName);
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

            //Method: "Npc give Item"
            public void npcGiveItem(Item item, Npc npc)
            {
                npc.removeItem(item);
                player.addItem(item);
                return;
            }

            //Method: "Player give Item"
            public void playerGiveItem(Item item, Npc npc)
            {
                player.removeItem(item);
                npc.addItem(item);
            }
    }           
}

