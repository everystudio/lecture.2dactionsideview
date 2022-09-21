using UnityEngine;

public class GoalController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if(_collision.CompareTag("Player"))
        {
            GameMain gameMain = GameObject.FindObjectOfType<GameMain>();
            gameMain.OnGoal();
        }
    }
}
