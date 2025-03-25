using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public bool isPlaying=false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

void DelayedAction()
{
    isPlaying=false;
}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // Zmień na swój klawisz ataku
        {
            if (isPlaying==false)
                {
                    animator.Play("Attack", 0, 0f);
                    isPlaying=true;
                     Invoke("DelayedAction", 1f);
                }
        }
    }
}

