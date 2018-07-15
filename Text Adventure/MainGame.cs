using System;
using System.Collections.Generic;

namespace Text_Adventure
{
    class MainGame
    {
       private Room currentRoom;
       private Room lastRoom;
       private Room secretPassage;
       private Npc currentNpc;
       private Npc currentEnemy;
       private Player player;
       private List<Room> allRooms;
       private List<Npc> allNpcs;
       public bool running = true;
       private bool gameOver = false;
       private int turnCounter;
       private bool caseSolfed = false;

        public MainGame()
        {
            allRooms = new List<Room>();
            allNpcs = new List<Npc>();
            turnCounter = 0;
            Player mainPlayer = new Player(100);
            player = mainPlayer;

            //Map

            //Driveway
            Room r1 = new Room("Driveway", "A long road led to the noble entrance doors of 'Battenberg Mannor'. Tall, well maintained hedges surrounded the place. My car was standing in front of the large marble stairs.");
            Item car = new Item("car", "My car, an old Hudson that had seen better days.", false);
            r1.AddItem(car);
            
            //Entrance Hall
            Room r2 = new Room("Entrance Hall", "A large room, with several columns and a floor made out of marvel. Two police officers were gathering around a lifeless body.");
            Item dagger = new Item("dagger", "The dagger was completely made out of stone. Strange symbols were engraved in the blade. They looked familiar to me, althoug i was shure that i had never seen them bevore.", true);
            Item body = new Item("dead body", "The dead Body of a young woman. She got stabbed in the chest with a fancy dagger, but it seemed to had missed hear heart.", false);
            Item bloodtraces = new Item("blood trace", "There were blood traces on the floor. As if the victim would have runned for her life and collapsed there. The trace seemed to leed to the eastern door.", false);
            Item note = new Item("note", "In the victims pocket was a note. On the note was written: 'Meet me in the library' It was signed with the letter 'C'.", true);
            Npc butler = new Npc("Alfred Sharp", "Grey hair, a small mustache and a perfectly aligned suit dressed that man. He looked exactly like you would imagine a butler to look like.", true, "Well Mr. Grifford, despite this terrible happenings today, i have much work to do. Because of the absence of Lord Charlie Battenberg till tomorrow. And before you ask, i have been in the service Room this whole day, assisting Lady Battenberg. The only strange thing, exept the 'incident', is that my precious cleaning mop is missing since this morning.", 100, r2);
            Npc police = new Npc("The Police", "Two police officers guarded the crime scene.", false, "Well Mr. Grifford, you may start with your investigation. If you should find anything... conclusive, don't hesitade to tell us.", 100, r2);
            r2.AddItem(dagger);
            r2.AddItem(note);
            r2.AddItem(body);
            r2.AddItem(bloodtraces);
            r2.AddNpc(police);
            
            //Dining Hall
            Room r3 = new Room("Dining Hall", "A long dining table filled the middle of the room. It was prepared for one person.");
            Npc lady = new Npc("Lady Battenberg", "She was an elder lady. Light grey hair and a classical long dress finished her look.", false, "Oh, it is terrible! Poor Isabelle... She left this world too early. And what is my husband going to say when he returns... . I nearly forgott, this is the key to my husbands office. You might need it for your investigation.", 100, r3);
            Item key = new Item("key", "The Key to the office of Lord Battenberg", true);
            lady.AddItem(key);

            //Kitchen
            Room r4 = new Room("Kitchen", "A white stained room, that looked like a kitchen, that is used by experienced people.");
            Npc cook = new Npc("Agate Murror", "A well feeded woman, with short brown hair. She was wearing a typical white kitchen uniform and looked quite bussy", false, "I don't know what happened. I have been in the kitchen the whole day. I was looking for a thief. In the last days, food has been disappearing and i am going to find out why!", 100, r4);

            //Floor
            Room r5 = new Room("Floor", "A long floor with several doors.");

            //Library
            Room r6 = new Room("Library", "Tall bookshelfes covered the walls. Cobwebs and dust were all over the place. Execpt one shelf. It looked well used.");
            Item floor = new Item("wet floor", "The floor seemed to be cleaned not long ago.", false);
            Item book1 = new Item("book: Ancient south american mythology", "A book about the Atztecs and theyr mythology and rituals.", true);
            Item book2 = new Item("book: A quick guide to get rich", "A book that will help your family get rich in just three generations.", true);
            Item book3 = new Item("book: The Red Circle", "A documentation about the mediacal history of pox.", true);
            Item book4 = new Item("book: Fantastical secret doors and how to find them", "A book about secret doors in old mansions and castles.", true);
            r6.AddItem(floor);
            r6.AddItem(book1);
            r6.AddItem(book2);
            r6.AddItem(book3);
            r6.AddItem(book4);

            //Office
            Room r7 = new Room("Office", "A small room with a large desk in the middle. Many books lied on the table. Lord Battenberg seemed to be very interrested in ancient history. Especially in the culture of the Atztecs and Mayas.");

            //Secret Passage
            Room r8 = new Room("Secret passage", "A long tunnel, with torches. Strange, they were burning.");
            Item mop = new Item("cleaning mop", "A mop, that is mostly used to clean the ground. It was wet.", true);
            Item food = new Item("food leftovers", "Someone or something hasn't finish its last meal.", false);
            r8.AddItem(mop);
            r8.AddItem(food);

            //Secret Chamber
            Room r9 = new Room("Secret chamber", "The chamber was filled with torch light. In the middle was a man, bowed over an altar of stone. It was edged in blood.");
            Npc lord = new Npc("Lord Battenberg", "He was spilled with blood. His face was mad. He wispered strange words in a language i could not understand. And his mad eyes starred at me.", true, "Oh, who are you? Mhh, actually it doesn't matter anyway. You will make a fine addition to my ritual!", 100, r9);

            //Add Doors
            r1.AddDoor(new Door(Door.Directions.North, r2, "north", false));
            r2.AddDoor(new Door(Door.Directions.South, r1, "south", false));
            r2.AddDoor(new Door(Door.Directions.West, r3, "west", false));
            r2.AddDoor(new Door(Door.Directions.East, r5, "east", false));
            r3.AddDoor(new Door(Door.Directions.North, r4, "north", false));
            r3.AddDoor(new Door(Door.Directions.East, r2, "east", false));
            r4.AddDoor(new Door(Door.Directions.South, r3, "south", false));
            r5.AddDoor(new Door(Door.Directions.West, r2, "west", false));
            r5.AddDoor(new Door(Door.Directions.East, r7, "east", true));
            r5.AddDoor(new Door(Door.Directions.North, r6, "north", false));
            r6.AddDoor(new Door(Door.Directions.South, r5, "south", false));
            r7.AddDoor(new Door(Door.Directions.West, r5, "west", false));
            r8.AddDoor(new Door(Door.Directions.South, r6, "south", false));
            r8.AddDoor(new Door(Door.Directions.North, r9, "north", false));
            r9.AddDoor(new Door(Door.Directions.South, r8, "south", false));
            
            allNpcs.Add(butler);
            allNpcs.Add(lady);
            allNpcs.Add(cook);
            allNpcs.Add(lord);

            allRooms.Add(r1);
            allRooms.Add(r2);
            allRooms.Add(r3);
            allRooms.Add(r4);
            allRooms.Add(r5);
            allRooms.Add(r6);
            allRooms.Add(r7);
            allRooms.Add(r8);
            allRooms.Add(r9);

            //r1.AddNpc(allNpcs.Find(x => x.GetCurrentRoom().Equals(r1)));
            r2.AddNpc(allNpcs.Find(x => x.GetCurrentRoom().Equals(r2)));
            r3.AddNpc(allNpcs.Find(x => x.GetCurrentRoom().Equals(r3)));
            r4.AddNpc(allNpcs.Find(x => x.GetCurrentRoom().Equals(r4)));
            //r5.AddNpc(allNpcs.Find(x => x.GetCurrentRoom().Equals(r5)));
            //r6.AddNpc(allNpcs.Find(x => x.GetCurrentRoom().Equals(r6)));
            //r7.AddNpc(allNpcs.Find(x => x.GetCurrentRoom().Equals(r7)));
            //r8.AddNpc(allNpcs.Find(x => x.GetCurrentRoom().Equals(r8)));
            r9.AddNpc(allNpcs.Find(x => x.GetCurrentRoom().Equals(r9)));

            currentRoom = r1;
            secretPassage = r8;
            currentNpc = butler;
            currentEnemy = lord;

            //Intro
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("It was one of those rainy days in London, when I, Ian Griffort, private Detective, got called to help by the local Police.");
            Console.WriteLine("The house maiden had been found dead. Stabbed in the chest with a dagger.");
            Console.WriteLine("It took about an hour, then I arrived at Battenberg Manor.");
            Console.WriteLine("The Police had already finished its investigation but it ended without a result.");
            Console.WriteLine("It was on me, to find out what happened there.");
            Console.WriteLine("\nI arrived at the ");
            ShowRoom();
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("For a list of commands type 'h' or 'help'.");
        }

