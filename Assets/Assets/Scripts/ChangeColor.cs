using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Material material;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        GetComponentInParent<EnemyScript>().onCalmDown.AddListener(CalmDown);
        GetComponentInParent<EnemyScript>().onEnrage.AddListener(Enrage);
        GetComponentInParent<EnemyScript>().onAlert.AddListener(Alert);
    }

    // Update is called once per frame
    void Enrage()
    {
        material.color = Color.red;
    }

    void CalmDown()
    {
        material.color = Color.green;
    }

    void Alert()
    {
        material.color = Color.yellow;
    }
}
