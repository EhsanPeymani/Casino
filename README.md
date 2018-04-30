# Mega Project: Casino
The mega project for C# course I took 2015 on DevU.com.

The idea is to emulate a slot machine. The rules as shown in the below image. 
The possible outcome of each reel is based on the images in /Casino.Presentation/Images/

I have worked more than specified on DevU.com to experience more. For example, adding a database for the results, or styling by CSS. 

## Code Architecture
I followed an object oriented programming. 

[![architecture.png](https://s18.postimg.cc/yf46jocnd/architecture.png)](https://postimg.cc/image/x02luybk5/)

The architecture is layered in 3 layers: Data, Domain and Presentation.
The code has the following objects:
- Player
- Reels
- ReelFaceUp
- SlotMachine
- Game which is the super class including Player and SlotMachine

### Players Class
The Players class has the following properties: Name (which is not really used), Pot, Bet and Wins (the number of wins where the player pot increases.)
It has 2 instance methods: Lose() and Win()

### ReelFaceUp
This class is to identify the reel faceup image. 
It has index, name and the url of the image to show. 
The class is intantiated bu index and name. The index and name of each image must be compatible.

### Reels
This class has 2 properties: Symbols which as dictionary holding symbol names with index as the key of the dictionary. The face which is faceup of the reel. 

The Reels class is intantiated by an integer which the index of the image that faces up. 

### SlotMachine Class
This class has the following properties: RndSlotMachine (the random variable), ReelsNumber (the number of reels), and ReelsOfMachine (an array of size ReelsNumber and type Reels)

The SlotMachine is instantiated by the number of reels (usually 3 or more).

This class has only one instance method LeverPulled() which instantiates a new Reels randomly instantiated with a nonnegative integer  

### Game class
This calss is the main class which has Players and SlotMachine as properties.
It also has GameStatus (Win, Lose, CannotPlay), WinCount and RoundCount as well as MoneyMultiplier. 

The instance method PlayRound(int newBet) is the major method which pull the lever, determine the amount of money to win or lose, update the pot and save information in database.


## Screen Shots
[![slot_Machine.png](https://s18.postimg.cc/3jmzstna1/slot_Machine.png)](https://postimg.cc/image/ej874fdp1/)

Another screen shot after 66 attempts and one refill:

[![slot2.png](https://s31.postimg.cc/70ncvzeu3/slot2.png)](https://postimg.cc/image/d1l1t21g7/)
