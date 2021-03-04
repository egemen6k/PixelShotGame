using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private ITouchInput TouchInput;
    private Touch touch;
    private Rigidbody _rb;
    public bool _hasThrown = false;

    // Start is called before the first frame update
    void Start()
    {
        TouchInput = GetComponent<ITouchInput>();
        if (TouchInput == null)
        {
            Debug.LogError("TouchInput is null");
        }

        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
        {
            Debug.LogError("RB is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector3(Mathf.Clamp(_rb.velocity.x, -25f, 25f), Mathf.Clamp(_rb.velocity.y, -25f, 25f), 0);  
        
        if (!_hasThrown)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                _hasThrown = TouchInput.GetTouchInput(touch,_hasThrown);
            }
        }
    }
}
