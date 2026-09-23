using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private TMP_Text healthText;

    private int currentHealth;

    private void UpdateHealthUI()
    {
        healthText.text =
            "HP : " + currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Dead");

        gameObject.SetActive(false);
    }
}