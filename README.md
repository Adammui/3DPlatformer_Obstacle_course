# 3DPlatformer_pet - is simple 3D platformer that was made as a pet project
# Little fox model is `by` [`bonfire`](https://sketchfab.com/bonfire.png)
## Description
This project is created mainly for testing my abilities, i wanted to see how much i will be able to do from the little idea and a task to show what i can do in little given time for development
I spent most of the time working on this project studying things i dont know or remember and had fun planning it. <br>
<img src="https://github.com/Adammui/3DPlatformer_likeFallguys/assets/53793144/608ee352-0db6-4791-bb68-e20115f2f560" width="330" height="200" /> <img src="https://github.com/Adammui/3DPlatformer_likeFallguys/assets/53793144/538aecb5-89e9-41ab-91eb-0a0e44a25324" width="330" height="200" />
<br>
## Features
- Character setup
  - Movement provided with Unity CharacterController and super simple PlayerController class.
  - Camera is managed by CameraController it is simple and just follows player, i dont think this test project needs complex and visely designed controllable camera.
  - PlayerStats controls health and level(scene) player is on.
- Platforms and environment
  - WindPlatform - "A block on which the wind blows, pushing the character with a certain force. The wind acts on
    character only while he is in the block. The wind direction changes every 2 seconds for
    random side. The wind blows strictly horizontally".
  - PulsePlatform - "When a player steps on a block, it is activated (lights up orange) and after 1 second
    will damage anyone standing on the block (by blinking red). After dealing damage, trap
    “re-starts” for some time, after which it begins its logic from the very beginning".
  - Moving - "Moving platform that can push player off the arena or make it difficult to get to the finish".

## Plans for revision
- [ ] clean up and structure code
- [ ] pause functions for levels
- [ ] gesign some levels, currently its in a more technical state.
- [ ] add light and textures\ materials(i wanted background to be starry space).
- [ ] add character selection menu with customisable characters (color of cape, stats)

## Video
showcase of 2 particular logic blocks - pulse and wind.

https://github.com/Adammui/3DPlatformer_likeFallguys/assets/53793144/b64f623b-f8f0-41fc-91e6-ef4ae3241891

running around and winning game.

https://github.com/Adammui/3DPlatformer_likeFallguys/assets/53793144/eb33311b-a89e-4c46-b31b-596241f056c6

## Reference
[`@agoodboygames`](https://www.youtube.com/@agoodboygames) used some of his code while creating movement <br>
[`@iHeartGameDev`](https://www.youtube.com/@iHeartGameDev) overall a lot of info <br>
[`discussions.unity.com`](https://discussions.unity.com)   :^/ <br>
model of fox by [`bonfire`](https://sketchfab.com/bonfire.png) REALLY CUTE THING <br>