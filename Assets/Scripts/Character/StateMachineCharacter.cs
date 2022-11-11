using UnityEngine;

namespace Character
{
    public class StateMachineCharacter
    {
        public StateCharacter CurrentState { get; private set; }

        public void Initialize(StateCharacter startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }

        public void ChangeState(StateCharacter newState)
        {
            CurrentState.Exit();

            CurrentState = newState;
            newState.Enter();
        }
    }
}
