using UnityEngine;

public class GetMousePosition : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main; 
    }

    void Update()
    {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        
        PlayerStatsController.Stats.Mouse3DPosition = hit.point;


    }
}
