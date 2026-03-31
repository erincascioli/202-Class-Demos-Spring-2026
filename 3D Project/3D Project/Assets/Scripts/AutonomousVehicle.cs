using UnityEngine;


/// <summary>
/// Class represents a vehicle (object that locomotes) that is controlled by the user
/// via the Enter key. Moves in one direction. Accelerate with enter press,
/// decelerate upon enter release.
/// Placed on the VehicleParent GO in the scene.
/// </summary>
public class AutonomousVehicle : MonoBehaviour
{
    // Handling smallest and largest speeds
    public float maxSpeed;
    public float minSpeed;

    // Rates of acceleration and deceleration
    public float accelerationRate;
    public float decelerationRate;

    // Part of “movement formula”
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 acceleration;


    void Start()
    {
        
    }

    void Update()
    {
        Drive();
    }

    public void Drive()
    {
        // Copy the vehicle’s current position
        Vector3 vehiclePosition = transform.position;

        // Set direction along the object’s forward transform
        direction = transform.forward;

        // Derive a velocity vector scaled to full speed NOPE!
        //velocity = direction * maxSpeed;

        // Reset acceleration, which clears momentum
        acceleration = Vector3.zero;

        // Calculate the current acceleration for this frame
        acceleration = direction * accelerationRate;

        // Add acceleration to velocity
        velocity += acceleration * Time.deltaTime;

        // Scale by delta time for per-second movement
        //velocity *= Time.deltaTime;

        // Clamp so it never exceeds the maximum speed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Calculate this frame’s new position
        vehiclePosition += velocity;

        // And transport the GameObject to that position
        transform.position = vehiclePosition;
    }

    void OnDrawGizmos()
    {
        // --------------------------------------------------------------------
        // TEST GIZMO
        // --------------------------------------------------------------------
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, 3);

        // --------------------------------------------------------------------
        // DRAW ORIENTATION GIZMO LINES (FORWARD, RIGHT, UP)
        // --------------------------------------------------------------------
        // Draw the vehicle's direction (along its forward transform)
        Gizmos.color = Color.blue;
        Vector3 lineEndpoint = transform.position + (transform.forward * 3);
        Gizmos.DrawLine(transform.position, lineEndpoint);

        // YOU DO:
        // Draw a line from center "up" (any color)
        Gizmos.color = Color.green;
        lineEndpoint = transform.position + (transform.up * 3);
        Gizmos.DrawLine(transform.position, lineEndpoint);

        // Draw a line from center "right" (any color)
        Gizmos.color = Color.red;
        lineEndpoint = transform.position + (transform.right * 3);
        Gizmos.DrawLine(transform.position, lineEndpoint);
    }
}
