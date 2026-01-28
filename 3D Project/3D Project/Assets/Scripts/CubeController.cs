using UnityEngine;

public class CubeController : MonoBehaviour
{
    // Fields of this CubeController class (set their values in Inspector)

    //                                      Values
    // Editable in Inspector
    public int number;                      // 100

    // Non-editable in Inspector
    private string word;                    // null

    // Editable in Inspector
    [SerializeField]
    private bool something;                 // true


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        number = 5;
        something = false;
        word = "birthday";

        Debug.Log(number);
        Debug.Log(something);
        Debug.Log(word);

        // Change X position to 100
        //transform.position.x = 100; NOOOOOOOOOOOOOOOOOOOOOOOO

        // Copy-Alter-Replace
        Vector3 positionCopy = transform.position;
        positionCopy.x = 100;
        transform.position = positionCopy;

        // CAR one step
        transform.position = new Vector3(100, 0, 0);

        // CAR one step (when you don't know the other axes)
        transform.position = new Vector3(
            100,                                    // X
            transform.position.y,                   // Y    
            transform.position.z);                  // Z
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
