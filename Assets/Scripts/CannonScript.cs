using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public GameObject spawnPos;
    public GameObject cannon;
    public GameObject projectile;
    float force = 100f;
    bool canShoot = true;
    float shooted;

    public bool IsCannonUsed = false;

    float rotationSpeed = 10f;
    float horizontalInput;
    float verticalInput;

    // Zakres obrotu w pionie (góra, dół)
    float minVerticalAngle = -20f;
    float maxVerticalAngle = 20f;
    void Start()
    {
        
    }

    void Update()
    {
        if (IsCannonUsed)
        {
            Shoot();
            MoveCannon();
        }

    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            GameObject bullet = Instantiate(projectile, spawnPos.transform.position, cannon.transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(cannon.transform.forward * force, ForceMode.Impulse);
            canShoot = false;
            shooted = Time.time;
        }
        if (Time.time > shooted + 3)
            canShoot = true;
    }

    void MoveCannon()
    {
        // Odczytywanie wejść do obracania armaty
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Obracanie na boki (lew - prawo)
        cannon.transform.Rotate(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);


        // Obracanie w pionie (góra - dół)
        float verticalRotation = verticalInput * rotationSpeed * Time.deltaTime;

        // Ograniczenie obrotu w pionie (aby nie obracało się za bardzo w górę lub w dół)
        float currentRotationX = cannon.transform.localEulerAngles.x;
        currentRotationX = (currentRotationX > 180) ? currentRotationX - 360 : currentRotationX;

        float newRotationX = Mathf.Clamp(currentRotationX + verticalRotation, minVerticalAngle, maxVerticalAngle);

        cannon.transform.localRotation = Quaternion.Euler(newRotationX, cannon.transform.localEulerAngles.y, 0);
    }
}
