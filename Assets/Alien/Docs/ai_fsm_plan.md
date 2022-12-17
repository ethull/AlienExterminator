# fsm plan

## animations
- Idle
- Attack_Right
- Walk
- Walk_Attack
- Walk_Attack 2
- Walk_Get Hit
- GetHit
- Dead

## variables
- isIdle
- isAttacking
- isWalking
- isWalkAttacking
- isWalkAttacking2
- isWalkGetHit
- isGetHit
- isDead

## animation transitions
- from any state
    - if isDead -> Dead
- Idle
    - if isHit -> GetHit
    - if isWalking -> Walk
- Attack_Right
    - if isHit -> GetHit
    - if isWalking -> Walk
    - if isIdle - Idle
- Walk
    - if isWalkGetHit -> Walk_Get Hit
    - if isWalkAttacking -> Walk_Attack
    - if isWalkAttacking2 -> Walk_Attack 2
- Walk_Attack 2
    - if isWalking -> Walk
- Walk_Get Hit
    - if isWalking -> Walk
- GetHit
    - after x time -> Idle
- Dead