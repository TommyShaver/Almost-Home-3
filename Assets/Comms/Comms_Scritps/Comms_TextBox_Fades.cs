using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comms_TextBox_Fades : MonoBehaviour
{
    public Animator _animator;

    public void FadeInTextBox()
    {
        _animator.SetBool("Text_FadeOut", false);
        _animator.SetBool("Text_FadeIn", true);
    }

    public void FadeOutTextBox()
    { 
        _animator.SetBool("Text_FadeOut", true);
        _animator.SetBool("Text_FadeIn", false);
    }

    public void ClearAllBool()
    {
        _animator.SetBool("Text_FadeOut", false);
        _animator.SetBool("Text_FadeIn", false);
    }

}
