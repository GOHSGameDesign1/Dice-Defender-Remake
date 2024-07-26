using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EvenOddEnemy : DiceEnemy, ISpawnable
{
    private bool isEven;
    private TextMeshPro tmp;

    // Start is called before the first frame update
    void OnEnable()
    {
        tmp = transform.GetChild(0).GetComponentInChildren<TextMeshPro>();
    }

    public new void OnSpawn()
    {
        tmp = transform.GetChild(0).GetComponentInChildren<TextMeshPro>();
        isEven = Random.Range(0,2) < 1;
        tmp.text = isEven ? "E" : "O";
    }

    public new void SpawnTooltipVFX()
    {
        GameObject vfx = Instantiate(tooltipVFX, transform.position, Quaternion.identity);
        vfx.transform.GetChild(0).GetComponent<TextMeshPro>().text = (isEven) ? "Needs Even!" : "Needs Odd!";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            HealthManager.GetInstance().DecreaseHealth(1);
            DeSpawn();
        }

        if (!collision.CompareTag("Projectile")) return;
        if (collision.TryGetComponent(out DieNumber projDie))
        {
            int evenOrOddValue = projDie.getDieNumber() % 2;
            if ((evenOrOddValue == 0) == isEven)
            {

                if (collision.TryGetComponent(out ProjectileDeath projectileDeath))
                {
                    projectileDeath.Die();
                }

                Die();
            }
            else
            {
                SpawnTooltipVFX();
            }
        }
    }
}
