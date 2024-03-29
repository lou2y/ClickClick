using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamanager : MonoBehaviour
{
    public static Gamanager Instance;

    private void Awake()
    {
        Instance = this;
    }
}
