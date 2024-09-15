using UnityEngine;

namespace DesignPattern.SingletonPattern
{
    public class SingletonClient : MonoBehaviour
    {
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = FindAnyObjectByType<AudioSource>();

            if (audioSource == null) return;

            Debug.Log("Audio Source is Found at: " + audioSource.gameObject.name);
        }
    }
}
