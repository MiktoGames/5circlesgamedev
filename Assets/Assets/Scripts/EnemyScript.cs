using System;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EnemyScript : MonoBehaviour
{
    public enum State { Enraged, Alerted, Calm }
    public State state = State.Calm;
    public UnityEvent onEnrage;
    public UnityEvent onAlert;
    public UnityEvent onCalmDown;
    public event Action onCalm;

    void Start()
    {
        onCalmDown.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterController>().onDeath.Invoke();
            onCalmDown.Invoke();
        }
    }

}
