using System;

using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    
    private float heightToCheck = float.MaxValue; 
    private float radiusToCheck = 250.0f;

    private float timeSinceLastCall = 0f;
    private float callInterval = 2.5f;

    public GameObject defaultTile;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastCall += Time.deltaTime;
    }

    public void CheckBorders(Vector3 playerPosition)
    {
        RaycastHit hit;
        
        for (float i = 0f; i <= 2 * Mathf.PI; i += 0.90f)
        {
            Vector3 coordinates = new Vector3(
                Mathf.Cos(i) * radiusToCheck + transform.position.x, 
                transform.position.y, 
                Mathf.Sin(i) * radiusToCheck + transform.position.z);
            
            Debug.DrawRay(coordinates, Vector3.down * heightToCheck, Color.red, 2.0f);
            if (!Physics.Raycast(coordinates, Vector3.down, out hit, heightToCheck) && timeSinceLastCall >= callInterval)
            {
                GenerateWorld(coordinates);
                timeSinceLastCall = 0f;
            }    
        }
        
    }
    
    int AdjustCoordinate(float coordinate, int gridSize)
    {
        int halfGridSize = gridSize / 2;
        if (coordinate >= 0)
            return ((int)coordinate + halfGridSize) / gridSize * gridSize;
        
        return ((int)Math.Abs(coordinate) + halfGridSize) / gridSize * gridSize * -1;
    }
    
    public void GenerateWorld(Vector3 coordinates)
    {
        RaycastHit hit;

        int gridSize = 1000;
        int x = AdjustCoordinate(coordinates.x, gridSize);
        int z = AdjustCoordinate(coordinates.z, gridSize);

        Vector3 adjustedPosition = new Vector3(x, 0, z);
        
        //Debug.Log("Detectou um não chão em " + coordinates + " => Colocando um chão nas coordenadas (" + x + "," + z + ")");
        
        GameObject tile = Instantiate(defaultTile, adjustedPosition, Quaternion.identity);
        tile.transform.position = adjustedPosition;
        tile.transform.localScale = new Vector3(1, 1, 1);
    
    }
}
