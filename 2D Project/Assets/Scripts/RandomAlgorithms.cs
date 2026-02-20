using UnityEngine;

// Custom enum used for controlling the program's "mode"
public enum RandomAlgorithm
{
    Uniform,
    Nonuniform,
    Gaussian,
    Perlin
}

public class RandomAlgorithms : MonoBehaviour
{
    //Prefab that will be instantiated via code
    public GameObject squarePrefab;

    /// <summary>
    /// Which "mode" the program is in. This is controlled in the Inspector.
    /// </summary>
    public RandomAlgorithm currentAlgorithm;
    
    void Start()
    {
        if(currentAlgorithm == RandomAlgorithm.Uniform)
            UniformRandomInstantiation();
        else if(currentAlgorithm == RandomAlgorithm.Nonuniform)
            NonUniformRandomInstantiation();
    }

    void Update()
    {
        
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
}
