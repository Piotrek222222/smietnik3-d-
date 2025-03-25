using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
     public Animator animator;
     public PlayerAttack attacking;
     public bool rotatingleft=false;
     public bool rotatingright=false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        attacking = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) // Zmień na swój klawisz ataku
        {
            if (attacking.isPlaying==false){
                animator.Play("Up", 0, 0f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S)){
           if (attacking.isPlaying==false){
                animator.Play("Down", 0, 0f);
            }
        }
        if (Input.GetKeyUp(KeyCode.W)) // Zmień na swój klawisz ataku
        {
            if (attacking.isPlaying==false){
                animator.Play("Idle", 0, 0f);
            }
        }
        else if (Input.GetKeyUp(KeyCode.S)){
           if (attacking.isPlaying==false){
                animator.Play("Idle", 0, 0f);
            }
        }

        if (rotatingleft==true){
             transform.Rotate(0, -50 * Time.deltaTime, 0);
        }
        if (rotatingright==true){
             transform.Rotate(0, 50 * Time.deltaTime, 0);
        }
         if (Input.GetKeyDown(KeyCode.A)) // Zmień na swój klawisz ataku
        {
            rotatingleft=true;
        }
         if (Input.GetKeyDown(KeyCode.D)) // Zmień na swój klawisz ataku
        {
            rotatingright=true;
        }
         if (Input.GetKeyUp(KeyCode.A)) // Zmień na swój klawisz ataku
        {
            rotatingleft=false;
        }
         if (Input.GetKeyUp(KeyCode.D)) // Zmień na swój klawisz ataku
        {
            rotatingright=false;
        }
        
    }
}
