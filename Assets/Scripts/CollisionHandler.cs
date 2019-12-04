using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // con fig vars

    // state vars

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void OnParticleCollision(GameObject other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("HandleDeath");
    }
}
