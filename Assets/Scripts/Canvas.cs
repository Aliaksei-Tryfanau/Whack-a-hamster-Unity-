using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    void Start()
    {

    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}