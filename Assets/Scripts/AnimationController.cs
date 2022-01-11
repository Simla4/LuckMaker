using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    
    public void Idle()
    {
        animator.SetTrigger("Idle");
    }

    public void Run()
    {
        animator.SetTrigger("Run");
    }

    public void Dance()
    {
        animator.SetTrigger("Dance");
    }

    public void Defeat()
    {
        animator.SetTrigger("Defeat");
    }

    public void Bumped()
    {
        animator.SetTrigger("Bumped");
    }

}
