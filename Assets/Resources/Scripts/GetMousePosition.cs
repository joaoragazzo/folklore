using UnityEngine;

public class GetMousePosition : MonoBehaviour
{
    private Camera cam;
    private PlayerInteraction playerInteraction;

    void Start()
    {
        playerInteraction = new PlayerInteraction();
        playerInteraction.Initialize();
        cam = Camera.main; // Atribui a câmera principal à variável
    }

    void Update()
    {
        // Converte a posição do mouse na tela para um Ray
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit; // Informações sobre o que foi atingido pelo Raycast

        Physics.Raycast(ray, out hit);
        
        playerInteraction.PlayerStats.Mouse3DPosition = hit.point;

        // if (Physics.Raycast(ray, out hit))
        // {
        //     Debug.Log("Objeto atingido: " + hit.collider.gameObject.name);
        //     Debug.Log("Ponto atingido: " + hit.point); // A posição 3D que o ray atingiu
        // }

        // Opcional: desenha o ray na cena para propósitos de debug. Isso só é visível no modo Scene view
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
    }
}
