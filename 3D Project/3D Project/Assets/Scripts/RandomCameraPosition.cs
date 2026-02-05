using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// Attach this to the Main Camera in the scene
/// </summary>
public class RandomCameraPosition : MonoBehaviour
{
    // References to the camera transform
    public GameObject mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Every time the space bar is pressed, the camera moves to a random position
        if(Input.GetKeyDown(KeyCode.Space))
        {
            float randomX = Random.Range(-2f, 2f);
            float randomY = Random.Range(-4f, 4f);
            Camera.main.transform.position = new Vector3(randomX, randomY, -20f);
            //gameObject.transform.position = new Vector3(randomX, randomY, -20);
        }
    }
}
