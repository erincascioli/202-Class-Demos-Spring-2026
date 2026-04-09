using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public Vector3 location;

    void Start()
    {
        location = transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            location = new Vector3(
                Random.Range(-40, 40),
                Random.Range(-20, 20),
                0);
        }

        transform.position = location;
    }
}
