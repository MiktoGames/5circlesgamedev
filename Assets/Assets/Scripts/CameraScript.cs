using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    Vector3 offset ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = character.transform.position + offset;
    }
}
