using UnityEngine;

namespace Character.States
{
    public class StandingState : GroundedState
    {
        private bool jump;
        private bool crouch;

        public StandingState(Character character, StateMachineCharacter stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            speed = character.MovementSpeed;
            rotationSpeed = character.RotationSpeed;
            crouch = false;
            jump = false;
        }

        public override void HandleInput()
        {
            base.HandleInput();
            crouch = Input.GetKeyDown(KeyCode.LeftControl);
            jump = Input.GetKey(KeyCode.Space);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (crouch)
            {
                stateMachine.ChangeState(character.ducking);
            }
            else if (jump)
            {
                stateMachine.ChangeState(character.jumping);
            }
        }
    }
}