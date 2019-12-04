using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider boxClollider = gameObject.AddComponent<BoxCollider>();
        boxClollider.isTrigger = false;
        CollisionHandler chScript = gameObject.AddComponent<CollisionHandler>();
        DeathProtocol dpScript = gameObject.AddComponent<DeathProtocol>();
    }
}