        //Method: Commands
        public void Commands(string command)
        {
            try
            {
            
                //command: "help"
                if((command == "help") || (command == "h"))
                {
                    Console.WriteLine("help(h), look(l), inventory(i), move <direction>, take <item>, drop <item>, attack <npc>, look at <item/npc>, talk to <npc>");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    return;
                }

                //command: "look"
                if((command == "look") || (command == "l"))
                {
                    ShowRoom();
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    return;
                }

                //command: "inventory"
                if ((command == "inventory") || (command == "i"))
                {
                    player.ShowInventory();
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    return;
                }

                //command: "move"
                if((command.Length >= 4) & (command.Substring(0, 4) == "move"))
                {
                    Move(command.Substring(5));
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    return;
                }

                //command: "take"
                if((command.Length >= 4) & (command.Substring(0, 4) == "take"))
                {
                    Console.WriteLine("\n");
                    Take(command); 
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    return;   
                }

                //command: "drop"
                if((command.Length >= 4) & (command.Substring(0, 4) == "drop"))
                {
                    Drop(command);
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    return;
                }

                //command: "attack"
                if((command.Length >= 6) & (command.ToLower().Substring(0, 6) == "attack"))
                {
                    Attack(command);
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    return;
                }

                //command: "look at"
                if((command.Length >= 7) & (command.Substring(0, 7) == "look at"))
                {
                    LookAt(command);
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    return;
                }
                
                //command: "talk to"
                if((command.Length >= 7) & (command.Substring(0, 7) == "talk to"))
                {
                    Console.WriteLine("\n");
                    TalkTo(command);
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                    return;
                }

                //No valid command
                Console.WriteLine("\nI am pretty shure I did not do that. (invalid command).\n");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                return;
            }
            catch
            {
                Console.WriteLine("\nI am pretty shure I did not do that (invalid command).\n");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                return;
            }
        }


