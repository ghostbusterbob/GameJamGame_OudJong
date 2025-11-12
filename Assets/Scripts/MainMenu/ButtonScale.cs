using System;
using UnityEngine;

public class ButtonScale : MonoBehaviour
{
    
    private Vector3 initalScale;
    private Vector3 initialImageScale;

    private bool scale;

    [SerializeField] private Transform image;
    
    void Start()
    {
        initalScale = transform.localScale;   
        initialImageScale = image.localScale;   
    }

    private void Update()
    {
        if (scale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, initalScale * 1.2f, 10f * Time.deltaTime);
            image.localScale = Vector3.Lerp(image.localScale, initialImageScale * 1.1f, 10f * Time.deltaTime);

        } else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, initalScale, 10f *Time.deltaTime); 
            image.localScale = Vector3.Lerp(image.localScale, initialImageScale, 10f * Time.deltaTime);


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
