using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    Image effect;

    [SerializeField]
    Slider healthbar;

    const float maxHealth = 200;
    float currentHealth = maxHealth;
    bool isDead = false;

    internal void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthbar.value = currentHealth / maxHealth;

        DamageEffect();
        if (currentHealth <= 0 && !isDead)
        {
            healthbar.gameObject.SetActive(false);
            Dead();
        }
    }

    private void DamageEffect()
    {
        //Debug.Log(currentHealth);
        StartCoroutine(Damage(0.5f));
    }

    IEnumerator Damage(float des, bool isReturn = true)
    {
        float worktime = 0;
        bool isGrow = true;
        while (true)
        {
            if (worktime >= des)
            {
                if (isReturn)
                {
                    isGrow = false;
                }
                else
                {
                    SceneManager.LoadScene(7);
                }
            }

            if (isGrow)
            {
                worktime += Time.deltaTime;
            }
            else
            {
                worktime -= Time.deltaTime;
            }
            effect.color = Color.Lerp(Color.clear, Color.red, worktime);

            if (worktime <= 0)
            {
                yield break;
            }

            yield return null;
        }
    }

    private void Dead()
    {
        isDead = true;

        StartCoroutine(Damage(0.8f, false));
    }
}