            //Method: Move <direction>
            public void Move(string command)
            {
                if(currentRoom.GetDoors().Exists(x => x.GetdirectionName().Equals(command)))
                {
                    if(currentRoom.GetDoors().Find(x => x.GetdirectionName().Equals(command)).GetLocked() == false)
                    {
                        lastRoom = currentRoom;
                        currentRoom = currentRoom.GetDoors().Find(x => x.GetdirectionName().Equals(command)).GetLeadsTo();
                        Console.WriteLine("\nI stepped into the ");
                        ShowRoom();
                        return;
                    }
                    if(currentRoom.GetDoors().Find(x => x.GetdirectionName().Equals(command)).GetLocked() == true)
                    {
                        Console.WriteLine("I wanted to walk through the door. But it was locked.");
                        return;
                    }
                }     
                Console.WriteLine("There was no door in the " + command);    
                return;
            }

            //Method: Move Npc
            public void MoveNpc(string npc, string room)
            {   
                Npc _currentNpc = allNpcs.Find(x => x.GetName().Equals(npc));
                Room npcCurrentRoom = allRooms.Find(y => y.Equals(allNpcs.Find(x => x.GetName().Equals(npc)).GetCurrentRoom()));
                Room npcNewRoom = allRooms.Find(x => x.GetTitle().Equals(room));
                npcCurrentRoom.RemoveNpc(_currentNpc);
                npcNewRoom.AddNpc(_currentNpc);
                _currentNpc.ChangeCurrentRoom(npcNewRoom);
                return;
            }

