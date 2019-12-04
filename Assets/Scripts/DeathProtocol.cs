using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathProtocol : MonoBehaviour
{
    // con fog vars
    [SerializeField]
    bool isPlayer = false;
    [Tooltip("In seconds"), SerializeField]
    float actionDelay = 0f;
    [Tooltip("Add Ons subgroup"), SerializeField]
    GameObject addOns;
    [Tooltip("Death FX"), SerializeField]
    GameObject deathFX;

    // state vars
    SceneLoader sceneLoader;
    FXBucket fxBucket;
    MeshRenderer meshRenderer;
    Collider collIder;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        fxBucket = FindObjectOfType<FXBucket>();
        meshRenderer = GetComponent<MeshRenderer>();
        collIder = GetComponent<Collider>();
        SetDFX();
    }

    private void SetDFX()
    {
        if (deathFX || !fxBucket) return; // return if deathFX is attached or FXBucket can't be found

        deathFX = fxBucket.deathFX;
    }

    private void HandleDeath() // called by string reference
    {
        Instantiate(deathFX, transform.position, transform.rotation, fxBucket.transform);
        if (addOns) addOns.SetActive(false);
        collIder.enabled = false;
        meshRenderer.enabled = false;
        if (isPlayer && sceneLoader) sceneLoader.ReloadOnPlayerDeath(actionDelay);
        else Destroy(gameObject, actionDelay);
    }
}
