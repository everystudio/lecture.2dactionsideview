using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviour
{
    public void OnGoal()
    {
        Debug.Log("ゴールしました");
        PlayerController playerController = GameObject.FindObjectOfType<PlayerController>();
        playerController.OnGoal();
    }
    public void OnDeadPlayer()
    {
        Debug.Log("プレイヤーがやられました");
        PlayerController playerController = GameObject.FindObjectOfType<PlayerController>();
        playerController.OnDead();

        StartCoroutine(Restart());
    }
    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
