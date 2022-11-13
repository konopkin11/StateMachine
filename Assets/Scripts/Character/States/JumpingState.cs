using UnityEngine;

namespace Character.States
{
    public class JumpingState : StateCharacter
    {
        private bool grounded;
        private int jumpParam = Animator.StringToHash("Jump");
        private int landParam = Animator.StringToHash("Land");
        public JumpingState(Character character, StateMachineCharacter stateMachine) : base(character, stateMachine)
        {
        }
        public override void Enter()
        {
            base.Enter();
            grounded = false;
            Jump();
        }

        public override void Exit()
        {
            base.Exit();
            
        }

        public override void HandleInput()
        {
            base.HandleInput();
            
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (grounded)
            {
                character.TriggerAnimation(landParam);
                stateMachine.ChangeState(character.standing);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            grounded = character.CheckCollisionOverlap(character.transform.position);
            
        }

        private void Jump()
        {
            character.TriggerAnimation(jumpParam);
            character.transform.Translate(Vector3.up * (character.CollisionOverlapRadius * 1.01f));
            character.ApplyImpulse(Vector3.up * character.JumpForce);
        }
    }
}
