using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkFollow : MonoBehaviour
{
    public void FollowLink(string link)
    {
        Application.OpenURL(link);
    }
}
