using UnityEngine;

public class CombatTrigger : MonoBehaviour
{
    [SerializeField] private GameObject enemyGroup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemyGroup.SetActive(true);
        }
    }
}