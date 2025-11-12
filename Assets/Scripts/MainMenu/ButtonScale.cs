using System;
using UnityEngine;

public class ButtonScale : MonoBehaviour
{
    
    private Vector3 initalScale;

    private bool scale;
    
    void Start()
    {
        initalScale = transform.localScale;   
    }

    private void Update()
    {
        if (scale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, initalScale * 1.2f, 10f * Time.deltaTime);

        } else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, initalScale, 10f *Time.deltaTime); 

        }
    }


    public void ScaleButton(bool value)
    {
        if (value)
        {
            scale = true;
        } else
        {
            scale = false;
        }
    }
}
