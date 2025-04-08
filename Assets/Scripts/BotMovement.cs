using UnityEngine;
using UnityEngine.AI;

public class KnightNPC : MonoBehaviour
{
    public float areaWidth = 10f; // Szerokoœæ kwadratu
    public float areaHeight = 10f; // Wysokoœæ kwadratu
    public float attackRange = 3f; // Zasiêg ataku
    public float attackCooldown = 2f; // Czas miêdzy atakami
    private float attackTimer = 0f;

    public Transform enemyTarget; // Cel wroga, mo¿e byæ przypisane w inspektorze
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
            // Sprawdzanie, czy wróg jest w zasiêgu
            float distanceToEnemy = Vector3.Distance(transform.position, enemyTarget.position);
            if (distanceToEnemy <= attackRange && attackTimer <= 0f)
            {
                AttackEnemy();
            }
            else if (distanceToEnemy > attackRange)
            {
                // Jeœli wróg jest poza zasiêgiem ataku, poruszaj siê do niego
                agent.SetDestination(enemyTarget.position);
            }
        }

        // Losowe poruszanie siê po obszarze kwadratu
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToRandomPositionInSquare();
        }
    }

    private void MoveToRandomPositionInSquare()
    {
        // Generowanie losowej pozycji w obrêbie kwadratu
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
        animator.SetTrigger("Attack"); // Za³ó¿my, ¿e masz animacjê ataku przypisan¹ w Animatorze
        attackTimer = attackCooldown;
        // Tutaj mo¿esz dodaæ logikê ataku (np. zadanie obra¿eñ)
        Debug.Log("Knight is attacking the enemy!");
    }
}
    