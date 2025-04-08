using UnityEngine;
using UnityEngine.AI;

public class KnightNPC : MonoBehaviour
{
    public float areaWidth = 10f; // Szeroko�� kwadratu
    public float areaHeight = 10f; // Wysoko�� kwadratu
    public float attackRange = 3f; // Zasi�g ataku
    public float attackCooldown = 2f; // Czas mi�dzy atakami
    private float attackTimer = 0f;

    public Transform enemyTarget; // Cel wroga, mo�e by� przypisane w inspektorze
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        MoveToRandomPositionInSquare();
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;

        if (enemyTarget != null)
        {
            // Sprawdzanie, czy wr�g jest w zasi�gu
            float distanceToEnemy = Vector3.Distance(transform.position, enemyTarget.position);
            if (distanceToEnemy <= attackRange && attackTimer <= 0f)
            {
                AttackEnemy();
            }
            else if (distanceToEnemy > attackRange)
            {
                // Je�li wr�g jest poza zasi�giem ataku, poruszaj si� do niego
                agent.SetDestination(enemyTarget.position);
            }
        }

        // Losowe poruszanie si� po obszarze kwadratu
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToRandomPositionInSquare();
        }
    }

    private void MoveToRandomPositionInSquare()
    {
        // Generowanie losowej pozycji w obr�bie kwadratu
        float randomX = Random.Range(-areaWidth / 2, areaWidth / 2);
        float randomZ = Random.Range(-areaHeight / 2, areaHeight / 2);
        Vector3 randomPosition = new Vector3(randomX, transform.position.y, randomZ) + transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPosition, out hit, 1f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    private void AttackEnemy()
    {
        animator.SetTrigger("Attack"); // Za��my, �e masz animacj� ataku przypisan� w Animatorze
        attackTimer = attackCooldown;
        // Tutaj mo�esz doda� logik� ataku (np. zadanie obra�e�)
        Debug.Log("Knight is attacking the enemy!");
    }
}
    