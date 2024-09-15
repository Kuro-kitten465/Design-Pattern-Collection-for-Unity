using DesignPattern.SingletonPattern;
using UnityEngine;

namespace DesignPattern.SingletonPattern
{
    public class GameManager : Singleton<GameManager>
    {
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = gameObject.GetComponent<AudioSource>();

            Debug.Log($"This {this} is ready!");
        }
    }
}
