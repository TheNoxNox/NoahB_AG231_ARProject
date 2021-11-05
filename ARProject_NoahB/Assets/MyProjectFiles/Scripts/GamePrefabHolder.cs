using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GamePrefabHolder : MonoBehaviour
{
    public static GamePrefabHolder Main;

    public GameObject gamePrefab;

    public GameObject theGame;

    public ARSession session;

    public ARPlaneManager planeMan;

    private void Awake()
    {
        if (!Main)
        {
            Main = this;
            session.enabled = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ToggleSession(bool toggle)
    {
        session.enabled = toggle;
    }
}
