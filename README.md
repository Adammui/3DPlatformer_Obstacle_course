# 3DPlatformer_likeFallguys - simple platformer
# With little fox in cape i found  `by` [`bonfire`](https://sketchfab.com/bonfire.png)
## Description
Test task project. This project is created mainly for testing my abilities, i wanted to see how much i will be able to do from the idea i had. 
I spent like 3 full evenings on this, mostly studying the things i dont know or remember and just thinking about stuff. I had fun and am planning to finish it some time later. <br>
<img src="https://github.com/Adammui/3DPlatformer_likeFallguys/assets/53793144/608ee352-0db6-4791-bb68-e20115f2f560" width="330" height="200" /> <img src="https://github.com/Adammui/3DPlatformer_likeFallguys/assets/53793144/538aecb5-89e9-41ab-91eb-0a0e44a25324" width="330" height="200" /> 
<br>
## Features
- Character setup
  - Movement provided with Unity CharacterController and custom super simple PlayerController class. PlayerRigidbodyController I added it just in case I would need it; the character is not using it.
  - Camera is managed by CameraController it is simple and just follows player, i dont think this test project needs controllable camera.
  - PlayerHealthController handles lowering hp count when player takes hit and hearts on UI.
  - GameController handles in-game timer, winning and dying events, calls UI for both.
- Platforms and environment 
  - Wind - "A block on which the wind blows, pushing the character with a certain force. The wind acts on
character only while he is in the block. The wind direction changes every 2 seconds for
random. The wind blows strictly horizontally".
  - Pulse - "When a player steps on a block, it is activated (lights up orange) and after 1 second
will damage anyone standing on the block (by blinking red). After dealing damage, trap
“re-infects” for 5 seconds, after which it begins its logic from the very beginning".
  - Damage - ticks damage every second.
  - Moving - moving platform that can push player off the arena.
  - Meteor - spawning a lot of annoying small balls from spawn point, i mainly did this because i wanted game to be space themed.
  
## Plans for revision
- [ ] clean up code and useless files.
- [ ] pause
- [ ] improve level design, it is messy and excessive currently.
- [ ] add light and textures\ materials.
- [ ] add character selection menu with customisable characters (color of cape, etc.)
- [ ] maybe improve the camera and add background (i wanted it to be starry space).

## Video
showcase of main task with 2 particular logic blocks - pulse and wind. 

https://github.com/Adammui/3DPlatformer_likeFallguys/assets/53793144/b64f623b-f8f0-41fc-91e6-ef4ae3241891

running around and winning game.

https://github.com/Adammui/3DPlatformer_likeFallguys/assets/53793144/eb33311b-a89e-4c46-b31b-596241f056c6

## Reference
[`@agoodboygames`](https://www.youtube.com/@agoodboygames) used some of his code while creating movement <br>
[`@iHeartGameDev`](https://www.youtube.com/@iHeartGameDev) overall a lot of info <br>
[`discussions.unity.com`](https://discussions.unity.com)   :^/ <br> 
model of fox by [`bonfire`](https://sketchfab.com/bonfire.png) REALLY CUTE THING <br>
