using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Obiekt, za którym kamera będzie podążać (np. gracz)
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Początkowa pozycja kamery względem celu
    public float smoothSpeed = 0.125f; // Szybkość wygładzania ruchu kamery

    public float rotationSpeed = 100f; // Szybkość obrotu kamery

    void LateUpdate()
    {
        // Wygładzenie ruchu kamery
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Obrót kamery na podstawie wejścia od gracza
        float horizontalInput = Input.GetAxis("Mouse X");
        offset = Quaternion.AngleAxis(horizontalInput * rotationSpeed * Time.deltaTime, Vector3.up) * offset;

        // Ustawienie kamery w kierunku celu
        transform.LookAt(target);
    }
}