using UnityEngine;

/// <summary>
/// Attached to the Interval Changer GO.
/// Change the timer so that cubes are spawned more frequently upon collision with
/// the floor GO.
/// </summary>
public class FloorCollision : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // References are fields of this script
    // These references can be set in the Inspector (as long as they are in the 
    //   scene or hierarchy of your project! If something is generated as the
    //   project runs, it can't be set in the Inspector and must be "found".)
    // ------------------------------------------------------------------------

    /// <summary>
    /// Reference to the floor GameObject in the scene/hierarchy
    /// </summary>
    public GameObject floorGO;

    /// <summary>
    /// Reference to the Cube Control GO in the scene/hierarchy
    /// </summary>
    public GameObject cubeControlGO;

    /// <summary>
    /// Reference to the CubeController script on the Cube Controller GO
    /// </summary>
    public CubeController cubeControllerScript;

    void Start()
    {
        // ------------------------------------------------------------------------
        // References can be set via code, if needed.
        // This is helpful for GameObjects that do NOT exist in the scene upon
        //   start of the game.
        // GameObjects that aren't in the scene/hierarchy cannot be dragged/dropped
        //   in the Inspector and MUST be found with the Find method.
        // ------------------------------------------------------------------------

        floorGO = GameObject.Find("Floor");
        cubeControlGO = GameObject.Find("Cube Control GO");

        // Get the CubeController script (component) on the Cube Control GO
        cubeControllerScript = cubeControlGO.GetComponent<CubeController>();
    }

    void Update()
    {
        
    }


    // ------------------------------------------------------------------------
    // Collisions are detected between 2 GameObjects via code.
    // Collisions can only be detected as long as:
    //  - One of the colliding GameObjects has a Rigidbody component
    //  - Both GameObjects have some type of collider
    //  - Collision detection is done within a collision method
    //    (OnCollisionEnter, OnCollisionExit, OnColllsionStay)
    // Any collision methods do NOT need to be explicitly invoked. They are
    //   automatically called by Unity's engine.
    // ------------------------------------------------------------------------

    /// <summary>
    /// Detects a collision between the GameObject this script is attached to
    /// (Interval Changer) and the floor GameObject
    /// </summary>
    /// <param name="collision">Reference with collision information</param>
    public void OnCollisionEnter(Collision collision)
    {
        // As long as this object collides with the floor:
        if(collision.gameObject == floorGO)
        {
            // Change the interval to 0, so cubes are spawned every. single. frame.
            cubeControllerScript.timeInterval = 0;
        }        
    }
}
