using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comms_anims : MonoBehaviour
{
    [SerializeField] Animator _commsAnimator;

    private void Start()
    {
        _commsAnimator = GetComponent<Animator>();
        _commsAnimator.SetBool("Fade_In", false);
        _commsAnimator.SetBool("Static_True", false);
        _commsAnimator.SetBool("Mon_True", false);
        _commsAnimator.SetBool("Tom_True", false);
        _commsAnimator.SetBool("Fade_Out", false);
    }
    public void CommsFadeInAnim()
    {
        _commsAnimator.SetBool("Fade_In", true);
    }
    public void CommsStaticAnim()
    {
        _commsAnimator.SetBool("Static_True", true);
    }
    public void CommsMonAnim()
    {
        _commsAnimator.SetBool("Mon_True", true);
        _commsAnimator.SetBool("Static_True", false);
    }
    public void CommsTomAnim()
    {
        _commsAnimator.SetBool("Tom_True", true);
    }
    public void CommsFadeOut()
    {
        _commsAnimator.SetBool("Fade_Out", true);
    }
    public void ClearAllBool()
    {
        _commsAnimator.SetBool("Fade_In", false);
        _commsAnimator.SetBool("Static_True", false);
        _commsAnimator.SetBool("Mon_True", false);
        _commsAnimator.SetBool("Tom_True", false);
        _commsAnimator.SetBool("Fade_Out", false);
    }
}
