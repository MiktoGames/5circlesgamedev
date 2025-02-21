using UnityEngine;

public class DeathUI : MonoBehaviour
{
    Canvas canvas;
    void Start()
    {
        canvas = GameObject.Find("UI").GetComponent<Canvas>();
        Debug.Log(canvas.name);
        GetComponent<CharacterController>().onDeath += ShowUI;
    }

    void ShowUI()
    {
        canvas.enabled = true;
    }
}
