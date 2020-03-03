# Blindslinger

<img src="screenshot1.png" alt="Screenshot" width="800"/>

[Youtube Video](https://www.youtube.com/watch?v=K99MYm-NKZA&feature=youtu.be)

## Description

Blindslinger is an experiment meant to demonstrate our ability to localize sources of sounds in three-dimentional space. A sphere is spawned and moves in a circular motion(can also be made stationary) around the player, looping an audio file. Using a spatializer, the sound not only changes according to it's position in the horizontal plane, but also reflects it's position in the vertical plane(above, underneath, or behind the user, etc). The user shoots the sphere, spawning a another one with a new position/trajectory. The spheres gradually becomes transparent as they are hit, until they are entirely invisible and the highlighted trajectory(colored red in the image) dissappears. Thus, the user is left with only their auditory sense to guide them. 

### Controls
The user is placed on a suspended platform, with a static gun-holding arm locked to the user's view. VR controllers are not used for tracking and is therefore not rendered; their only purpose is using their trigger for shooting. This is is order for the projectile to shoot consistently in a perfect forward-facing motion from the users face. 

# Background
Having two ears is generally enough to localize sounds in the horizontal plane, as most mammals' ears are oriented in this manner. In order to pinpoint a sound this space, the brain primarily uses two cues:

1. The interaural level difference (ILD) is the difference in loudness in one ear compared to the other.  

2. The interaural time difference (ITD) is the difference in the timing of the sound entering one ear compared to the other. 

A sound coming from the left will sound somewhat louder to the left ear than it does to the right ear. The brain picks up on that to determine where a sound is coming from. Similarly, the brain determines that a sound came from the left if it entered the left ear before it entered the right ear. This basic capability is common for most mammals. 

Many mammals cannot easily pinpoint sounds in the longitudinal plane(up, down, behind, in front). Primates are another story. Our auditory receptors(link to cells) are mediocre compared to other mammals, but we have world-class sound localization abilities. Primates can precisely pinpoint sounds in all directions, including the longitudinal plane. 

A sound coming from above sounds different than an identical one coming from below, as the sound is affected by our body and the shape of our ears. The processing power required to distinguish these variations are considerable, but the brains of primates enable the advanced processing that is nessecary to pinpoint sounds in all directions. 
(mention spectral modifications?)

## Spatial sound in VR

In most traditional first-person games, it is often enough to have the soundscape in the horizontal plane. In VR however, this is not optimal. If a VR experience doesn’t have realistic audio to match the visuals, it will break immersion. Considering that the benefits of VR are more pronounced when you’re fully immersed in it, this must be addressed. 

Standard stereo headphones enable directional sounds in the horizontal plane. In order to make soudns appear in all directions however, spectral modifications must be coded. 


The effect is achieved through head-related transfer function (HRTF)

The effect is reached using Occulus spatializer. 



## Equipment
The demo has only been tested on HTC Vive with Vive Controllers. Other HMDs should work, but it might be nessecary to use mouse-click to shoot.  






binaural audio, stereo
[SmarterEveryDay](https://www.youtube.com/watch?v=Oai7HUqncAA&t=322s)
[Ambisonic Audio](https://docs.unity3d.com/Manual/AmbisonicAudio.html) 