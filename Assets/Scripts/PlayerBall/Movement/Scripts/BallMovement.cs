using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private bool _hasThrown;

    void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb != null)
        {
            gameObject.transform.position = new Vector3(0, -4, 0);
            _rb.isKinematic = true;
            _hasThrown = false;
        }
    }

    void Update()
    {
        _rb.velocity = new Vector3(Mathf.Clamp(_rb.velocity.x, -25f, 25f), Mathf.Clamp(_rb.velocity.y, -25f, 25f), 0);

        if (!_hasThrown && Input.touchCount > 0)
        {   
                Touch touch = Input.GetTouch(0);

                ITouchInput TouchInput = GetComponent<ITouchInput>();
                if (TouchInput != null)
                {
                    _hasThrown = TouchInput.GetTouchInput(touch, _hasThrown);
                }
        }
    }
}
