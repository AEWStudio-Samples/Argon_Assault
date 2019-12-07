using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // con fig vars
    [SerializeField]
    int hitPoints = 100;

    // state vars
    Collider boxClollider;
    CollisionHandler chScript;
    DeathProtocol dpScript;
    HealthContainer hcScript;

    void Start()
    {
        boxClollider = gameObject.AddComponent<BoxCollider>();
        boxClollider.isTrigger = false;
        chScript = gameObject.AddComponent<CollisionHandler>();
        dpScript = gameObject.AddComponent<DeathProtocol>();
        hcScript = gameObject.AddComponent<HealthContainer>();
    }
}
