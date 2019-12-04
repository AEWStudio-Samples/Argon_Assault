using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXBucket : MonoBehaviour
{
    // con fig vars
    public GameObject deathFX;

    //state vars

    void Awake()
    {
        int numFXBuckets = FindObjectsOfType<FXBucket>().Length;

        if (numFXBuckets > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
