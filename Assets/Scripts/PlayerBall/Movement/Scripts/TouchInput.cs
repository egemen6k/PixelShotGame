using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour, ITouchInput
{
    public bool GetTouchInput(Touch touch,bool _hasThrown)
    {
            Vector3 _startPos3D = Vector3.zero;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startPos3D = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                    break;

                case TouchPhase.Ended:
                    Vector3 _endPos3D = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                    Vector3 direction = _startPos3D - _endPos3D;
                    IThrow Throw = GetComponent<IThrow>();
                    if (Throw != null)
                    {
                        Throw.ThrowBall(direction);
                    }
                    _hasThrown = true;
                    break;
            }
        return _hasThrown;
    }
}
