using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertScript : MonoBehaviour
{
    [SerializeField]
    private GameObject enrageZone;
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();
    [SerializeField]
    private GameObject retreatpoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject enemy in enemies)
            {
                EnemyScript gameObject = enemy.GetComponent<EnemyScript>();
                Debug.Log("Entered alert trigger");
                gameObject.onAlert.Invoke();
            }
            StartCoroutine(StartCountdown());
        }
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(enrageZone);
        foreach (GameObject enemy in enemies)
        {
            if(enemy.GetComponent<EnemyScript>().state != EnemyScript.State.Enraged) {
                EnemyMovement gameObject = enemy.GetComponent<EnemyMovement>();
                Debug.Log("Entered trigger");
                gameObject.moveToDestination(retreatpoint.transform.position);
                gameObject.GetComponent<EnemyScript>().onCalmDown.Invoke();
            }
            
        }

    }


    }
