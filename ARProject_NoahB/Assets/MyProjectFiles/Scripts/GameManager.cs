using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    protected float gametime = 0f;

    public Tower theTower;

    public static GameManager Main;

    private void Awake()
    {
        if (Main) { Destroy(gameObject); }
        else { Main = this; }
    }

    private void Update()
    {
        gametime += Time.deltaTime;
    }
}
