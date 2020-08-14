using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visor : DefaultTrackableEventHandler
{
    public Material material;
    public GameObject conceptpanel;
    public GameObject timerPanel;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        Skybox skybox = FindObjectOfType<Skybox>();
        skybox.material = material;
        Camera cam = skybox.gameObject.GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.Skybox;
        Debug.Log(cam.gameObject.name);
        conceptpanel.SetActive(true);
        timerPanel.SetActive(true);
    }
}
