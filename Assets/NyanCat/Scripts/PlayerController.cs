using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_fvdSpeed = 3;
    [SerializeField] float m_gravity = -1;
    [SerializeField] float m_jumpForce = 5;
    [SerializeField] InputActionReference m_jump;

    float _yVelocity;
    bool _isActive;


    void OnEnable()
    {
        GameEvents.I.OnEveryFrame += EveryFrame;
        m_jump.ToInputAction().performed += InputJump;
    }

    void OnDisable()
    {
        GameEvents.I.OnEveryFrame -= EveryFrame;
        m_jump.ToInputAction().performed -= InputJump;
    }

    void EveryFrame()
    {
        MoveX();
        MoveY();
        Gravity();
    }

    void MoveX()
    {
        transform.position += Vector3.right * m_fvdSpeed * Time.deltaTime;
    }

    void MoveY()
    {
        transform.position += Vector3.up * _yVelocity * Time.deltaTime;
    }

    void Gravity()
    {
        _yVelocity -= m_gravity * Time.deltaTime;
    }

    void InputJump(InputAction.CallbackContext context = default)
    {
        if (_isActive == false)
            return;

        _yVelocity = m_jumpForce;
    }

    public void Jump()
    {
        _yVelocity = m_jumpForce;
    }


    public void SetActiveInput(bool active)
    {
        _isActive = active;
    }
}