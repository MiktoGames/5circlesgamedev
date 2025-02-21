using UnityEngine;

public class EditorPlayerPathSpawner : MonoBehaviour
{
    [SerializeField] GameObject m_marker;
    [SerializeField] Transform m_parent;


    void OnEnable()
    {
        GameEvents.I.OnTick_01 += Spawn;
    }

    void OnDisable()
    {
        GameEvents.I.OnTick_01 -= Spawn;
    }

    void Spawn()
    {
        Instantiate(m_marker, transform.position, transform.rotation, m_parent);
    }
}