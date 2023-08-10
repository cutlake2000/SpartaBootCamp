using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    public Animator timeTextAnim;

    public void MatchFailed()
    {
        timeTextAnim.SetBool("isFailed", true);
    }

    public void MatchFailedEnd()
    {
        timeTextAnim.SetBool("isFailed", false);
    }
}
