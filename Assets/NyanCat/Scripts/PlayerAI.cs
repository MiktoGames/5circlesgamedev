using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    [SerializeField] Jump[] m_jumps;
    [SerializeField] PlayerController m_controller;

    public void Activate()
    {
        if (gameObject.activeSelf)
            Jumping();
    }

    async UniTaskVoid Jumping()
    {
        for(int i = 0;  i < m_jumps.Length; i++)
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(m_jumps[i].Time));
            m_controller.Jump();
        }
    }

    [Serializable]
    public class Jump
    {
        public float Time;
    }
}