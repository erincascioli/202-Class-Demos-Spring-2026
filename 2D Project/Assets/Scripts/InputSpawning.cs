using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class InputSpawning : MonoBehaviour
{
    // Fields of the script

    /// <summary>
    /// Reference to the prefab that will be instantiated
    /// </summary>
    public GameObject prefab;

    /// <summary>
    /// List that will hold references to all spawned items
    /// </summary>
    public List<GameObject> spawnedItems;


    void Start()
    {
        // Add a new prefab instance to the list at the start of the script
        spawnedItems.Add(
            Instantiate(
                prefab, 
                Vector3.zero, 
                Quaternion.identity));
    }

    void Update()
    {
        // This code uses the old Legacy Input Manager system:
        //// A --> Add a new instance to the list at a random location
        //if( Input.GetKeyDown(KeyCode.A) )
        //{
        //    Vector3 randomLocation = new Vector3(
        //        Random.Range(-10f, 10f),
        //        Random.Range(-5f, 5f),
        //        0);

        //    spawnedItems.Add(
        //    Instantiate(
        //        prefab,
        //        randomLocation,
        //        Quaternion.identity));
        //}
    }

    // Write a method that's called by the InputPlayer component
    //   that's attached to the Spawning GO in the scene
    public void OnSpawn(InputAction.CallbackContext context)
    {
        // Has the action completed?
        if (context.started)
        {
            // Code that runs when the A key is pressed
            Vector3 randomLocation = new Vector3(
                Random.Range(-10f, 10f),
                Random.Range(-5f, 5f),
                0);

            spawnedItems.Add(
                Instantiate(
                    prefab,
                    randomLocation,
                    Quaternion.identity));
        }
    }
}
