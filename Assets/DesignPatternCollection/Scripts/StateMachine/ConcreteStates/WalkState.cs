using DesignPattern.StateMachinePattern;
using UnityEngine;

namespace DesignPattern.StateMachinePattern
{
    public class WalkState : IStateMachine
    {
        public void EnterState()
        {
            Debug.Log("Cube start Walking!");
        }

        public void ExitState()
        {
            Debug.Log("Cube stop walking!");
        }
    }
}
