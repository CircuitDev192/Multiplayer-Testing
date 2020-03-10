using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetupScript : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    private Camera sceneCamera;

    private void Start()
    {
        sceneCamera = Camera.main;

        if (!isLocalPlayer)
        {
            foreach (Behaviour behaviour in componentsToDisable)
            {
                behaviour.enabled = false;
            }
        }
        else
        {
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
