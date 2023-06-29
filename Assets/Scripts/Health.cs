using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int hp_current;
    public int hp_max;
    public UnityEvent<int> OnHealthChange = new UnityEvent<int>();
    private void Start()
    {
        OnHealthChange.Invoke(hp_current);
    }

    public void Damage(int _iParam, GameObject targetObject)
    {
        hp_current -= Mathf.Abs(_iParam);
        OnHealthChange.Invoke(hp_current);
        PlayerController player = GetComponent<PlayerController>();
        if (player != null)
        {
            if (hp_current <= 0)
            {
                GameObject.FindObjectOfType<GameMain>().OnDeadPlayer();
            }
            else
            {
                player.OnDamage(targetObject);
            }
        }
    }

}
