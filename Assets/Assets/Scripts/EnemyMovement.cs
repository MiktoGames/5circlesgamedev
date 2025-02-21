using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private GameObject player;
    private NavMeshAgent m_Agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Character");
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.speed = speed;
        Disable();
        GetComponentInParent<EnemyScript>().onEnrage.AddListener(Enable);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null) {
            m_Agent.SetDestination(player.transform.position);
        }
        
    }


    public void Enable()
    {
        this.enabled = true;
    }
    public void Disable()
    {
        this.enabled = false;
    }

    public void moveToDestination(Vector3 pos)
    {
        m_Agent.SetDestination(pos);
        player = null;
    }
}
