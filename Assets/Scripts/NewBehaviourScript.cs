using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float velX = Input.GetAxisRaw("Horizontal");
        float velZ = Input.GetAxisRaw("Vertical");

        anim.SetFloat("speedX" , velX);
        anim.SetFloat("speedZ" , velZ);

        
    }
}
