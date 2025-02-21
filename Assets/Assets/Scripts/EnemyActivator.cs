using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyActivator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject enemy in enemies)
            {
                EnemyScript gameObject = enemy.GetComponent<EnemyScript>();
                gameObject.onEnrage.Invoke();
                gameObject.state = EnemyScript.State.Enraged;
            }
        }
    }

}
