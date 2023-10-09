using UnityEngine;

using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class GrassBladeGenerator : MonoBehaviour
{
    public int tileSize = 500;
    public int halfTileSize;
    public GameObject grassTexture;
    
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
                    Vector3 position = new Vector3(x + transform.position.x - halfTileSize, 1f, y + transform.position.z - halfTileSize);
                    //Debug.Log("Colocando grass em (" + x + "," + y + ")");
                    Instantiate(grassTexture, position, Quaternion.Euler(41.452f, -0f, 0f));
                }
                
            }
        }
    }
}
    
