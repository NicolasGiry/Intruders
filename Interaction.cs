using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public void HoverEnter(Animator animator)
    {
        animator.SetBool("Enter", true);
    }

    public void HoverExit(Animator animator)
    {
        animator.SetBool("Enter", false);
    }

}
