using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Referencias a Módulos")]
    private PlayerMove movementScript;

    [Header("Máquina de Estados")]
    public bool isDead = false;
    public bool isStunned = false; // Crítico en juegos de pelea (hitstun)

    void Start()
    {
        // El cerebro busca y enlaza los otros scripts que viven en la misma cápsula
        movementScript = GetComponent<PlayerMove>();
    }

    // Método público que otro jugador llamará cuando su Hitbox te golpee
    public void RecibirGolpe(int danio)
    {
        if (isDead) return;

        isStunned = true;

        // Bloqueamos el input temporalmente para que no pueda caminar mientras recibe el golpe
        movementScript.enabled = false;

        // TODO: Disparar animación de daño y aplicar retroceso (knockback)
    }
}