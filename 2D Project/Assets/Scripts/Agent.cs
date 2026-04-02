using TMPro;
using UnityEngine;

// Placed on an autonomous agent GameObject in the Autonomous Agent Test scene in 2D
public abstract class Agent : MonoBehaviour
{
    // Data needed for an autonomous agent (vehicular movement)
    private Vector3 acceleration;
    private Vector3 velocity;
    private Vector3 position;
    public float maxSpeed;

    // Other data (will complete as we need it)


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // ------------------------------------------------------------------------
    // Code Seek(), Flee(), Arrive() and ALL other steering behaviors here
    // ------------------------------------------------------------------------

    /// <summary>
    /// Calculates the steering force for an agent to seek a target in the scene
    /// </summary>
    /// <param name="targetPosition">Position of the target</param>
    /// <returns>Steering force to seek a position in the scene</returns>
    public Vector3 Seek(Vector3 targetPosition)
    {
        // step 1: Get a vector pointing toward the target's location
        Vector3 desiredVelocity = targetPosition - transform.position;

        // Step 2: Scale it to the max speed
        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        // Step 3: Calculate a steering force
        Vector3 steeringForce = desiredVelocity - velocity;

        // Step 4: Return the force
        return steeringForce;
    }

    /// <summary>
    /// Overload of the Seek method allows a GameObject to be used in place of a
    /// Vector3 position.
    /// </summary>
    /// <param name="target">GameObject in the scene</param>
    /// <returns>Steering force to seek a position in the scene</returns>
    public Vector3 Seek(GameObject target)
    {
        return Seek(target.transform.position);
    }
}
