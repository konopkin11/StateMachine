using UnityEngine;

namespace Character.States
{
    public class GroundedState : StateCharacter
    {
        protected float speed;
        protected float rotationSpeed;

        private float horizontalInput;
        private float verticalInput;

        public GroundedState(Character character, StateMachineCharacter stateMachine) : base(character, stateMachine)
        {
        }
        public override void Enter()
        {
            base.Enter();
            horizontalInput = verticalInput = 0.0f;
        }

        public override void Exit()
        {
            base.Exit();
            character.ResetMoveParams();
        }

        public override void HandleInput()
        {
            base.HandleInput();
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            character.Move(verticalInput * speed, horizontalInput * rotationSpeed);
        }
    }
}
