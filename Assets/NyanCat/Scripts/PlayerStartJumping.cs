using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayerStartJumping : MonoBehaviour
{
    [SerializeField] PlayerController m_controller;
    [SerializeField] float m_jumpingRate = 1;
    [SerializeField] int m_jumpCount = 4;

    int _currentJump;

    public async UniTaskVoid JumpingLoop()
    {
        m_controller.Jump();
        _currentJump++;

        if (_currentJump >= m_jumpCount) 
            return;

        await UniTask.Delay(System.TimeSpan.FromSeconds(m_jumpingRate));
        JumpingLoop();
    }
}