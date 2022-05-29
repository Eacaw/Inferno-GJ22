# Game Jam 2022

## Theme: "Death is only the beginning"

### Updates:

### Day 1:

Theme announced at 9pm local time, so we had a brief brainstorming session before calling it a night.

### Day 2:

Initial planning completed with the team. Game theme is based on Dante's inferno and utilises the player _killing themselves_ to progress through a set of levels. Basic player movement added within a basic tunnel view (3d platform style). Basic title screen included with start button that brings you to dev space

### Day 3:

A lot of prefabs were added today (button, door). Leaving your original body was also added and can be done by pressing [E]. UI interfaces were created for the end of the level as well as a pause menu that allow for navigation to other screens/scenes.

### Day 4:

Created 8 basic levels that can be utilized for the game.

Update the UI at the end of each level to progress to the next level in the build.

Added some more assets to the project, including a ramp/wall that the player must use their bodies to climb.

DevPG has been extended and will become the first level of the game once we have the remaining missing assets. This is how it stands at time of writing:

![Day 4 Progress](https://user-images.githubusercontent.com/24251551/169892035-83f9fb7d-e672-4f5f-8be9-1af25441f46e.png)

Also fixed a bug wherein the player could force themselves to stick to a wall, resolved by adding a frictionless material to the player. Nice little bonus here that we were able to add a little bounce to the player. Fixed up the level a bit and updated the door/frame model to match the walls exactly.

Attempted to include a new player model, but rotation issues have put that to one side for now, contemplating sticking with the original model.

Updated main menu screen to now include a guide page (nothing useful on it yet), as well as a _controls_ page.

### Day 5: 

Say hello to the most important change so far, we finally say goodbye to Mr Pillman McCapsule and welcome in... well we don't have a name for him yet: 

![Playermodel](https://user-images.githubusercontent.com/24251551/170148297-0c142be8-b2cd-4599-a3cf-389f9354d416.png)


Today was a big push towards finishing off prefabs and getting ready to focus on level design. Added a box into a hole trigger mechanic, which we can use to store blocks in hard to reach places and get the player to fetch it down to progress. We've also added a player/corpse into a hole trigger mechanic, in which a player must leave one of their corpses in order to progress. 

We've also added another event prefab in the form of the laser doorway. The lasers will instantly kill you if you touch them, they will also instantly destroy a corpse if one was to touch them! 

Here are some screenshots showcasing their models (all subject to sudden and immediate chantge at time of writing)

BoxForHole + HoleForBox with BoxInHole and IndicatorLightActive
![BodHole](https://user-images.githubusercontent.com/24251551/170148447-33a56929-2a6b-4fab-be68-395de1989c35.png)

LaserBeams + LaserFrame + BodyHole
![BodyHole](https://user-images.githubusercontent.com/24251551/170148563-a3a72071-55d2-45a9-bb79-f82676df4229.png)

As you can see from the images, they both come with a littel indicator light that goes green once the trigger has been activated, signalling that you can progress.

The playground has been decorated a little more with the new triggers, some additional lighting effects and a lower respawn location which will be carried across to the fullgame levels. Here's today's update picture:

![Day 5 Progress](https://user-images.githubusercontent.com/24251551/170147872-66007c4a-8f96-449d-938b-2808a294f1f0.png)

There have also been a number of bugfixes made, and UI improvements and refinements, including a new restart button on the pause screen, the final level now links correctly to the gameover screen and you can now view controls while in the pause menu.

Along with the usual bugfixes and improvements. 

### Days 6 - 9:

We, being the amazing people that we are, seem to have abandoned updating the readme every day, instead we focussed purely on the development of the game. These days (Wednesday - Saturday) we spent the majority of our time adding levels to the game, working to playtest each others levels as we finished them and ironing out any kinks as they were discovered. 

Saturday was spend fixing as many of the UI issues as we could, refining the layout and UX for the game, and ensuring that everything was connected as intended. We also spent some time working on finding and adding all the sounds that you hear in game, adding a new sound manager class to handle it all for us, making our lives much easier. 

### Day 10:

We counted slightly wrong, and this is day 9 for most people, however because we started counting on day 0, this is day 10 for us. Today has been mostly play testing through the game finding anything that needs fixing immediately, noting down anything that we can fix later and just generally tidying everything up as well as updating the credits and attributions, then setting up the game page and figuring out how to upload it. Then we've got around 24 hours to polish and refine and upload another build if we have the time! 

## Going forwards:

We have many plans to keep this project alive, at a much slower pace though, so we can focus on getting it right and taking the time we need to give it the attention that it really deserves. Watch this space for updates, alternatively, join us on discord! Reach out at any point with ideas or suggestions. We're always open to new ideas from anyone! 
