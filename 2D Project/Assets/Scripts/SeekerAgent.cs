using UnityEngine;

// Child of Agent, will seek a target in the scene.
public class SeekerAgent : Agent
{
    // Child-specific data
    public Vector3 targetLocation;

    // NO START OR UPDATE HERE IN THE CHILD

    public override Vector3 CalcSteeringForce()
    {
        // Call every steering force that this child wants to implement
        return Seek(targetLocation);
    }
}
