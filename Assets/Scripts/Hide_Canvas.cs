using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide_Canvas : MonoBehaviour
{
    public Canvas canvas;
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }
}