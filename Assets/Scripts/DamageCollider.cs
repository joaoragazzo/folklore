using UnityEngine;

public class RotatingCollider : MonoBehaviour
{
    public float rotationSpeed = 120f;
    private bool isRotating = false;
    private float currentAngle = 0f;

    private BoxCollider boxCollider;
    private Quaternion initialRotation;

    private void Start()
    {
        boxCollider = GetComponentInChildren<BoxCollider>();
        initialRotation = boxCollider.transform.localRotation;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isRotating)
        {
            isRotating = true;
        }

        if (isRotating)
        {
            RotateAndCheckDamage();
        }
    }

    private void RotateAndCheckDamage()
    {
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        currentAngle += rotationThisFrame;

        // Rotaciona o GameObject filho com o BoxCollider usando rotação local
        Vector3 localUp = boxCollider.transform.TransformDirection(Vector3.up);
        boxCollider.transform.RotateAround(boxCollider.transform.position, localUp, rotationThisFrame);

        // Verifica colisões com o BoxCollider
        Collider[] hitColliders = Physics.OverlapBox(boxCollider.transform.position, boxCollider.size / 2, boxCollider.transform.rotation);
        foreach (var hitCollider in hitColliders)
        {
            IDamageble damageableEntity = hitCollider.GetComponent<IDamageble>();
            if (damageableEntity != null)
            {
                damageableEntity.TakeDamage(1);
            }
        }

        // Se a rotação alcançou ou ultrapassou 120 graus, pare de rotacionar e redefina a rotação local
        if (currentAngle >= 120f)
        {
            isRotating = false;
            currentAngle = 0f;
            boxCollider.transform.localRotation = initialRotation;
        }
    }
}