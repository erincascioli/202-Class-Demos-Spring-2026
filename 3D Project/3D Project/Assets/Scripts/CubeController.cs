using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;                   // Allows use of generic data structures

public class CubeController : MonoBehaviour
{
    // Fields of this CubeController class (set their values in Inspector)
    public GameObject cubePrefab;
    private int timer;
    public int timeInterval;                        // Value: 150
    public List<GameObject> spawnedCubeList;

    #region Old Variables (for students to see)
    /*
    //                                      Values
    // Editable in Inspector
    public int number;                      // 100

    // Non-editable in Inspector
    private string word;                    // null

    // Editable in Inspector
    [SerializeField] 
    private bool something;                 // true
    */
    #endregion


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        #region Old variables values (for students to see)
        /*
        number = 5;
        something = false;
        word = "birthday";

        Debug.Log(number);
        Debug.Log(something);
        Debug.Log(word);
        */
        #endregion

        #region Modifying the transform position (for students to see)
        /*
        // Change X position to 100
        //transform.position.x = 100; NOOOOOOOOOOOOOOOOOOOOOOOO
        // MOVING THE EMPTY CUBE CONTROL GO TO (100, 0, 0) IN THE SCENE
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
        */
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        // Timing mechanism
        timer++;

        // Once I've surpassed the interval, reset the timer and spawn an object
        if(timer > timeInterval)
        {
            timer = 0;

            // Instantiation of a prefab
            GameObject spawnedCubeRef = Instantiate(
                cubePrefab,                                     // Which prefab to use?
                new Vector3(0, 10, 0),                          // Position in the scene
                Quaternion.identity);                           // Rotation (0, 0, 0)

            // Keep track of all spawned cubes in this handy dandy list
            spawnedCubeList.Add(spawnedCubeRef);
        }
    }
}
