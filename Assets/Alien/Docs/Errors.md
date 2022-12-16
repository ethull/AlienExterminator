# errors

## Level manager problems 1
UnityException: Tag: LevelManager is not defined.
InsectController.Start () (at Assets/Alien/Scripts/AI/InsectController.cs:34)

inventory script
UnityEngine.Debug:Log (object)
Inventory:Start () (at Assets/Alien/Scripts/Inventory.cs:21)

UnityException: Tag: LevelManager is not defined.
PlayerController.Start () (at Assets/Alien/Scripts/PlayerController.cs:16)

UnityException: Tag: LevelManager is not defined.
PlayerController.Start () (at Assets/Alien/Scripts/PlayerController.cs:16)

UnityException: Tag: AlienSpawner is not defined.
LevelManager.Start () (at Assets/Alien/Scripts/Game/LevelManager.cs:28)

NullReferenceException: Object reference not set to an instance of an object
InsectController.OnDie () (at Assets/Alien/Scripts/AI/InsectController.cs:60)
Health.HandleDeath () (at Assets/Alien/Scripts/Shared/Health.cs:62)
Health.TakeDamage (System.Single damage, UnityEngine.GameObject damageSource) (at Assets/Alien/Scripts/Shared/Health.cs:40)
Gun.Shoot () (at Assets/Alien/Scripts/Gun.cs:64)
Gun.Update () (at Assets/Alien/Scripts/Gun.cs:37)

## Level manager problems 2
- game cant find insectspawner and levelmanager
- they are missing their tags
NullReferenceException: Object reference not set to an instance of an object
InsectController.Start () (at Assets/Alien/Scripts/AI/InsectController.cs:34)

NullReferenceException: Object reference not set to an instance of an object
PlayerController.Start () (at Assets/Alien/Scripts/PlayerController.cs:16)

NullReferenceException: Object reference not set to an instance of an object
PlayerController.Start () (at Assets/Alien/Scripts/PlayerController.cs:16)

NullReferenceException: Object reference not set to an instance of an object
LevelManager.Start () (at Assets/Alien/Scripts/Game/LevelManager.cs:28)

NullReferenceException: Object reference not set to an instance of an object
InsectController.OnDie () (at Assets/Alien/Scripts/AI/InsectController.cs:60)
Health.HandleDeath () (at Assets/Alien/Scripts/Shared/Health.cs:62)
Health.TakeDamage (System.Single damage, UnityEngine.GameObject damageSource) (at Assets/Alien/Scripts/Shared/Health.cs:40)
Gun.Shoot () (at Assets/Alien/Scripts/Gun.cs:64)
Gun.Update () (at Assets/Alien/Scripts/Gun.cs:37)

## problem with lighting
- lighting does not work after switching from the main menu
- https://answers.unity.com/questions/1264278/unity-5-directional-light-problem-please-help.html

## getting ai state to work
- unity learn AI and state courses
- https://learn.unity.com/tutorial/creating-and-using-a-state-class-1?uv=2019.4&projectId=5e0b85cdedbc2a144cf5cde5#
- https://learn.unity.com/search?k=%5B%22q%3Aai%22%2C%22lang%3Aen%22%2C%22tag%3A5d351f087fbf7d006af48180%22%5D

### Continous GetHits even after alien is hit
- change state machine so GetHit only runs once
- https://stackoverflow.com/questions/57442480/stop-animation-looping-back-to-initial-position-in-unity3d

### how to hit player during insect animation
- https://answers.unity.com/questions/1175964/make-an-animation-do-damage.html
- https://answers.unity.com/questions/45070/play-animation-only-once.html
- https://answers.unity.com/questions/1023873/how-do-you-run-an-animation-only-once.html
- https://stackoverflow.com/questions/63082951/unity2d-attack-animation-and-damage-timing
- https://forum.unity.com/threads/best-practice-for-triggers-collider-hits-and-animation.856324/
- https://forum.unity.com/threads/running-a-script-in-animation-timeline.431919/

- https://answers.unity.com/questions/37211/detecting-which-collider-involved-in-trigger-colli.html

## basic shooting (raycast) and gun switching
- https://www.youtube.com/watch?v=THnivyG0Mvo
- https://answers.unity.com/questions/573601/how-can-i-get-the-tag-of-the-first-object-raycast.html

# level switching

