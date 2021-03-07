﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisual
{
    void OnClicked();
    void OnDrag(Touch touch);
    void OnRelease();
}
