using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    private float m_fAxisHorizontal;
    public float HorizontalSpeed = 3f;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        m_fAxisHorizontal = Input.GetAxisRaw("Horizontal");

        if( 0f < m_fAxisHorizontal)
        {
            // 右側の入力
            transform.localScale = Vector2.one;
        }
        else if(m_fAxisHorizontal < 0f)
        {
            // 左側の入力
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            // 左右の入力なし
        }
    }

    private void FixedUpdate()
    {
        m_rigidbody.velocity = new Vector2(
            m_fAxisHorizontal * HorizontalSpeed,
            m_rigidbody.velocity.y);
    }
}
