using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovePlatform : MonoBehaviour
{
    public float move = 5f;
    public float speed = 1f;

    private List<Transform> ridingPlayers = new List<Transform>();
    void Start()
    {
        float dulation = move / speed;
        transform.DOMoveX(move, dulation)
            .SetRelative(true)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.gameObject.CompareTag("Player"))
        {
            bool bIsUp = false;
            foreach (ContactPoint2D point in _collision.contacts)
            {
                if (transform.position.y < point.point.y)
                {
                    bIsUp = true;
                }
            }
            if (bIsUp)
            {
                _collision.transform.SetParent(this.transform);
                ridingPlayers.Add(_collision.transform);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D _collision)
    {
        List<Transform> removePlayers = new List<Transform>();
        foreach (Transform player in ridingPlayers)
        {
            if (player.GetComponent<PlayerController>().IsGround == false)
            {
                removePlayers.Add(player);
            }
        }

        foreach (Transform removePlayer in removePlayers)
        {
            RemoveRigindPlayer(removePlayer);
        }
    }

    private void OnCollisionExit2D(Collision2D _collision)
    {
        if (ridingPlayers.Contains(_collision.transform))
        {
            RemoveRigindPlayer(_collision.transform);
        }
    }

    private void RemoveRigindPlayer(Transform _playerTransform)
    {
        ridingPlayers.Remove(_playerTransform);
        _playerTransform.SetParent(null);

    }
}
