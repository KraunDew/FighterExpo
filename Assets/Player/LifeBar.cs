
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private Image fillLifeBar;
    [SerializeField] private PlayerManager player;

    private float maxLife;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("No se ha asignado el PlayerManager a la barra de vida.");
            enabled = false;
            return;
        }

        maxLife = player.life;
        UpdateLifeBar();
    }

    void Update()
    {
        UpdateLifeBar();
    }

    private void UpdateLifeBar()
    {
        if (maxLife <= 0) return;

        fillLifeBar.fillAmount = Mathf.Clamp01(player.life / maxLife);
    }
}
