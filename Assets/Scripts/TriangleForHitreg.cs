using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TriangleMesh : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // Definindo os vértices
        Vector3[] vertices = {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(0.5f, 1, 0)
        };

        // Definindo os triângulos
        int[] triangles = {
            0, 1, 2
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Opcional: Definir normais, se necessário
        Vector3[] normals = {
            Vector3.up,
            Vector3.up,
            Vector3.up
        };

        mesh.normals = normals;
    }
}
