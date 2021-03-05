using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private ITouchInput TouchInput;
    private Touch touch;
    private Rigidbody _rb;
    private bool _hasThrown;

    void Start()
    {
        TouchInput = GetComponent<ITouchInput>();
        if (TouchInput == null)
        {
            Debug.LogError("TouchInput is null");
        }

        _rb = GetComponent<Rigidbody>();
        if (_rb != null)
        {
            _rb.isKinematic = true;
            _hasThrown = false;
            _rb.velocity = Vector3.zero;
        }
    }

    void Update()
    {
        _rb.velocity = new Vector3(Mathf.Clamp(_rb.velocity.x, -25f, 25f), Mathf.Clamp(_rb.velocity.y, -25f, 25f), 0);

        if (!_hasThrown && Input.touchCount > 0)
        {   
                touch = Input.GetTouch(0);
                _hasThrown = TouchInput.GetTouchInput(touch,_hasThrown);
        }
    }
}
