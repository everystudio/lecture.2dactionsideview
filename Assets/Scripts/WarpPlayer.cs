using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPlayer : MonoBehaviour
{
    [SerializeField] private float popSpeed = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Warp"))
        {
            if (collision.gameObject.TryGetComponent<WarpArea>(out WarpArea warpArea))
            {
                Vector3 targetPosition = warpArea.GetTargetPosition();
                transform.position = targetPosition;
                if (transform.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody))
                {
                    rigidbody.velocity = Vector2.up * popSpeed;
                }

                warpArea.VanishPlayer(gameObject, 0.5f);
            }
        }
    }

}
