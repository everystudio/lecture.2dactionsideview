using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    private float m_fAxisHorizontal;
    public float HorizontalSpeed = 3f;

    public float m_fJumpPower = 9.0f;
    public LayerMask m_layerGround;
    private bool m_bJumpRequest;
    private bool m_bIsGround;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Stop()
    {
        Debug.Log("Stop");
        m_rigidbody.velocity = new Vector2(0f, m_rigidbody.velocity.y);
    }

    void Update()
    {
        m_fAxisHorizontal = Input.GetAxisRaw("Horizontal");
        Debug.Log("update");
        if (0f < m_fAxisHorizontal)
        {
            // 右側の入力
            transform.localScale = Vector2.one;
        }
        else if (m_fAxisHorizontal < 0f)
        {
            // 左側の入力
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            // 左右の入力なし
        }

        // ジャンプの入力処理
        if (Input.GetButtonDown("Jump"))
        {
            InputJump();
        }

    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position,
            transform.position + (transform.up * -0.27f));

        Gizmos.DrawWireSphere(
            transform.position + (transform.up * -0.27f),
            0.5f);
    }

    private void FixedUpdate()
    {
        // 接地判定
        m_bIsGround = Physics2D.CircleCast(
            transform.position,
            0.5f,
            transform.up * -1f,
            0.27f,
            m_layerGround);

        m_rigidbody.velocity = new Vector2(
            m_fAxisHorizontal * HorizontalSpeed,
            m_rigidbody.velocity.y);

        if (m_bIsGround && m_bJumpRequest)
        {
            Vector2 jumpPower = new Vector2(0f, m_fJumpPower);
            m_rigidbody.AddForce(jumpPower, ForceMode2D.Impulse);
            m_bJumpRequest = false;
        }
    }

    private void InputJump()
    {
        m_bJumpRequest = true;
    }

    public void OnGoal()
    {
        GetComponent<Animator>().Play("Goal");
        Stop();
    }

    public void OnDead()
    {
        GetComponent<Animator>().Play("Dead");
        GetComponent<Collider2D>().enabled = false; // 2Dの当たり判定
        m_rigidbody.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        Stop();
    }

}
