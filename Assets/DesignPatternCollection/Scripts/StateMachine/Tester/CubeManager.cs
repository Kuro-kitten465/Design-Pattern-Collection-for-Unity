using System;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.StateMachinePattern
{
    public class CubeManager : MonoBehaviour
    {
        public float Speed = 5f;
        public float Distance = 5f;

        private enum CubeState
        {
            None, WalkState, JumpState
        }

        private Vector3 startPos;

        private StateMachine m_stateMachine;
        private Dictionary<Enum, IStateMachine> m_states = new Dictionary<Enum, IStateMachine>();

        private void Awake()
        {
            m_states.Add(CubeState.JumpState, new JumpState());
            m_states.Add(CubeState.WalkState, new WalkState());
            m_states.Add(CubeState.None, new StopState());

            m_stateMachine = new StateMachine(m_states);

            startPos = gameObject.transform.position;

            m_stateMachine.ChangeState(CubeState.None);
        }

        private void Update()
        {
            if (m_stateMachine.OnState.Equals(CubeState.WalkState))
            {
                float newXPosition = Mathf.PingPong(Time.time * Speed, Distance) - Distance / 2;

                transform.position = new Vector3(startPos.x + newXPosition, startPos.y, startPos.z);
            }
            else if (m_stateMachine.OnState.Equals(CubeState.JumpState))
            {
                float newYPosition = Mathf.PingPong(Time.time * Speed, Distance) - Distance / 2;

                transform.position = new Vector3(startPos.x, startPos.y + newYPosition, startPos.z);
            }
            else
            {
                transform.position = startPos;
            }
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Walk State"))
                m_stateMachine.ChangeState(CubeState.WalkState);
            if (GUILayout.Button("Jump State"))
                m_stateMachine.ChangeState(CubeState.JumpState);
            if (GUILayout.Button("Stop State"))
                m_stateMachine.ChangeState(CubeState.None);
        }
    }
}