            //Method: Events
            public void Events(string command)
            {
                if(turnCounter > 15)
                {
                    MoveNpc("Alfred Sharp", "Floor");
                }

                if((currentEnemy.GetName() == "Lord Battenberg") & (currentEnemy.GetHealth() <= 0))
                {
                    Console.WriteLine("I killed the mad lord. The police took care of the paper work and the whole happening was found news for the press. But I still can't get loose of this case. His mad eyes, i still feel them starring at me.");
                    gameOver = true;
                    Update();
                }
                
                if(currentRoom.GetTitle() == "Secret chamber")
                {
                    caseSolfed = true;
                }

                if((command.ToLower() == "take book: ancient south american mythology") & (currentRoom.GetDoors().Exists(x => x.GetdirectionName() != "north")) & (currentRoom.GetTitle().ToLower() == "library"))
                {
                    Console.WriteLine("\nThe moment i pulled the book out of the shelf, the wall began to move and opened a secret passage way.");
                    currentRoom.AddDoor(new Door(Door.Directions.North, secretPassage, "north", false));
                }

                return;
            }

            //Method: "UpdateGame"
            public void Update()
            {
                if(gameOver == true)
                {
                    Console.WriteLine("\n-The game ended-");
                    running = false;
                    return;
                }

                string currentCommand = Console.ReadLine().ToLower();

                if((currentCommand == "quit") || (currentCommand == "q"))
                {
                    Console.WriteLine("Obviously i am boring you with my story. Well then, fare well...");
                    Console.WriteLine("\n-The game ended-");
                    running = false;
                    return;
                }

                Events(currentCommand);
                turnCounter = turnCounter + 1;
                Commands(currentCommand);
            }

            //Method: Drop <item>
            public void Drop(string command)
            {
                if (command == "drop")
                    {
                        Console.WriteLine("\nMhh, which item did I drop?\n");
                        return;
                    }

                    if (player.GetInventory().Exists(x => x.GetName() == command.Substring(5)))
                    {
                        currentRoom.AddItem(player.GetInventory().Find(x => x.GetName() == command.Substring(5)));
                        player.RemoveItem(player.GetInventory().Find(x => x.GetName() == command.Substring(5)));
                        Console.WriteLine("\nI dropped the " + command.Substring(5) + ".\n");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\nI had no " + command.Substring(5) + " to drop.\n");
                        return;
                    }
            }

