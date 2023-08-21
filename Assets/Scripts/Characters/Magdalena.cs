using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magdalena : MonoBehaviour
{
    private Animator animator;
    private Animation anim;
    private int animNum;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ANIMATION
        if (animNum == 0)
        {
            //anim.PlayQueued("MagdaIdle", QueueMode.CompleteOthers);
            animNum = Random.Range(0,4);
            animator.SetInteger("Num", animNum);
        } 
        else if (animNum == 1)
        {
            //anim.PlayQueued("MagdaIdle1", QueueMode.CompleteOthers);
            animNum = Random.Range(0,4);
            animator.SetInteger("Num", animNum);
        } 
        else if (animNum == 2)
        {
            //anim.PlayQueued("MagdaIdle2", QueueMode.CompleteOthers);
            animNum = Random.Range(0,4);
            animator.SetInteger("Num", animNum);
        }
        else if (animNum == 3)
        {
            //anim.PlayQueued("MagdaIdle3", QueueMode.CompleteOthers);
            animNum = Random.Range(0,4);
            animator.SetInteger("Num", animNum);
        }
    }
}
