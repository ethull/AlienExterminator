# ai planning 2

## planning
- what are the possible states
    - what states might be children of anouther
- for each state what could happen, and how would that effect each state
    - if var x is y then change STATE
    - if x time passes then change STATE
- then impl in animator
- then impl in code

## variables
bool playerDetected
bool GetHit
bool isDead
### distances
- float detectDist (dD)
- float idleAtkDist (iAD)
- float closeAtkDist (cAD)
- float farAtkDist (fAD)

## alien states
- IDLE
    - GETHIT
    - IDLEATTACK (Attack player) // if we are really close we want to stop chasing and attack player for high damage
- PATROL (Walk between checkpoints)
- CHASE (Walk after player)
    (Walk after player and attack)
    - CHASEATTACKCLOSE (Walk attacking close) (attack player for medium damage)
    - CHASEATTACKFAR (Walk attacking from far) (attack player for low damage)
- DEAD

## alien state transitions
- if any STATE
    - if isDead -> DEAD STATE -> End Animation
- if IDLE STATE // from here we could gethit, we could start patrolling
    - if GetHit > 1 -> GETHIT STATE // GETHIT is accessable from IDLE, because if the player is close enougth we want to be in ChaseAttackState instead
    // - if playerDistance <1 -> IDLEATTACK STATE // this shouldnt be in IDLE because we want to enter chasing state first
    - after x time start PATROL
- if PATROL STATE // from here the player could shoot it, or move closer
    - if GetHit > 1 -> GETHIT STATE
    - if playerDetected == true -> CHASE STATE
- if CHASE STATE // from here the player could move away, or move x amount closer
    - if playerDetected == false -> IDLE STATE
    //- if playerDistance < iAD -> IDLEATTACK STATE
    //- if playerDistance < cAD -> CHASEATTACKCLOSE STATE
    - if playerDistance < fAD -> CHASEATTACKFAR STATE
- if GETHIT STATE // want to move back to idle so we can start chaseing
    - after 1 sec -> IDLE STATE
- if IDLEATTACK STATE // from here the player could move away
    - if playerDistance > iAD -> CHASEATTACKCLOSE // // move to CHASE rather than CHASEATTACKCLOSE to attacks aren't straight after each other
- if CHASEATTACKCLOSE STATE // from here the player could move closer or move away
    - if playerDistance < iAD -> IDLEATTACK STATE
    - if playerDistance > cAD -> CHASEATTACKFAR STATE
- if CHASEATTACKFAR STATE // from here the player could move closer or move away
    - if playerDistance < fAD -> CHASEATTACKCLOSE STATE
    - if playerDistance > fAD -> CHASE STATE
- if DEAD STATE
    - end animation
// from a closer attack state, do we want to go straight to the one above or just go back to chase?
## questions
### does this planning need redoing
- this is getting the animator and the logic mixed up
    - the animator doesnt support logic
        - can only have < and > for floats
    - playerDistance > x -> isNextTo, isClose, isFar
    // am getting the logic and code mixed up