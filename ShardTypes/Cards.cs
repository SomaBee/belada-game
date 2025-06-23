namespace ShardTypes;

public static class Cards
{
    public static List<Card> AvailableCards = new()
    {
        new Card()
        {
            Name = "Maren&Lara",
            Description = "All females drink",
            NumberOfDrinks = 2,
            Type = CardType.Action,
            ImageName = "card1.png",
        },
        new Card()
        {
            Name = "Chrisi is thirsty!",
            Description = "Chrisi has to drink",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card2.png",
        },
        new Card()
        {
            Name = "Chrisis Laugh",
            Description = "Make someone laugh",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card3.png",
        },
        new Card()
        {
            Name = "Beladas Buddy",
            Description = "Choose a buddy to drink with you",
            NumberOfDrinks = 1,
            Type = CardType.Effect,
            ImageName = "card4.png",
            Duration = Int32.MaxValue,
        },
        new Card()
        {
            Name = "Fynx is angwy!",
            Description = "Everybody drinks",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card5.png",
        },
        new Card()
        {
            Name = "Glumandas Update",
            Description = "Put one foot in the air",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card6.png",
        },
        new Card()
        {
            Name = "Lara the Traindriver",
            Description = "Until the person who drew this card draws again, scream 'Choo Choo' before drinking.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card7.png",
        },
        new Card()
        {
            Name = "Chad Thaddäus",
            Description = "Player drinks 3 times.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card8.png",
        },
        new Card()
        {
            Name = "Valentina is sceptical",
            Description = "Player drinks",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card9.png",
        },
        new Card()
        {
            Name = "Tounges out",
            Description = "Everybody has to lick something. The bravest lick, distributes 5 drinks.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card10.png",
        },
        new Card()
        {
            Name = "Smile",
            Description = "Everybody has to smile. The last one drinks.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card11.png",
        },
        new Card()
        {
            Name = "Beladas Hospital",
            Description = "Player tells a story where they got injured. Group decides if it was a good story. If not, player drinks. If yes player can distribute 1 drink.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card12.png",
        },
        new Card()
        {
            Name = "Laras Stare",
            Description = "The first person to look at you has to drink.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card13.png",
        },
        new Card()
        {
            Name = "Fresh Belada",
            Description = "The person who most recently showered drinks.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card14.png",
        },
        new Card()
        {
            Name = "Scared Valentina",
            Description = "Everybody drinks 5 times.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card15.png",
        },
        new Card()
        {
            Name = "Proud Arleen",
            Description = "The player chooses 2 other players. They all have to drink.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card16.png",
        },
        new Card()
        {
            Name = "Gangster Lara",
            Description = "Say a word. The next person has to find a word that rhymes with it. If they can't, they drink.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card17.png",
        },
        new Card()
        {
            Name = "Goose in pants",
            Description = "The first person to pulls down their pants distributes 5 drinks.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card18.png",
        },
        new Card()
        {
            Name = "Shocked Goose",
            Description = "Wasserfall: The person who drew this card starts drinking. The person to their left starts drinking after them. This continues until the person to the right of the person who drew the card starts drinking.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card19.png",
        },
        new Card()
        {
            Name = "Programmer Goose",
            Description = "Everybody has to prove that they are not an AI. The most convincing person distributes 5 drinks.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card20.png",
        },
        new Card()
        {
            Name = "Lara is sober",
            Description = "The group decides who is the most sober. This person drinks 5 times.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card21.png",
        },
        new Card()
        {
            Name = "Ice Lara",
            Description = "Player has to get everyone who asks for it a fresh cold drink.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card22.png",
        },
        new Card()
        {
            Name = "Suitcase Glumanda",
            Description = "Sit on something that is not a chair until your next turn. If you can't, drink.",
            NumberOfDrinks = 1,
            Type = CardType.Effect,
            ImageName = "card23.png",
            Duration = 5,
        },
        new Card()
        {
            Name = "Norway",
            Description = "Name a fact about Norway, that hasn't been mention on the festival yet. If you can't, drink.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card24.png",
        },
        new Card()
        {
            Name = "Lara the Winner",
            Description = "Empty your drink and get a new one.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card25.png",
        },
        new Card()
        {
            Name = "Goose & Glumanda",
            Description = "Choose 2 players. They drink 2 times.",
            NumberOfDrinks = 2,
            Type = CardType.Action,
            ImageName = "card26.png",
        },
        new Card()
        {
            Name = "Sleepwatcher Goose",
            Description = "The person who slept the longest last night drinks.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card27.png",
        },
        new Card()
        {
            Name = "Belada & Valentina",
            Description = "Make Belada and Valentina drink. If they are not playing, you drink for them.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card28.png",
        },
        new Card()
        {
            Name = "Fancy Valentina",
            Description = "Lift your pinky while drinking, until your next turn. If you forget, drink.",
            NumberOfDrinks = 1,
            Type = CardType.Effect,
            Duration = 2,
            ImageName = "card29.png",
        },
        new Card()
        {
            Name = "Happy new Year!",
            Description = "Choose a rule that must be followed for the rest of the game. If someone breaks the rule, they drink.",
            NumberOfDrinks = 1,
            Type = CardType.Effect,
            ImageName = "card30.png",
        },
        new Card()
        {
            Name = "Beladas 'Drill'",
            Description = "Build something of at least 50cm heigth with at least 5 components. If you can't, drink.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card31.png",
        },
        new Card()
        {
            Name = "Military Belada",
            Description = "Do 5 push-ups, sit-ups or squats. If you can't, drink for each one you can't do.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card32.png",
        },
        new Card()
        {
            Name = "It's sexy time!",
            Description = "Everyone has to make a move on you. The best one distributes 3 drinks.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card33.png",
        },
        new Card()
        {
            Name = "Wizard Fynx",
            Description = "Double all drinks you receive until your next turn.",
            NumberOfDrinks = 1,
            Type = CardType.Effect,
            ImageName = "card34.png",
            Duration = 5,
        },
        new Card()
        {
            Name = "The fluffiest Boi",
            Description = "Everytime someone talks to you they have to end what they say with: 'You are the fluffiest boi'. If they forget, they drink.",
            NumberOfDrinks = 1,
            Type = CardType.Effect,
            ImageName = "card35.png",
            Duration = 5,
        },
        new Card()
        {
            Name = "Hunter Belada",
            Description = "Obtain somethin from a stranger. Anything will do. If you can't, drink 5 times.",
            NumberOfDrinks = 5,
            Type = CardType.Action,
            ImageName = "card36.png",
        },
        new Card()
        {
            Name = "Covid is not over",
            Description = "Get something to cover your mouth and nose. If you forget to wear it after drinking, you drink again.",
            NumberOfDrinks = 1,
            Type = CardType.Effect,
            ImageName = "card37.png",
            Duration = Int32.MaxValue,
        },
        new Card()
        {
            Name = "Icy Group",
            Description = "Take a group picture. Everyone drinks after the picture is taken.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card38.png",
        },
        new Card()
        {
            Name = "Maren & Lara",
            Description = "Hug someone and both of you drink while hugging.",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card39.png",
        },
        new Card()
        {
            Name = "Marens Supermarket",
            Description = "Get yourself a fresh cold drink. Even if you already have one.",
            NumberOfDrinks = 0,
            Type = CardType.Action,
            ImageName = "card40.png",
        },
        new Card()
        {
            Name = "Valentina Chills",
            Description = "You can deny one drink",
            NumberOfDrinks = 0,
            Type = CardType.Trap,
            ImageName = "card41.png",
        },
        new Card()
        {
            Name = "Laras Murder",
            Description = "The next person that says your name has to finish their drink",
            NumberOfDrinks = 8,
            Type = CardType.Action,
            ImageName = "card42.png",
        },
        new Card()
        {
            Name = "Valentinas Baby",
            Description = "Only talk in baby speak until your next turn. Drink if you forget",
            Type = CardType.Effect,
            NumberOfDrinks = 1,
            ImageName = "card43.png",
            Duration = 5
        },
        new Card()
        {
            Name = "Chrisis Adventure",
            Description = "The last person to touch the floor, drinks",
            NumberOfDrinks = 1,
            Type = CardType.Action,
            ImageName = "card44.png",
        },
        new Card()
        {
            Name = "Yogatime",
            Description = "Choose a player to perform a yoga pose of your choice. If they fail, they drink",
            Type = CardType.Action,
            ImageName = "card45.png",
        },
        new Card()
        {
            Name = "Catch them all",
            Description = "Name 3 Pokemon, that haven't been named yet. If you can't, drink",
            Type = CardType.Action,
            ImageName = "card46.png",
        },
        new Card()
        {
            Name = "Horserider Valentina",
            Description = "Ride an invisible horse around the pavillon. If you refuse, drink 3 times",
            Type = CardType.Action,
            ImageName = "card47.png",
        },
        new Card()
        {
            Name = "Laras Nova Rock",
            Description = "All players that haven't been to Nova Rock, drink twice",
            Type = CardType.Action,
            ImageName = "card48.png",
        },
        new Card()
        {
            Name = "Maren in Vienna",
            Description = "The Player chooses one Person. Everyone except the player and the chosen person drinks",
            Type = CardType.Effect,
            ImageName = "card49.png",
        },
        new Card()
        {
            Name = "Toiletboy Goose",
            Description = "The last person who went to the toilet, drinks 5 times. If a player is on the toilet, while this card is drawn, they have to empty their drink when they come back",
            Type = CardType.Action,
            ImageName = "card50.png",
        },
        new Card()
        {
            Name = "Snackmaster",
            Description = "Get Snacks for everyone.",
            Type = CardType.Action,
            ImageName = "card51.png",
        },
        new Card()
        {
            Name = "Beer Lara",
            Description = "Drink 3 times",
            Type = CardType.Action,
            ImageName = "card52.png",
        },
        new Card()
        {
            Name = "Pirate Maren",
            Description = "Switch hats with someone. You both drink",
            Type = CardType.Action,
            ImageName = "card53.png",
        },
        new Card()
        {
            Name = "Exhausted Maren",
            Description = "Everyone takes a sip of water",
            Type = CardType.Action,
            ImageName = "card54.png",
        },
        new Card()
        {
            Name = "Festive Maren&Lara",
            Description = "Everybody shouts 'Whoop Whoop' and drinks",
            Type = CardType.Action,
            ImageName = "card55.png",
        },
        new Card()
        {
            Name = "Max from Bremen",
            Description = "Tell everyone what your favorite type of bear is. You then drink 2 times",
            Type = CardType.Action,
            ImageName = "card56.png",
        },
        new Card()
        {
            Name = "Oldtimer Chrisi",
            Description = "The oldest and the youngest player drink",
            Type = CardType.Action,
            ImageName = "card57.png",
        },
        new Card()
        {
            Name = "Scared Alice",
            Description = "Player drinks 7 times",
            Type = CardType.Action,
            ImageName = "card58.png",
        },
        new Card()
        {
            Name = "Confused Alice",
            Description = "When this card is played, any drink you would have to take, is given to the player to your left instead",
            Type = CardType.Trap,
            ImageName = "card59.png",
        },
        new Card()
        {
            Name = "Chrisi & Valentina",
            Description = "When this card is played, the player who tried to make you drink, has to drink instead",
            Type = CardType.Trap,
            ImageName = "card60.png",
        },
        new Card()
        {
            Name = "Sandy Sisters",
            Description = "Stand up and stand on one leg until your next turn.",
            Type = CardType.Effect,
            Duration = 1,
            ImageName = "card61.png",
        },
        new Card()
        {
            Name = "Hidden Valentina",
            Description = "When this card is played, you can refuse one action",
            Type = CardType.Trap,
            ImageName = "card62.png",
        },
        new Card()
        {
            Name = "Crocodile Alice",
            Description = "Choose a player to drink 3 times",
            Type = CardType.Action,
            ImageName = "card63.png",
        },
        new Card()
        {
            Name = "Cowgirls Lara&Valentina",
            Description = "Choose a player to duel you in Rock, Paper, Scissors. The loser drinks 5 times",
            Type = CardType.Action,
            ImageName = "card64.png",
        },
        new Card()
        {
            Name = "Staring Alice",
            Description = "Choose a player to battle you in a staring contest. The loser drinks",
            Type = CardType.Action,
            ImageName = "card65.png",
        },
        new Card()
        {
            Name = "Till the builder",
            Description = "Imitate the sound of a power tool. If no one can guess what tool it is, you drink 3 times",
            Type = CardType.Action,
            ImageName = "card66.png",
        },
        new Card()
        {
            Name = "Sunbathing Alice",
            Description = "The person who is the least tanned, drinks. Everyone that has a sunburn, drinks 3 times",
            Type = CardType.Action,
            ImageName = "card67.png",
        },
        new Card()
        {
            Name = "4 Beer Alice",
            Description = "Everyone drinks 4 times",
            Type = CardType.Action,
            ImageName = "card68.png",
        },
        new Card()
        {
            Name = "Anarchy Thaddäus",
            Description = "Decorate yourself with a permanent marker. If you refuse, drink 3 times",
            Type = CardType.Action,
            ImageName = "card69.png",
            Duration = 1,
        },
        new Card()
        {
            Name = "Coffee Thaddäus",
            Description = "Everyone who had a coffee today, drinks",
            Type = CardType.Action,
            ImageName = "card70.png",
        },
        new Card()
        {
            Name = "Disco Thaddäus",
            Description = "Do a Fortnite dance. If you refuse, drink",
            Type = CardType.Action,
            ImageName = "card71.png",
            Duration = 1,
        },
        new Card()
        {
            Name = "Roadtrip Thaddäus",
            Description = "Everyone who arrived at the festival in the same vehicle as Thaddäus, drinks",
            Type = CardType.Action,
            ImageName = "card72.png",
            Duration = 1,
        },
        new Card()
        {
            Name = "Powerwalking Thaddäus",
            Description = "Walk in circles around the pavillon until your next turn. If you stop, drink 3 times",
            Type = CardType.Action,
            ImageName = "card73.png",
        },
        new Card()
        {
            Name = "Hungover Thaddäus",
            Description = "The person with the biggest hangover takes one shot.",
            Type = CardType.Action,
            ImageName = "card74.png",
            Duration = Int32.MaxValue,
        },
        new Card()
        {
            Name = "Great Hair Thaddäus",
            Description = "The group decides who has the worst hair. This person drinks",
            Type = CardType.Action,
            ImageName = "card75.png",
        },
        new Card()
        {
            Name = "Tired Thaddäus",
            Description = "The last person to get up this morning drinks",
            Type = CardType.Action,
            ImageName = "card76.png",
        },
        new Card()
        {
            Name = "Double Arleen",
            Description = "Get a second drink. Everytime you drink, you have to drink from both drinks at the same time. For the next 3 rounds",
            Type = CardType.Effect,
            ImageName = "card77.png",
            Duration = 3,
        },
        new Card()
        {
            Name = "Hidden Thaddäus",
            Description = "You have 3 turns to sneakily hide an item of another player. If you succeed, they drink 3 times. If you fail, you drink 3 times",
            Type = CardType.Effect,
            ImageName = "card78.png",
        },
        new Card()
        {
            Name = "Trashbin Thaddäus",
            Description = "Pick up some trash and dispose of it. Drink twice afterwards",
            Type = CardType.Action,
            ImageName = "card79.png",
        },
        new Card()
        {
            Name = "Selfie Thaddäus",
            Description = "Take a bad selfie. If you dare to post it on social media, everyone else drinks If you don't, you drink",
            Type = CardType.Action,
            ImageName = "card80.png",
        },
        new Card()
        {
            Name = "Shocked Thaddäus",
            Description = "Make up a shocking news story, that actually could be true. Everyone else drinks.",
            Type = CardType.Action,
            ImageName = "card81.png",
        },
        new Card()
        {
            Name = "Bowl Thaddäus",
            Description = "Wear something that is not a hat on your head until your next turn. If it falls off, you drink",
            Type = CardType.Effect,
            ImageName = "card82.png",
        },
        new Card()
        {
            Name = "Silly Thaddäus",
            Description = "State a fact that feels silly. Drink 3 times afterwards",
            Type = CardType.Action,
            ImageName = "card83.png",
        },
        new Card()
        {
            Name = "Grandmom Thaddäus",
            Description = "Talk like an old person until your next turn. If you forget, drink",
            Type = CardType.Effect,
            ImageName = "card84.png",
        },
        new Card()
        {
            Name = "Milk Thaddäus",
            Description = "Everyone who prefers cows milk, drinks",
            Type = CardType.Action,
            ImageName = "card85.png",
        },
        new Card()
        {
            Name = "Winter Thaddäus",
            Description = "Put an ice cube in your pants and take a drink from a cold drink.",
            Type = CardType.Action,
            ImageName = "card86.png",
        },
        new Card()
        {
            Name = "Lord Till",
            Description = "Everyone has to call you 'Lord/Lady' for the next 4 rounds. If they forget, they drink",
            Type = CardType.Effect,
            ImageName = "card87.png",
            Duration = 4,
        },
        new Card()
        {
            Name = "Till in trouble",
            Description = "Choose a person to drink 5 times",
            Type = CardType.Action,
            ImageName = "card88.png",
        },
        new Card()
        {
            Name = "Dr. Till",
            Description = "Choose a player that can rest. The chosen player doesn't have to drink until your next turn",
            Type = CardType.Effect,
            ImageName = "card89.png",
            Duration = 1,
        },
        new Card()
        {
            Name = "Forever alone Till",
            Description = "Block one action or drink.",
            Type = CardType.Trap,
            ImageName = "card90.png",
        },
        new Card()
        {
            Name = "Lab Till",
            Description = "Mix your drink with another drink. This is your new drink",
            Type = CardType.Action,
            ImageName = "card91.png",
        },
        new Card()
        {
            Name = "Berliner Luft",
            Description = "Everyone takes a shot of Berliner Luft",
            Type = CardType.Action,
            ImageName = "card92.png",
        },
        new Card()
        {
            Name = "Driver Belada",
            Description = "Everyone who doesn't own a car, drinks",
            Type = CardType.Action,
            ImageName = "card93.png",
        },
        new Card()
        {
            Name = "Pyromaniac Belada",
            Description = "Everybody shouts 'Fire in the hole' and drinks",
            Type = CardType.Action,
            ImageName = "card94.png",
        },
        new Card()
        {
            Name = "Weeb Belada",
            Description = "Name an anime you watched. Drink if you can't name one",
            Type = CardType.Action,
            ImageName = "card95.png",
        },
        new Card()
        {
            Name = "Belada & the bois",
            Description = "All males drink",
            Type = CardType.Action,
            ImageName = "card96.png",
        },
    };
}