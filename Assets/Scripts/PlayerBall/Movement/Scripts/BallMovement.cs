using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    ITouchInput TouchInput;
    IThrow Throw;
    Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        TouchInput = GetComponent<ITouchInput>();
        if (TouchInput == null)
        {
            Debug.LogError("TouchInput is null");
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            TouchInput.GetTouchInput(touch);
        }
    }
}
