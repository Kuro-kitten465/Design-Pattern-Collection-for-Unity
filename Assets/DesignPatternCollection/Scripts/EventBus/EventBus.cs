using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DesignPattern.EventBusPattern
{
    public class EventBus : MonoBehaviour
    {
        #region Static EventBus
        private static readonly Dictionary<Enum, UnityEvent>
                       Events = new Dictionary<Enum, UnityEvent>();

        public static void Subscribe(Enum eventType, UnityAction listener)
        {
            if (!Events.TryGetValue(eventType, out UnityEvent thisEvent))
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Events.Add(eventType, thisEvent);
            }
            else
            {
                thisEvent.RemoveAllListeners();
                thisEvent.AddListener(listener);
                Events[eventType] = thisEvent;
            }
        }

        public static void UnSubScribe(Enum eventType, UnityAction listener)
        {
            if (Events.TryGetValue(eventType, out UnityEvent thisEvent))
                thisEvent.RemoveListener(listener);
        }

        public static void Publish(Enum eventType)
        {
            if (Events.TryGetValue(eventType, out UnityEvent thisEvent))
                thisEvent.Invoke();
        }
        #endregion

        #region non-Static EventBus
        private readonly Dictionary<Enum, UnityEvent>
                       m_events = new Dictionary<Enum, UnityEvent>();

        public void Register(Enum eventType, UnityAction listener)
        {
            if (!m_events.TryGetValue(eventType, out UnityEvent thisEvent))
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                m_events.Add(eventType, thisEvent);
            }
            else
            {
                thisEvent.RemoveAllListeners();
                thisEvent.AddListener(listener);
                m_events[eventType] = thisEvent;
            }
        }

        public void UnRegister(Enum eventType, UnityAction listener)
        {
            if (m_events.TryGetValue(eventType, out UnityEvent thisEvent))
                thisEvent.RemoveListener(listener);
        }

        public void InvokeEvent(Enum eventType)
        {
            if (m_events.TryGetValue(eventType, out UnityEvent thisEvent))
                thisEvent.Invoke();
        }
        #endregion
    }
}
