using UnityEngine;

using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class TreeProceduralGenerator : MonoBehaviour
{
    public int tileSize = 1000;
    public int halfTileSize;
    public GameObject treeOne;
    public GameObject treeTwo;
    public GameObject treeThree;
    public GameObject treeFour;
    public int noiseMapSize = 750;
    public float exclusionRadius = 40f;
    
    private GameObject RandomTreeSelection()
    {
        int randomNumber = Random.Range(0, 4);

        if (randomNumber == 0)
            return treeOne;
        if (randomNumber == 1)
            return treeTwo;
        if (randomNumber == 2)
            return treeThree;
        return treeFour;
    }

    private GameObject RandomTreeConfiguration(GameObject tree)
    {
        float size = Random.Range(1f, 2f);
        
        tree.transform.localScale = new Vector3(100 * size, 100 * size, 100 * size);
        return tree;
    }
    
    
    
    private void Start()
    {
        halfTileSize = tileSize / 2;
        float[,] noiseMap = new float[noiseMapSize, noiseMapSize];
        (float xOffset, float yOffset) = (Random.Range(-10000f, 10000f), Random.Range(-1000f, 1000f));

        // Fator de escala para projetar noiseMap proporcionalmente ao mapa
        float scale = (float)tileSize / noiseMapSize;

        for (int y = 0; y < noiseMapSize; y++)
        {
            for (int x = 0; x < noiseMapSize; x++)
            {
                float noiseValue = Mathf.PerlinNoise(x * 0.3f + xOffset, y * 0.3f + yOffset);
                noiseMap[x, y] = noiseValue;
                
                if (noiseValue > 0.78f)
                {
                    // Use o fator de escala ao posicionar as árvores
                    Vector3 position = new Vector3(transform.position.x + x * scale, 0.6f, transform.position.z + y * scale);

                    if (Vector3.Distance(position, Vector3.zero) > exclusionRadius)
                    {
                        GameObject tree = RandomTreeConfiguration(RandomTreeSelection());
                        Instantiate(tree, position, Quaternion.Euler(-90, 0, 0));   
                    }
                    
                }
                
            }
        }
    }
}
    
