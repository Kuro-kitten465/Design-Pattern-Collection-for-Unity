using UnityEngine;

namespace DesignPattern.EventBusPattern
{
    public class EventBusClient : MonoBehaviour
    {
        private enum ClickEvent
        {
            ClickBTN1, ClickBTN2
        }

        private EventBus m_eventBus;
        private string notify;

        private void OnEnable()
        {
            //Static m_EventBus
            EventBus.Subscribe(ClickEvent.ClickBTN1, OnClick1);
            EventBus.Subscribe(ClickEvent.ClickBTN2, OnClick2);

            //non-Static m_EventBus
            m_eventBus = gameObject.AddComponent<EventBus>();
            m_eventBus.Register(ClickEvent.ClickBTN1, OnClick1);
            m_eventBus.Register(ClickEvent.ClickBTN2, OnClick2);
        }

        private void OnClick1()
        {
            notify = "m_EventBus is Working on " + ClickEvent.ClickBTN1.ToString();
            Debug.Log(notify);
        }

        private void OnClick2()
        {
            notify = "m_EventBus is Working on " + ClickEvent.ClickBTN2.ToString();
            Debug.Log(notify);
        }

        private void OnDisable()
        {
            RemoveEvents();
        }

        private void RemoveEvents()
        {
            //Static m_EventBus
            EventBus.UnSubScribe(ClickEvent.ClickBTN1, OnClick1);
            EventBus.UnSubScribe(ClickEvent.ClickBTN2, OnClick2);

            //non-Static m_EventBus
            m_eventBus.UnRegister(ClickEvent.ClickBTN1, OnClick1);
            m_eventBus.UnRegister(ClickEvent.ClickBTN2, OnClick2);

            notify = "Remove Successfully! you may now disconnect from Button";
            Debug.Log("Remove Successfully");
        }

        private void OnGUI()
        {
            GUILayout.Label(notify);

            //Static m_EventBus
            if (GUILayout.Button("BTN1"))
                EventBus.Publish(ClickEvent.ClickBTN1);
            if (GUILayout.Button("BTN2"))
                EventBus.Publish(ClickEvent.ClickBTN2);

            //non-Static m_EventBus
            if (GUILayout.Button("BTN1-Non-Static"))
                m_eventBus.InvokeEvent(ClickEvent.ClickBTN1);
            if (GUILayout.Button("BTN2-Non-Static"))
                m_eventBus.InvokeEvent(ClickEvent.ClickBTN2);

            if (GUILayout.Button("Remove Events"))
                RemoveEvents();
        }
    }
}
