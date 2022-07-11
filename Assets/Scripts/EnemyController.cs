using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float m_fMoveSpeed = 0.5f;
    public bool m_bIsLeft = true;

    private Rigidbody2D m_rigid2d;
    private float m_fCurrentSpeed;

    void Start()
    {
        m_rigid2d = GetComponent<Rigidbody2D>();
        ChangeDirection(m_bIsLeft);
    }

    private bool CheckChangeSpeed()
    {
        return Mathf.Abs(m_rigid2d.velocity.x) < 0.01f;
    }

    private void ChangeDirection(bool _bIsLeft)
    {
        m_fCurrentSpeed = _bIsLeft ? -1f * m_fMoveSpeed : m_fMoveSpeed;
        m_rigid2d.velocity = new Vector2(m_fCurrentSpeed, m_rigid2d.velocity.y);
    }

    private void FixedUpdate()
    {
        if (CheckChangeSpeed())
        {
            m_bIsLeft = !m_bIsLeft;
            ChangeDirection(m_bIsLeft);
        }
        m_rigid2d.velocity = new Vector2(m_fCurrentSpeed, m_rigid2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.CompareTag("Dead"))
        {
            Destroy(gameObject);
        }
        else if (_collision.gameObject.CompareTag("Player"))
        {
            _collision.gameObject.GetComponent<Health>().Damage(1);
        }
    }

}
