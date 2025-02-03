using UnityEngine;

public class SunDamage : MonoBehaviour
{
    public Transform sun; // Referência ao objeto do sol
    public float damagePerSecond = 0.2f; // Dano recebido por segundo
    public LayerMask obstacleMask; // Máscara para detectar obstáculos (sombra)

    private bool isInSunlight;

    void Update()
    {
        CheckSunExposure();
    }

    void CheckSunExposure()
    {
        // Posição mais alta do player (altura da cabeça)
        Vector3 rayOrigin = transform.position + Vector3.up * 2f;

        // Direção do sol para o personagem
        Vector3 directionToSun = (sun.position - rayOrigin).normalized;

        // Lança um raycast na direção do sol
        int layerMask = obstacleMask & ~(1 << LayerMask.NameToLayer("Player"));


        if (Physics.Raycast(rayOrigin, directionToSun, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            Debug.Log("Raycast atingiu: " + hit.collider.gameObject.name);
            // isInSunlight = false;
        }
        else
        {
            Debug.Log("Sem bloqueio - Personagem exposto ao sol!");
            isInSunlight = true;
            
        }
       // Aplica dano caso esteja no sol
        if (isInSunlight)
        {
            ApplySunDamage();
        }


}


    void ApplySunDamage()
    {
        // Busca o script de vida do personagem
        PlayerHealth playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}
