using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GamePrefabHolder : MonoBehaviour
{
    public static GamePrefabHolder Main;

    public GameObject gamePrefab;

    public ARSession session;

    private void Awake()
    {
        if (!Main)
        {
            Main = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
