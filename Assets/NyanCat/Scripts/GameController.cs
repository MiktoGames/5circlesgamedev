using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] float m_startDelay = 0.2f;
    [SerializeField] float m_controllActivateDelay = 1;
    [SerializeField] AudioSource m_audioSource;
    [SerializeField] PlayerController m_playerController;
    [SerializeField] PlayerStartJumping m_playerStartJumping;
    [SerializeField] PlayerAI m_playerAI;

    void Start()
    {
        PlayMusic();
        StartDelay();
        ControllActivateDelay();
    }

    void PlayMusic()
    {
        m_audioSource?.Play();
    } 

    async UniTaskVoid StartDelay()
    {
        await UniTask.Delay(System.TimeSpan.FromSeconds(m_startDelay));
            m_playerStartJumping.JumpingLoop();
    }

    async UniTaskVoid ControllActivateDelay()
    {
        await UniTask.Delay(System.TimeSpan.FromSeconds(m_controllActivateDelay));
        m_playerController.SetActiveInput(true);
        m_playerAI.Activate();
    }
}