using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp_current;
    public int hp_max;

    public void Damage(int _iParam)
    {
        hp_current -= Mathf.Abs(_iParam);
        PlayerController player = GetComponent<PlayerController>();
        if (player != null)
        {
            if (hp_current <= 0)
            {
                GameObject.FindObjectOfType<GameMain>().OnDeadPlayer();
            }
            else
            {
                player.OnDamage();
            }
        }
    }

}
