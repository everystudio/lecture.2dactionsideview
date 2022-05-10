using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public GameTimer m_gameTimer;
    public float m_fGameTime;
    public Text m_text;

    private void show(float _fTime)
    {
        m_text.text = _fTime.ToString("000");
    }

    private void Awake()
    {
        show(m_fGameTime);
    }

    private void Update()
    {
        float fTimeLeft = m_fGameTime - m_gameTimer.CurrentTime;
        show(fTimeLeft);

        if (fTimeLeft < 0f)
        {
            GameObject.FindObjectOfType<GameMain>().OnDeadPlayer();
            this.enabled = false;
        }
    }

}
