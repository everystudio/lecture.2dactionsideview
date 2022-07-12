using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHolder : MonoBehaviour
{
    public Image[] m_imageArr;
    public int m_iHealth;

    public void SetHealth(int _iHealth)
    {
        m_iHealth = _iHealth;
        for (int i = 0; i < m_imageArr.Length; i++)
        {
            m_imageArr[i].enabled = i < m_iHealth;
        }
    }

}
