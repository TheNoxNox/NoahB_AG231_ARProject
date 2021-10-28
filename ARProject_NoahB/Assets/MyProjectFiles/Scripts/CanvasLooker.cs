using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class CanvasLooker : MonoBehaviour
{
    public Canvas canvas;

    public TMP_Text scoreCount;

    public TMP_Text timeCounter;

    public Slider healthBar;

    private void Awake()
    {
        canvas.worldCamera = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(transform.position + canvas.worldCamera.transform.rotation * Vector3.forward, canvas.worldCamera.transform.rotation * Vector3.up);
        scoreCount.text = "Points to spend: " + GameManager.Main.points;

        TimeSpan t = TimeSpan.FromSeconds(GameManager.Main.GameTime);

        timeCounter.text = "Current Record: " + t.ToString(@"mm\:ss\:ff");

        healthBar.value = GameManager.Main.theTower.DurabilityPercent * 100;
    }
}
