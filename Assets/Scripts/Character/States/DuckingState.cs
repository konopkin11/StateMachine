using System.Text;
using UnityEngine;

namespace Character.States
{
    public class DuckingState : GroundedState
    {
        private bool belowCeiling;
        private bool crouchHeld;
        public DuckingState(Character character, StateMachineCharacter stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            //character.SetAnimationBool(character.crouchParam, true);
            speed = character.CrouchSpeed;
            rotationSpeed = character.CrouchRotationSpeed;
            character.ColliderSize = character.CrouchColliderHeight;
            belowCeiling = false;
        }
        public override void Exit()
        {
            base.Exit();
           // character.SetAnimationBool(character.crouchParam, false);
            character.ColliderSize = character.NormalColliderHeight;
        }

        public override void HandleInput()
        {
            base.HandleInput();
            crouchHeld = Input.GetKey(KeyCode.LeftControl);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (!(crouchHeld || belowCeiling))
            {
                stateMachine.ChangeState(character.standing);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            belowCeiling = character.CheckCollisionOverlap(character.transform.position +
                                                           Vector3.up * character.NormalColliderHeight);
        }
    }
}