## creating menus and getting menu buttons to do things
- https://www.youtube.com/watch?v=zc8ac_qUXQY
- https://www.youtube.com/watch?v=JivuXdrIHK0

## saving data between scenes and sessions
- https://learn.unity.com/mission/programming-systems-and-architecture
- https://learn.unity.com/tutorial/implement-data-persistence-between-scenes-1
- https://learn.unity.com/tutorial/implement-data-persistence-between-sessions

## disable buttons relative to levels cleared
- https://www.codegrepper.com/tpc/unity+disable+button
- https://stackoverflow.com/questions/39633143/get-a-reference-to-a-button-from-script-in-unity
- https://stackoverflow.com/questions/53915354/how-to-fix-the-type-or-namespace-name-could-not-be-found-error-in-unity
    - import UnityEngine.UI

## cant find MainManager object
- moved MainManager gameObject from level01 to mainmenu, so its avaliable throughout the entire games lifetime
- https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html

## doesnt select correct menu after death/clear
- goes to Start menu after death/clear, rather than specific death/clear menus

Start method run
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:24)
Menus (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:25)
StartMenu (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:26)
LevelSelectMenu (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:27)
LevelClearMenu (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:28)
GameOverMenu (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:29)

Start method run
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:24)
Menus (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:25)
StartMenu (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:26)
LevelSelectMenu (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:27)
LevelClearMenu (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:28)
GameOverMenu (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:29)

Selecting Menu: LevelSelect
UnityEngine.Debug:Log (object)
CurrentSceneManager:SelectMenu (string) (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:52)
UnityEngine.EventSystems.EventSystem:Update () (at Library/PackageCache/com.unity.ugui@1.0.0/Runtime/EventSystem/EventSystem.cs:501)

Level cleared
UnityEngine.Debug:Log (object)
LevelManager:levelCleared () (at Assets/Alien/Scripts/Game/LevelManager.cs:46)
LevelManager:enemyKilled () (at Assets/Alien/Scripts/Game/LevelManager.cs:99)
InsectController:OnDie () (at Assets/Alien/Scripts/AI/InsectController.cs:60)
Health:HandleDeath () (at Assets/Alien/Scripts/Shared/Health.cs:62)
Health:TakeDamage (single,UnityEngine.GameObject) (at Assets/Alien/Scripts/Shared/Health.cs:40)
Gun:Shoot () (at Assets/Alien/Scripts/Gun.cs:64)
Gun:Update () (at Assets/Alien/Scripts/Gun.cs:37)

// start is not run before LevelClear is (but is after), maybe Start refs are old

Selecting Menu: LevelClear
UnityEngine.Debug:Log (object)
CurrentSceneManager:SelectMenu (string) (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:52)
LevelCLear
UnityEngine.Debug:Log (object)
CurrentSceneManager:SelectMenu (string) (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:73)

MissingReferenceException: The object of type 'GameObject' has been destroyed but you are still trying to access it.
Your script should either check if it is null or you should not destroy the object.
CurrentSceneManager.SelectMenu (System.String menuName) (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:74)
CurrentSceneManager.ClearLevel () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:105)
LevelManager.levelCleared () (at Assets/Alien/Scripts/Game/LevelManager.cs:54)
LevelManager.enemyKilled () (at Assets/Alien/Scripts/Game/LevelManager.cs:99)
InsectController.OnDie () (at Assets/Alien/Scripts/AI/InsectController.cs:60)
Health.HandleDeath () (at Assets/Alien/Scripts/Shared/Health.cs:62)
Health.TakeDamage (System.Single damage, UnityEngine.GameObject damageSource) (at Assets/Alien/Scripts/Shared/Health.cs:40)
Gun.Shoot () (at Assets/Alien/Scripts/Gun.cs:64)
Gun.Update () (at Assets/Alien/Scripts/Gun.cs:37)

Start method run
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:24)
Menus (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:25)
StartMenu (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:26)
LevelSelectMenu (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:27)
LevelClearMenu (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:28)
GameOverMenu (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
CurrentSceneManager:Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:29)

// new error after refreshing start first

