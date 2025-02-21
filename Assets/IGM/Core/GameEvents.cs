using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    #region Singelton
    private static GameEvents _instance;
    public static GameEvents I
    {
        get
        {
            if (_instance == null)
                _instance = FindFirstObjectByType<GameEvents>();

            return _instance;
        }
    }
    #endregion

    public delegate void GameEvent();

    public GameEvent OnStart;
    public GameEvent OnEnterGame;

    public GameEvent OnEveryFrame;
    public GameEvent OnFixedUpdate;
    public GameEvent OnTick_005;
    public GameEvent OnTick_01;

    void Start()
    {
        StartEvents();
        Update005();
        Update01();
    }

    async UniTaskVoid StartEvents()
    {
        OnStart?.Invoke();

        await UniTask.Delay(System.TimeSpan.FromSeconds(3));
        OnEnterGame?.Invoke();
    }

    void Update()
    {
        OnEveryFrame?.Invoke();
    }

    void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }

    async UniTaskVoid Update005()
    {
        OnTick_005?.Invoke();

        await UniTask.Delay(System.TimeSpan.FromSeconds(0.05f));
        Update005();
    }

    async UniTaskVoid Update01()
    {
        OnTick_01?.Invoke();

        await UniTask.Delay(System.TimeSpan.FromSeconds(0.1f));
        Update01();
    }
}