using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchInput
{
    bool GetTouchInput(Touch touch, bool _hasThrown);
}
