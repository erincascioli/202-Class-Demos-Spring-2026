using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;                   // Allows use of generic data structures

/// <summary>
/// Attached to the Cube Control GO.
/// Spawns a new cube in the scene every X frames.
/// </summary>
public class CubeController : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Fields of this CubeController class
    // All of the values are set in the Inspector window.
    // ------------------------------------------------------------------------

    /// <summary>
    /// Reference to the prefab I want to spawn multiple instances of.
    /// </summary>
    public GameObject cubePrefab;

    /// <summary>
    /// Timer to control spawn frequency
    /// </summary>
    [SerializeField]
    private int timer;

    /// <summary>
    /// Amount of time passed before the timer resets
    /// </summary>
    public int timeInterval;                        // Value: 150

    /// <summary>
    /// List of references to every spawned cube
    /// </summary>
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
        Vector2 vec1 = new Vector2(2, 1);
        Vector2 vec2 = new Vector2(10, 10);
        Vector2 addedVectors = vec1 + vec2;


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
        
        // Change X position to 100
        //transform.position.x = 100;   // NOOOOOOOOOOOOOOOOOOOOOOOO

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
        
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCubeAtInterval();
        RemoveOldCubes();
    }

    /// <summary>
    /// A new cube is spawned in the scene at the specified timeInterval.
    /// </summary>
    public void SpawnCubeAtInterval()
    {
        // Timing mechanism
        timer++;

        // Once I've surpassed the interval, reset the timer and spawn a cube
        if (timer > timeInterval)
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

    /// <summary>
    /// Removes cubes after a set amount of time.
    /// </summary>
    public void RemoveOldCubes()
    {
        // For loop, iteration through every spawned cube in the list
        for(int i = 0; i < spawnedCubeList.Count; i++)
        {
            // Remove from the scene
            Destroy(spawnedCubeList[i], 2f);

            // Remove from the list ONLY after the object has been destroyed
            if (spawnedCubeList[i] == null)
            {
                spawnedCubeList.Remove(spawnedCubeList[i]);
            }
        }

        // Useful for debugging
        /*
        // For loop, iteration through every spawned cube in the list
        for (int i = 0; i < spawnedCubeList.Count; i++)
        {
            if (spawnedCubeList[i] != null)
            {
                Debug.Log(spawnedCubeList[i].transform.position);

            }
        }
        */
    }
}
