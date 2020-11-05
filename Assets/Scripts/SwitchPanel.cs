using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    public void OpenPanel(Animator animator)
    {
        animator.SetBool("isOpen", true);
    }

    public void ClosePanel(Animator animator)
    {
        animator.SetBool("isOpen", false);
    }
}
