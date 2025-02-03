using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;

    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        // Debug.Log("Vida Atual: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Debug.Log("O personagem morreu!");
        // Adicionar lógica para reiniciar o jogo ou exibir uma tela de Game Over
    }
}