using DesignPattern.SingletonPattern;
using UnityEngine;

namespace DesignPattern.SingletonPattern
{
    public class GameManager : Singleton<GameManager>
    {
        public int Health { get { return m_health; } }
        public int Attack { get { return m_attack; } }

        private int m_health = 100;
        private int m_attack = 200;

        public void SetAttack(int value) => m_attack += value;
        public void SetHealth(int value) => m_health += value;
    }
}