            //Method: Attack <Npc>
            public void Attack(string command)
            { 
                if(command == "attack")
                    {
                        Console.WriteLine("\nI knew i had to attack, but whom?");
                        return;
                    }

                if(currentRoom.GetNpcs().Exists(x => x.GetName().ToLower().Equals(command.ToLower().Substring(7))))
                {
                    currentEnemy = currentRoom.GetNpcs().Find(x => x.GetName().ToLower() == command.ToLower().Substring(7));

                    if(currentEnemy.GetFightable() == true)
                    {
                        Console.WriteLine("The fight began!");
                        while((player.GetHealth() > 0) & (currentEnemy.GetHealth() > 0))
                        { 
                            int attackValuePlayer = 1;
                            int attackValueNpc = 0;
                            Console.WriteLine("I attacked " + currentEnemy.GetName() + ".");

                            if(attackValuePlayer > attackValueNpc)
                            {
                                currentEnemy.ReduceHealth();
                                Console.WriteLine("That attack did hit!");
                            }
                            else
                            {
                                Console.WriteLine("I remember missing that attack!");
                            }
                            Console.WriteLine("Mhh, i can't remember if i did continue the fight... (y/n)");
                            if(Console.ReadLine() == "n")
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                currentRoom = lastRoom;
                                Console.WriteLine("I managed to escape the fight into the " + currentRoom.GetTitle() + "!");
                                return;
                            }
                            if(Console.ReadLine() == "y")
                            {
                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine(currentEnemy.GetName() + " attacked!");
                                if(attackValueNpc != attackValuePlayer)
                                {
                                    player.ReduceHealth();
                                    Console.WriteLine(currentEnemy.GetName() + "'s attack did hit!");
                                    Console.WriteLine("I felt like i had " + player.GetHealth() + "% of my strenght remaining.");
                                }
                                else
                                {
                                    Console.WriteLine("I remember " + currentEnemy.GetName() + " missing that attack!");
                                }
                            }
                        }
                    }
                    
                    else
                    {
                        Console.WriteLine("I can't remember fighting against " + currentEnemy.GetName() + ".");
                        return;
                    }

                    if(player.GetHealth() > 0)
                    {
                        Console.WriteLine("My enemy trambeled and died. " + currentEnemy.GetName() + " lied dead on the ground.");
                        Item deadEnemy = new Item("Dead body of " + currentEnemy.GetName(), currentEnemy.GetDescription() + " But then " + currentEnemy.GetName() + " lied dead to my feet.", false);
                        currentRoom.AddItem(deadEnemy);
                        currentRoom.RemoveNpc(currentEnemy);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("And that is how I died. It is strange when you think about it.");
                        Console.WriteLine("\n-The game ended-");
                        gameOver = true;
                        Update();
                        return;                
                    }
                }
                else
                {
                    Console.WriteLine("There was no " + command.Substring(7) + " to attack.");
                    return;
                }
            }

            //Method: Look at <Item / Room>
            public void LookAt(string command)
            {
                if(command == "look at")
                    {
                        Console.WriteLine("\nI was not shure what or whom i wanted to look at.\n");
                        return;
                    }

                    if(currentRoom.GetNpcs().Exists(x => x.GetName().ToLower().Equals(command.ToLower().Substring(8))))
                    {
                        Console.WriteLine("\n" + currentRoom.GetNpcs().Find(x => x.GetName().ToLower().Equals(command.ToLower().Substring(8))).GetDescription() + "\n");
                        return;
                    }
                    if(currentRoom.GetInventory().Exists(x => x.GetName().ToLower() == command.ToLower().Substring(8)))
                    {
                        Console.WriteLine("\n" + currentRoom.GetInventory().Find(x => x.GetName().ToLower().Equals(command.ToLower().Substring(8))).GetDescription() + "\n");
                        return;
                    }
                    if(player.GetInventory().Exists(x => x.GetName().ToLower() == command.ToLower().Substring(8)))
                    {
                        Console.WriteLine("\n" + player.GetInventory().Find(x => x.GetName().ToLower().Equals(command.ToLower().Substring(8))).GetDescription() + "\n");
                        return;
                    }
                    Console.WriteLine("\nThere was no " + command.Substring(8) + " to look at.");
                    return;
            }

