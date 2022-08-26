using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class HitStopController : MonoBehaviour
{
    public static HitStopController Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void Stop(float _fTime, bool _bBoss)
    {
        StartCoroutine(HitStopAction(_fTime, _bBoss));
    }

    private IEnumerator HitStopAction(float _fTime, bool _bBoss)
    {
        Time.timeScale = 0f;

        CinemachineImpulseSource impulse = GetComponent<CinemachineImpulseSource>();
        impulse.GenerateImpulse(5f);

        yield return new WaitForSecondsRealtime(_fTime);

        if (_bBoss)
        {
            Time.timeScale = 0.1f;
            yield return new WaitForSecondsRealtime(3f);
        }

        Time.timeScale = 1f;
    }

}
