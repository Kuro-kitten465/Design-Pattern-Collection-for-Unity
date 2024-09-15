using DesignPattern.StateMachinePattern;
using UnityEngine;

namespace DesignPattern.StateMachinePattern
{
    public class JumpState : IStateMachine
    {
        public void EnterState()
        {
            Debug.Log("Cube start Jumping!");
        }

        public void ExitState()
        {
            Debug.Log("Cube stop Jumping!");
        }
    }
}
