using UnityEngine;

/// <summary>
/// Attached to the triangle sprite
/// Rotates a GO sprite x degrees every frame.
/// </summary>

public class RotateMe : MonoBehaviour
{
    /// <summary>
    /// Change in rotation per frame, in degrees
    /// </summary>
    public float angleDelta; 

    /// <summary>
    /// Cumulative rotation
    /// </summary>
    private float totalAngleRotation;


    void Update()
    {
        // --------------------------------------------------------------------
        // Rotation with Quaternions:
        // The rotation data of a Transform component is a Quaternion.
        // Quaternion.Euler returns a quaternion representing a 3D-rotation: x, y and z.
        // --------------------------------------------------------------------

        // When the A key is pressed
        if (Input.GetKey(KeyCode.A))
        {
            // Increase the angle of rotation by the delta
            totalAngleRotation += angleDelta;

            // Ensure it doesn't exceed 360 degrees
            totalAngleRotation %= 360;
        }

        // You can also do this to keep the degrees between 0 and 360:
        //if(totalAngleRotation >= 360)
        //{
        //    totalAngleRotation = 0;
        //}

        // Set the object's rotation
        Quaternion angle = Quaternion.Euler(0, 0, totalAngleRotation);
        transform.rotation = angle;


        // --------------------------------------------------------------------
        // Screen Space to World Space:
        // The rotation data of a Transform component is a Quaternion.
        // Quaternion.Euler returns a quaternion representing a 3D-rotation: x, y and z.
        // --------------------------------------------------------------------

        // Take a look at the mouse's position every frame
        Vector3 mousePositionInPixels = Input.mousePosition;
        Vector3 mousePositionInWorldSpace = Camera.main.ScreenToWorldPoint(mousePositionInPixels);

        // Since ScreenToWorldPoint returns an X,Y position on the camera's frustum (Z), 
        //   the z value of mousePositionInWorldSpace is -10. 
        // We can zero-it-out so that the mouse position is at the same Z depth as the 
        //   other Game Objects in the scene.
        // This, of course, is dependent on the other GO's having Z coordinates of 0.
        mousePositionInWorldSpace.z = 0;

        // This code is here just so we can see what the screen space (in pixels) and
        //   the resulting world space (in Unity units) is.
        // I'm not "doing anything" else with those 2 positions. 
        Debug.Log("Mouse pos in screen space: " + mousePositionInPixels);
        Debug.Log("Mouse pos in world space: " + mousePositionInWorldSpace);
    }
}
