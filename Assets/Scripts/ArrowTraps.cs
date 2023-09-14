using UnityEngine;

public class ArrowTraps : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] Arrows;
    private float cooldownTimer;

    private void attack()
    {
        cooldownTimer = 0;

        Arrows[FindArrows()].transform.position = firepoint.position;
        Arrows[FindArrows()].GetComponent<EnemyProjectile>().ActivateProjectile();

    }

    private int FindArrows()
    {
        for (int i = 0; i < Arrows.Length; i++)
        {
            if (!Arrows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= attackCooldown)
        {
            attack();
        }
    }
}
