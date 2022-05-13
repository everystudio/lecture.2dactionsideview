using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private float distance = 5f;
    private float speed = 1f;

    void Start()
    {
        float duration = distance / speed;
        transform.DOMoveX(distance, duration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetRelative(true)
            .SetEase(Ease.InOutQuad);
    }

}