            //Method: Talk to Npc
            public void TalkTo(string command)
            {
                if(command == "talk to")
                    {
                        Console.WriteLine("\nI started talking, but it was no one there.");
                        return;
                    }

                    if(command.ToLower() == "talk to lord battenberg")
                    {
                        currentNpc = currentRoom.GetNpcs().Find(x => x.GetName().ToLower() == command.ToLower().Substring(8));
                        Console.WriteLine("I drew his attention to me. He looked at me and began smiling: \n" + currentNpc.GetAnswer());
                        Commands("attack Lord Battenberg");
                        return;
                    }
                    if((command.ToLower() == "talk to the police") & (caseSolfed == true))
                    {
                        Console.WriteLine("I told the police about the madness happening within the secret chamber. The police took care of the mad lord and the paper work. The whole happening was found news for the press. But I still can't get loose of this case. His mad eyes, I still feel them starring at me. ");
                        gameOver = true;
                        Update();
                        return;
                    }

                    if(currentRoom.GetNpcs().Exists(x => x.GetName().ToLower().Equals(command.ToLower().Substring(8))))
                    {
                        currentNpc = currentRoom.GetNpcs().Find(x => x.GetName().ToLower() == command.ToLower().Substring(8));
                        Console.WriteLine("I asked " + currentNpc.GetName() + " about the case:\n" + currentNpc.GetAnswer() + "\n");
                        if(currentNpc.GetName() == "Lady Battenberg")
                        {
                            NpcGiveItem(currentNpc.GetInventory().Find(x => x.GetName().ToLower() == "key"), currentNpc);
                            Console.WriteLine("She gave me the key to the Office.\n");
                            Door door = allRooms.Find(x => x.GetTitle().ToLower() == "floor").GetDoors().Find(y => y.GetdirectionName().ToLower().Equals("east"));
                            door.SetLocked(false);
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("There was no " + command.Substring(8) + " to talk to.\n");
                    }
                    return;
            }

            //Method: ShowRoom
            public void ShowRoom()
            {
                Console.WriteLine("\n" + currentRoom.GetTitle() + "\n");
                Console.WriteLine(currentRoom.GetDescription());

                if(currentRoom.GetInventory().Count > 0)
                {
                    Console.WriteLine("\nIn the " + currentRoom.GetTitle() + " were:" );
                    for(int i = 0; i < currentRoom.GetInventory().Count; i++)
                    {
                        Console.WriteLine("a " + currentRoom.GetInventory()[i].GetName());
                    }
                }

                if(currentRoom.GetNpcs().Count > 0)
                {
                    Console.WriteLine("\nAnd i remember:");
                    for(int i = 0; i < currentRoom.GetNpcs().Count; i++)
                    {
                        Console.WriteLine(currentRoom.GetNpcs()[i].GetName());
                    }
                    Console.Write("being in the " + currentRoom.GetTitle() + "\n");
                }   

                Console.WriteLine("\nThe " + currentRoom.GetTitle() + " had a door in the");
			    foreach (Door doors in currentRoom.GetDoors())
			    {
				    Console.WriteLine(doors.GetDirections());
			    }
                Console.WriteLine();
                return;
            }

            //Method: Take <item>
            public void Take(string command)
            {
                if (command == "take")
                    {
                        Console.WriteLine("\nMhh, which item did i take?.\n");
                        return;
                    }

                    if ((currentRoom.GetInventory().Find(x => x.GetName().ToLower().Equals(command.ToLower().Substring(5))).GetUseable() == true)) 
                    {
                        player.AddItem(currentRoom.GetInventory().Find(x => x.GetName().ToLower() == command.ToLower().Substring(5)));
                        currentRoom.RemoveItem(currentRoom.GetInventory().Find(x => x.GetName().ToLower() == command.ToLower().Substring(5)));
                        Console.WriteLine("\nI picked up the " + command.Substring(5) + ".\n");
                        return;
                    }

                    if ((currentRoom.GetInventory().Find(x => x.GetName().ToLower().Equals(command.ToLower().Substring(5))).GetUseable() == false))
                    {
                        Console.WriteLine("\nI was unable to take the " + command.Substring(5) + ".\n");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\nThere was no " + command.Substring(5) + " to take.\n");
                        return;
                    } 
            }

            //Method: Npc give item
            public void NpcGiveItem(Item item, Npc npc)
            {
                npc.RemoveItem(item);
                player.AddItem(item);
                return;
            }

            //Method: Player give item
            public void PlayerGiveItem(Item item, Npc npc)
            {
                player.RemoveItem(item);
                npc.AddItem(item);
            }
    }           
}

