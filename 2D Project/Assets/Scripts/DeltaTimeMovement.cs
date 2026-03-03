using UnityEngine;

/// <summary>
/// Demonstrate how to move a GameObject 2 different ways:
/// 1. Using direction, velocity and position without the physics system.
/// 2. Adding a force to a Rigidbody.
/// </summary>
public class DeltaTimeMovement : MonoBehaviour
{
    // --------------------------------------------------------------------
    // Fields for movement control without the physics system
    // --------------------------------------------------------------------
    public Vector3 velocity;
    public Vector3 direction;
    public float speed;

    // Timer for debugging and confirmation of framerate-independent movement
    public float timer;
    public float timerInterval;

    // --------------------------------------------------------------------
    // Fields for physics system movement
    // --------------------------------------------------------------------
    public Rigidbody2D body;
    public Vector2 jumpForce;
    public float jumpMagnitude;


    void Start()
    {
        // --------------------------------------------------------------------
        // DeltaTimeMovement field assignments
        // Can set the direction so it's always to the right
        // This is used for the DeltaTimeMovement part and NOT for jumping
        // --------------------------------------------------------------------
        direction = new Vector3(1, 0, 0);           // Rightward movement
        //direction = Vector3.right;                // Shortcut

        // --------------------------------------------------------------------
        // Jump field assignments
        // --------------------------------------------------------------------
        // Find the Rigidbody component to add a force to
        body = GetComponent<Rigidbody2D>();         // Finds the Rigidbody on this GO

        // --------------------------------------------------------------------
        // Jump once at the beginning of gameplay
        // --------------------------------------------------------------------
        Jump();
    }

    void Update()
    {
        // --------------------------------------------------------------------
        // Although the Update method runs once per frame, we coded the method
        //    below to use delta time for framerate independent animation. 
        // --------------------------------------------------------------------
        //VectorMovementDeltaTime();
    }

    void FixedUpdate()
    {
        // --------------------------------------------------------------------
        // If something needs to occur every frame with the physics system, use
        //   FixedUpdate instead of Update. The framerate is fixed and the physics
        //   movement will be physically accurate.
        // --------------------------------------------------------------------
        //Jump();
    }

    /// <summary>
    /// Applies a force to a GameObject to make it "jump" upward
    /// </summary>
    public void Jump()
    {
        // --------------------------------------------------------------------
        // YES WE WANT A RIGIDBODY FOR THIS!!!!!
        // Set the magnitude of the force vector
        // Higher magnitude ==> higher force applied to the rigidbody
        // --------------------------------------------------------------------
        jumpForce *= jumpMagnitude;
        body.AddForce(jumpForce);
    }

    /// <summary>
    /// Animates a GameObject toward a set direction at a set speed
    /// </summary>
    public void VectorMovementDeltaTime()
    {
        // --------------------------------------------------------------------
        // DON'T WANT A RIGIDBODY FOR THIS!!!!!
        // Every frame, move the prefab by a velocity (direction * speed)
        // Velocity = Direction normalized * speed
        // Position = position + velocity
        // --------------------------------------------------------------------
        velocity = direction.normalized * speed * Time.deltaTime;
        transform.position += velocity;

        // --------------------------------------------------------------------
        // Timer for debugging/confirm accuracy of movement speed
        // This timer is used to print a Console statement every second of how
        //   far the object has moved, to confirm it's moving X units per second
        //   instead of X units per frame.
        // --------------------------------------------------------------------
        timer += Time.deltaTime;
        if (timer > timerInterval)
        {
            Debug.Log(transform.position.magnitude);
            timer -= timerInterval;
        }
    }
}
