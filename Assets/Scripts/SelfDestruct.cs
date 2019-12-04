using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // con fig vars
    [SerializeField]
    float delay = 2f;

    void Start()
    {
        Destroy(gameObject, delay);
    }
}
