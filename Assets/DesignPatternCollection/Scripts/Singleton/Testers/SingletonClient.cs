using UnityEngine;

namespace DesignPattern.SingletonPattern
{
    public class SingletonClient : MonoBehaviour
    {
        private GameManager m_gameManager;

        private void Start()
        {
            m_gameManager = FindAnyObjectByType<GameManager>();

            if (m_gameManager != null)
                Debug.Log($"{m_gameManager.name} is already registered to {name}.");
        }

        private void OnGUI()
        {
            GUILayout.Label($"Player Health: {m_gameManager.Health}");
            GUILayout.Label($"Player Attack: {m_gameManager.Attack}");

            if (GUILayout.Button("Increase 100 HP"))
                m_gameManager.SetHealth(100);

            if (GUILayout.Button("Increase 100 ATK"))
                m_gameManager.SetAttack(100);

            if (GUILayout.Button("Reduce 100 HP"))
                m_gameManager.SetHealth(-100);

            if (GUILayout.Button("Reduce 100 ATK"))
                m_gameManager.SetAttack(-100);            
        }
    }
}
