using UnityEngine;

namespace Character
{
    public abstract class StateCharacter
    {
        protected Character character;
        protected StateMachineCharacter stateMachine;

        protected StateCharacter(Character character, StateMachineCharacter stateMachine)
        {
            this.character = character;
            this.stateMachine = stateMachine;
        }

        protected void DisplayOnUI()
        {
            Debug.Log(this);
        }
        public virtual void Enter()
        {
            DisplayOnUI();
        }

        public virtual void HandleInput()
        {

        }

        public virtual void LogicUpdate()
        {

        }

        public virtual void PhysicsUpdate()
        {

        }

        public virtual void Exit()
        {

        }
    }
}