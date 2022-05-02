using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMain : MonoBehaviour
{
    public GameObject m_goPanelStart;
    public GameObject m_goPanelGoal;

    private void Start()
    {
        PlayerController playerController = GameObject.FindObjectOfType<PlayerController>();
        playerController.enabled = false;

        m_goPanelStart.SetActive(true);
        m_goPanelGoal.SetActive(false);

    }

    public void OnGameStart()
    {
        m_goPanelStart.SetActive(false);

        PlayerController playerController = GameObject.FindObjectOfType<PlayerController>();
        playerController.enabled = true;
    }

    public void OnGoal()
    {
        Debug.Log("ゴールしました");
        PlayerController playerController = GameObject.FindObjectOfType<PlayerController>();
        playerController.OnGoal();
        playerController.enabled = false;

        m_goPanelGoal.SetActive(true);
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
