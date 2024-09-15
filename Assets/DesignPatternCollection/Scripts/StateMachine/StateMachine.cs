using System;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.StateMachinePattern
{
    public class StateMachine
    {
        public Enum OnState { get { return m_stateType; } }

        private IStateMachine m_currentState = null;
        private Enum m_stateType;
        private Dictionary<Enum, IStateMachine> m_states = new Dictionary<Enum, IStateMachine>();

        public StateMachine(Dictionary<Enum, IStateMachine> states)
        {
            m_states = states;
        }

        private void TransitionState(Enum stateType, IStateMachine newState)
        {
            m_currentState?.ExitState();
            m_currentState = newState;
            m_stateType = stateType;
            m_currentState.EnterState();
        }

        public void ChangeState(Enum stateType)
        {
            IStateMachine currentState;

            if (m_states.TryGetValue(stateType, out currentState))
            {
                TransitionState(stateType, currentState);
            }
            else
            {
                Debug.LogWarning("No handler found for event type: " + stateType);
            }
        }
    }
}
