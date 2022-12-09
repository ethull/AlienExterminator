# ai planning

## planning
- what are the possible states
    - what states might be children of anouther
- for each state what could happen, and how would that effect each state
    - if var x is y then change STATE
    - if x time passes then change STATE
- then impl in animator
- then impl in code

- fsm plan
- code plan

## fms plan
- variables
- state list
- state transitions

### variables
- bool isIdle
- bool isHit
- bool isDead
- bool isNextToPlayer
- bool isCloseToPlayer
- bool isFarFromPlayer

## new variables
- isIdle
- isHit
- isDead
- isAttacking
- is 

### state list
- IDLE
- GETHIT
- IDLEATTACK (Attack player from idle)
- PATROL (Walk between checkpoints)
- CHASE (Walk after player)
- CHASEATTACKCLOSE (Walk after player and attack) (attack player for medium damage)
- CHASEATTACKFAR (Walk after player and attack from far) (attack player for low damage)
- DEAD

### alien code state transitions
- if ANY STATE
    - if isDead -> DEAD STATE -> end animation
- if IDLE STATE // from here we could gethit, we could start patrolling
    - if isHit -> GETHIT STATE // GETHIT is accessable from IDLE, because if the player is close enougth we want to be in ChaseAttackState instead
    - after x time -> PATROL
    // - if playerDistance <1 -> IDLEATTACK STATE // this shouldnt be in IDLE because we want to enter chasing state first
- if PATROL STATE // from here the player could shoot it, or move closer
    - if GetHit -> GETHIT STATE
    - if playerDetected -> CHASE STATE
- if CHASE STATE // from here the player could move away, or move x amount closer
    - if !playerDetected -> IDLE STATE
    - if isNextToPlayer -> IDLEATTACK STATE
    - if isCloseToPlayer -> CHASEATTACKCLOSE STATE
    - if isFarFromPlayer -> CHASEATTACKFAR STATE
- if GETHIT STATE // want to move back to idle so we can start chaseing
    - after 1 sec -> IDLE STATE
- if IDLEATTACK STATE // from here the player could move away
    - if !isNextToPlayer -> CHASE
- if CHASEATTACKCLOSE STATE // from here the player could move closer or move away
    - if !isCloseToPlayer  -> CHASE
- if CHASEATTACKFAR STATE // from here the player could move closer or move away
    - if !isFarFromPlayer -> CHASE
- if DEAD STATE
    - end animation
    
## questions/thoughts
- link between idle and chase?
    - only for going back?
- animation is strictly about animation, all the logic is in the code