NullReferenceException: Object reference not set to an instance of an object
CurrentSceneManager.Start () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:20)
CurrentSceneManager.SelectMenu (System.String menuName) (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:59)
CurrentSceneManager.ClearLevel () (at Assets/Alien/Scripts/Game/CurrentSceneManager.cs:107)
LevelManager.levelCleared () (at Assets/Alien/Scripts/Game/LevelManager.cs:54)
LevelManager.enemyKilled () (at Assets/Alien/Scripts/Game/LevelManager.cs:99)
InsectController.OnDie () (at Assets/Alien/Scripts/AI/InsectController.cs:60)
Health.HandleDeath () (at Assets/Alien/Scripts/Shared/Health.cs:62)
Health.TakeDamage (System.Single damage, UnityEngine.GameObject damageSource) (at Assets/Alien/Scripts/Shared/Health.cs:40)
Gun.Shoot () (at Assets/Alien/Scripts/Gun.cs:64)
Gun.Update () (at Assets/Alien/Scripts/Gun.cs:37)


if we use old component ref variables: get MissingReferenceException
if we reset the component ref variables: get NullReferenceException
it tells use we are still in level01
    might be calling old Scene Manager script in level01, instead of calling the new one?
    might be taking too long to laod scene
    why are the vars avaliable from level01

i could decouple scene and menu management from each other
 as the menu management is only needed in the menu
 then i could also make the scene manager static
worse comes to worse, i could put each menu in its own scene

## buttons dont work after returning to menu
- unity menus dont work after changing scenes
- untiy buttons dont work after returning to menu

- the cursor was locked by firstperson-aio
- https://answers.unity.com/questions/1626273/how-to-unhide-cursor-when-going-to-main-menu.html
- rip 2 hours _-_

# alien ai script errors
alien patrol script u cunt
UnityEngine.Debug:Log (object)
Patrol:Update () (at Assets/Alien/Scripts/AI/Patrol.cs:68)
State:Process () (at Assets/Alien/Scripts/AI/State.cs:55)
InsectController:Update () (at Assets/Alien/Scripts/AI/InsectController.cs:39)

insect(Clone) (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)
Patrol:Update () (at Assets/Alien/Scripts/AI/Patrol.cs:69)
State:Process () (at Assets/Alien/Scripts/AI/State.cs:55)
InsectController:Update () (at Assets/Alien/Scripts/AI/InsectController.cs:39)

insect(Clone) (UnityEngine.NavMeshAgent)
UnityEngine.Debug:Log (object)
Patrol:Update () (at Assets/Alien/Scripts/AI/Patrol.cs:70)
State:Process () (at Assets/Alien/Scripts/AI/State.cs:55)
InsectController:Update () (at Assets/Alien/Scripts/AI/InsectController.cs:39)

MissingReferenceException: The object of type 'GameObject' has been destroyed but you are still trying to access it.
Your script should either check if it is null or you should not destroy the object.
Patrol.Update () (at Assets/Alien/Scripts/AI/Patrol.cs:71)
State.Process () (at Assets/Alien/Scripts/AI/State.cs:55)
InsectController.Update () (at Assets/Alien/Scripts/AI/InsectController.cs:39)

// with more prints

alien patrol script u cunt
UnityEngine.Debug:Log (object)

npc: insect(Clone) (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)

agent: insect(Clone) (UnityEngine.NavMeshAgent)
UnityEngine.Debug:Log (object)

gameenv: GameEnvironment
UnityEngine.Debug:Log (object)

gameenv check: System.Collections.Generic.List`1[UnityEngine.GameObject]
UnityEngine.Debug:Log (object)

MissingReferenceException: The object of type 'GameObject' has been destroyed but you are still trying to access it.
Your script should either check if it is null or you should not destroy the object.


alien patrol script u cunt
UnityEngine.Debug:Log (object)

npc: insect(Clone) (UnityEngine.GameObject)
UnityEngine.Debug:Log (object)

agent: insect(Clone) (UnityEngine.NavMeshAgent)
UnityEngine.Debug:Log (object)

gameenv: GameEnvironment
UnityEngine.Debug:Log (object)

gameenv check: System.Collections.Generic.List`1[UnityEngine.GameObject]
UnityEngine.Debug:Log (object)

MissingReferenceException: The object of type 'GameObject' has been destroyed but you are still trying to access it.
Your script should either check if it is null or you should not destroy the object.

spent 1 hour of mtd, found anouther that took 15 mins
ended up i was getting nulls in static GameEnvironment, added an extra condition to make it reload on new scenes