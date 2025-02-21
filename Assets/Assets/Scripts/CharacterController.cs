using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float velocity = 10f;
    [SerializeField]
    private float jumpForce = 100f;
    private Rigidbody rb;
    private bool jumped = false;
    private bool IsDead = false;

    private CharacterControls characterControls;

    public Action onDeath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterControls = new CharacterControls();
        characterControls.Enable();
        rb = GetComponent<Rigidbody>();
        onDeath += Die;
     }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumped = false;
        }     
    }

    private void FixedUpdate()
    {
        if (!IsDead)
        {
            float direction = characterControls.Character.Move.ReadValue<float>();
            rb.MovePosition(transform.position + transform.forward * direction * Time.fixedDeltaTime * velocity);

            
            if (transform.position.y < -10f)
            {
                onDeath.Invoke();
            }
        }
    }
    private void OnEnable()
    {
        characterControls.Character.Jump.performed += OnJumped;
    }

    private void OnDisable()
    {
        characterControls.Character.Jump.performed -= OnJumped;
    }
    private void OnJumped(InputAction.CallbackContext context)
    {
        if (!jumped)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumped = true;
        }
    }

    void Die()
    {
        characterControls.Disable();
        rb.freezeRotation = false;
    }
}
