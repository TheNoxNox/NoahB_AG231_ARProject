using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameManager.Main.TouchRaycast(ray);
        }
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            GameManager.Main.TouchRaycast(ray);
        }
    }
}
