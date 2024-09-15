using DesignPattern.StateMachinePattern;
using UnityEngine;

public class StopState : IStateMachine
{
    public void EnterState()
    {
        Debug.Log("Cube start Standing!");
    }

    public void ExitState()
    {
        Debug.Log("Cube stop Standing!");
    }
}
