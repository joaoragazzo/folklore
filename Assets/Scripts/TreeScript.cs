using UnityEngine;

using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class GrassBladeGenerator : MonoBehaviour
{
    public int tileSize = 1000;
    public int halfTileSize;
    public GameObject treeOne;
    public GameObject treeTwo;
    public GameObject treeThree;
    public GameObject treeFour;

    public GameObject selectTree()
    {
        int randomNumber = Random.Range(0, 3);

        if (randomNumber == 0)
            return treeOne;
        else if (randomNumber == 1)
            return treeTwo;
        else if (randomNumber == 2)
            return treeThree;
        else
            return treeFour;
    }
    
    private void Start()
    {
        halfTileSize = tileSize / 2;
        float[,] noiseMap = new float[tileSize, tileSize];
        (float xOffset, float yOffset) = (Random.Range(-10000f, 10000f), Random.Range(-1000f, 1000f));
        
        for (int y = 0; y < tileSize; y++)
        {
            for (int x = 0; x < tileSize; x++)
            {
                float noiseValue = Mathf.PerlinNoise(x * 0.3f + xOffset, y * 0.3f + yOffset);
                //Debug.Log("(" + x + "," + y + ") | " + noiseValue);
                noiseMap[x, y] = noiseValue;
                
                if (noiseMap[x, y] > 0.8f)
                {
                    Vector3 position = new Vector3(transform.position.x + x, 1f, transform.position.z + y);
                    //Debug.Log("Colocando grass em (" + x + "," + y + ")");

                    GameObject tree = selectTree();
                    
                    Instantiate(tree, position, Quaternion.Euler(-90, 0, 0));
                }
                
            }
        }
    }
}
    
