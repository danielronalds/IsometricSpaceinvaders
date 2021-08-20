# IsometricSpaceinvaders

I made this game with a use of a C# library I made last year, and whom's github repository can be found with the following link:

https://github.com/danielronalds/IsometricGameEngine

# Final Product Showcase 

Final Gameplay Showcase Video: 

Part 1: https://drive.google.com/file/d/10Cm-fvoQU5fDGR6atEubH8u4g-yuWwQf/view

Part 2: https://drive.google.com/file/d/11WQPjjsDJpNtcQ06rLgYRt0YhcO4giS4/view

Didn't realise Screencastify had a recording time limit of 5 minutes, hence the two parts

# Evaluation

By using Github's Projects feature I was able to produce a high quality outcome as it allowed me to plan out exactly what I wanted my end product to be from the start, and then chip away at it. As I set clearly defined goalposts it allowed me to work on a feature till it was perfected and then move on, resulting in a high quality product. Through game testing I was able to discover bugs that I would've otherwised missed, such as my first itteration of the alien movement system having collision issues resulting in me redesigning it later down the road. Gametesting with other people provided me the ability to fine tune the feel of the game, as I had more than my own opinion to base it off. Knowing that each version of my code was backed up on github gave me the freedom to experiment with my code and test new ideas and ways of achieving my desired end result as I knew that if I screwed up the code I could reset it within minutes. As such my end product was of a higher quality than If I was afraid of losing the entire game. 

A relavent implication I had to consider while developing my game was intelectual property. To avoid any conflicts I only used code I had developed myself, such as my isometric game engine library. I also created my own assests so that I could be sure that I owned them rather than using assests from the public domain as it might've been difficult to confirm that they were in fact in the public domain.

Another relavent implication when developing my game was functionality. Ultimatly the goal of any game is to create an enjoyable experience for those who play it and an integral part of that is a game without any bugs that runs well and without glitches, and fast load times. One way I accomplished this was by capping the game's frame rate at 60fps by setting the frame refresh timer to 16 miliseconds(ms). The reasoning behind this was based on my game testing, as I noticed that at times the game would encouter a lag spike as certain methods and actions were run. Intially I tried to refine these methods however this did not help the problem much, so I decided to give the computer more time to produce a frame by increasing the time between frames from 1ms to 16ms. This had the effect of the game running at a stable fps of 60 frames per second rather than as fast as it could, which provided the user with a consistent experience thus improving the end product's functionality. When adding the start screen and the gameover/highscore screen I opted to use panels instead of seperate forms as I noticed that using panels procided a smoother experience as the act of the window closing and a new one opening up felt jarring. This opinion was shared by my parents who were unfortunate to enough to be game testers, and as such I implemented multipile panels into my game for the different screens.
