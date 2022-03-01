using UnityEngine;

public class DeadArea : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.CompareTag("Player"))
        {
            GameMain gameMain = GameObject.FindObjectOfType<GameMain>();
            gameMain.OnDeadPlayer();
        }
    }
}
