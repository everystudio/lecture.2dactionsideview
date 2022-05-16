using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovePlatform : MonoBehaviour
{
    public float move = 5f;
    public float speed = 1f;
    void Start()
    {
        float dulation = move / speed;
        transform.DOMoveX(move, dulation)
            .SetRelative(true)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);
    }
}
