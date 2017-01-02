using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTest : MonoBehaviour
{

    void OnBecameVisible()
    {
        Debug.Log("Became Visible");
    }

    void OnBecameInvisible()
    {
        Debug.Log("Became Invisible");
    }

    private void OnWillRenderObject()
    {
         Debug.Log(Camera.current.name);

    }
}
