using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

// Custom enum used for controlling the program's "mode"
public enum RandomAlgorithm
{
    Uniform,
    Nonuniform,
    Gaussian,
    Perlin,
    Erratic
}

public class RandomAlgorithms : MonoBehaviour
{
    //Prefab that will be instantiated via code
    public GameObject squarePrefab;

    public GameObject movingPrefab;

    public float timeStep;              // Difference in sampling interval
    private float accumTime;            // Current sampling time

    /// <summary>
    /// Which "mode" the program is in. This is controlled in the Inspector.
    /// </summary>
    public RandomAlgorithm currentAlgorithm;
    
    void Start()
    {
        if (currentAlgorithm == RandomAlgorithm.Uniform)
            UniformRandomInstantiation();
        else if (currentAlgorithm == RandomAlgorithm.Nonuniform)
            NonUniformRandomInstantiation();
        else if (currentAlgorithm == RandomAlgorithm.Gaussian)
            GaussianInstantiation();
        else if (currentAlgorithm == RandomAlgorithm.Erratic)
            ErraticUniform();
        else if (currentAlgorithm == RandomAlgorithm.Perlin)
            PerlinNoiseMovement();
    }

    void Update()
    {
        if (currentAlgorithm == RandomAlgorithm.Erratic)
            ErraticUniform();
        else if (currentAlgorithm == RandomAlgorithm.Perlin)
            PerlinNoiseMovement();
    }

    /// <summary>
    /// Uses uniform random to instantiate squares at a randomized X and Y position,
    /// where there is an equal probability of any X or Y position being generated.
    /// </summary>
    void UniformRandomInstantiation()
    {
        // For 20x:
        // Generate random X and random Y positions (uniform random)
        // Instantiate the square at that random position
        for(int i = 0; i < 20; i++)
        {
            // Floats are inclusive on the lower and upper bounds.
            float xPosition = Random.Range(-9f, 9f);                    // Any value from -9.0 to 9.0
            float yPosition = Random.Range(-4f, 4f);                    // Any value from -4.0 to 4.0

            // Instantiate the square at that position.
            Instantiate(
                squarePrefab,
                new Vector3(xPosition, yPosition, 0),
                Quaternion.identity);
        }
    }

    /// <summary>
    /// Uses non-uniform random to instantiate squares at determined Y positions
    /// of 0, 1 or 2.
    /// </summary>
    void NonUniformRandomInstantiation()
    {
        // For 20x:
        // Generate random X positions
        // Determine which Y position to use (based on non-uniform random)
        // Instantiate the square at the determined position
        for (int i = 0; i < 20; i++)
        {
            // Random X position for this square
            // Integers are exclusive on the upper bound.
            int xPosition = Random.Range(-9, 10);                       // Any integral value between -9 and 9
            int yPosition = 0;

            // Generate a random probability of 0 - 9 (meaning each digit is approximately
            //   a 10% chance)
            int randomChance = Random.Range(0, 10);                     // 0, 1, 2, 3, 4, 5, 6, 7, 8, or 9. NOT 10!

            // Set the Y position based on a non-uniform distribution
            // 20% chance (chance values 0 or 1)
            if(randomChance < 2)
            {
                yPosition = 0;
            }
            // 30% chance (chance values 2, 3, or 4)
            else if (randomChance < 5)
            {
                yPosition = 1;
            }
            // 50% chance (chance values 5, 6, 7, 8, or 9)
            else
            {
                yPosition = 2;
            }

            // Instantiate the square at that position
            Instantiate(
                squarePrefab,
                new Vector3(xPosition, yPosition, 0),
                Quaternion.identity);
        }
    }

    // Provided by Erin Cascioli for IGME 202
    public float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);
        float gaussValue =
                 Mathf.Sqrt(-2.0f * Mathf.Log(val1)) *
                 Mathf.Sin(2.0f * Mathf.PI * val2);
        return mean + stdDev * gaussValue;
    }

    public void GaussianInstantiation()
    {
        for (int i = 0; i < 1000; i++)
        {
            float xPosition = Gaussian(0, 6);       // 96% -6 to 6, 99% -9 to 9
            float yPosition = Gaussian(0, 3.5f);       

            // Instantiate the square at that position
            Instantiate(
                squarePrefab,
                new Vector3(xPosition, yPosition, 0),
                Quaternion.identity);
        }
    }

    public void ErraticUniform()
    {
        // Uniform random Y position
        float randomYPosition = Random.Range(-5f, 5f);

        // Static X and X position but object will float over time.
        movingPrefab.transform.position = 
            new Vector3(0, randomYPosition, 0);
    }

    public void PerlinNoiseMovement()
    {
        // Have a single square repoisition on the Y axis using Perlin noise values
        // Sample every so often (time step)
        // 1D perlin noise:  X --> 0, Y --> increase by timestep.
        // Instantiate the square at that position

        accumTime += timeStep;

        float perlinValue = Mathf.PerlinNoise(0, accumTime) * 5;
        movingPrefab.transform.position = 
            new Vector3(
                movingPrefab.transform.position.x,                  // Keep X
                perlinValue,                                        // Reassign Y
                movingPrefab.transform.position.z);                 // Keep Z
    }

}
