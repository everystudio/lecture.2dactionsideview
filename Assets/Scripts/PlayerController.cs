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
    public bool IsGround { get { return m_bIsGround; } }

    public float m_fControlLostTime;

    void Start()
    {
        m_fControlLostTime = 0f;
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Stop()
    {
        m_rigidbody.velocity = new Vector2(
            0f,
            m_rigidbody.velocity.y);
    }

    void Update()
    {
        bool bControl = m_fControlLostTime <= 0;

        m_fAxisHorizontal = Input.GetAxisRaw("Horizontal");
        if (bControl == false)
        {
            m_fAxisHorizontal = 0f;
        }


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
        if (Input.GetButtonDown("Jump") && bControl)
        {
            InputJump();
        }

        if (0f < m_fControlLostTime)
        {
            m_fControlLostTime -= Time.deltaTime;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
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
        bool bIsGround = Physics2D.CircleCast(
            transform.position,
            0.5f,
            transform.up * -1f,
            0.27f,
            m_layerGround);

        if (m_bIsGround != bIsGround)
        {
            m_bIsGround = bIsGround;
            if (m_bIsGround)
            {
                Landing();
            }
            else
            {
                // 地面から足が離れた瞬間
            }
        }
        bool bControl = m_fControlLostTime <= 0;
        if (bControl)
        {
            m_rigidbody.velocity = new Vector2(
                m_fAxisHorizontal * HorizontalSpeed,
                m_rigidbody.velocity.y);
        }

        if (m_bIsGround && m_bJumpRequest)
        {
            Vector2 jumpPower = new Vector2(0f, m_fJumpPower);
            m_rigidbody.AddForce(jumpPower, ForceMode2D.Impulse);
            m_bJumpRequest = false;
        }
    }

    private void Landing()
    {
        Debug.Log("着地した瞬間！");
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

    public void OnDamage()
    {
        m_rigidbody.velocity = new Vector2(-3f, 5f);
        m_fControlLostTime = 0.5f;
    }

}
