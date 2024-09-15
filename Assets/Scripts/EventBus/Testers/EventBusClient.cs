using UnityEngine;

namespace DesignPattern.EventBusPattern
{
    public class EventBusClient : MonoBehaviour
    {
        private enum ClickEvent
        {
            ClickBTN1, ClickBTN2
        }

        private EventBus eventBus;

        private void OnEnable()
        {
            //Static EventBus
            EventBus.Subscribe(ClickEvent.ClickBTN1, OnClick1);
            EventBus.Subscribe(ClickEvent.ClickBTN2, OnClick2);
            EventBus.Subscribe(ClickEvent.ClickBTN2, OnClick2);

            //non-Static EventBus
            eventBus = gameObject.AddComponent<EventBus>();
            eventBus.RegisterEvent(ClickEvent.ClickBTN1, OnClick1);
            eventBus.RegisterEvent(ClickEvent.ClickBTN2, OnClick2);
            eventBus.RegisterEvent(ClickEvent.ClickBTN2, OnClick2);
        }

        private void OnClick1()
        {
            Debug.Log("EventBus is Working on " + ClickEvent.ClickBTN1.ToString());
        }

        private void OnClick2()
        {
            Debug.Log("EventBus is Working on " + ClickEvent.ClickBTN2.ToString());
        }

        private void OnDisable()
        {
            //Static EventBus
            EventBus.UnSubScribe(ClickEvent.ClickBTN1, OnClick1);
            EventBus.UnSubScribe(ClickEvent.ClickBTN2, OnClick2);

            //non-Static EventBus
            eventBus.UnRegisterEvent(ClickEvent.ClickBTN1, OnClick1);
            eventBus.UnRegisterEvent(ClickEvent.ClickBTN2, OnClick2);
        }

        private void RemoveEvents()
        {
            //Static EventBus
            EventBus.UnSubScribe(ClickEvent.ClickBTN1, OnClick1);
            EventBus.UnSubScribe(ClickEvent.ClickBTN2, OnClick2);

            //non-Static EventBus
            eventBus.UnRegisterEvent(ClickEvent.ClickBTN1, OnClick1);
            eventBus.UnRegisterEvent(ClickEvent.ClickBTN2, OnClick2);

            Debug.Log("Remove Successfully");
        }

        private void OnGUI()
        {
            //Static EventBus
            if (GUILayout.Button("BTN1"))
                EventBus.Publish(ClickEvent.ClickBTN1);
            if (GUILayout.Button("BTN2"))
                EventBus.Publish(ClickEvent.ClickBTN2);

            //non-Static EventBus
            if (GUILayout.Button("BTN1-Non-Static"))
                eventBus.InvokeEventBus(ClickEvent.ClickBTN1);
            if (GUILayout.Button("BTN2-Non-Static"))
                eventBus.InvokeEventBus(ClickEvent.ClickBTN2);

            if (GUILayout.Button("Remove Events"))
                RemoveEvents();
        }
    }
}
