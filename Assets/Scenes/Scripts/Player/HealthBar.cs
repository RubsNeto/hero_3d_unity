using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Player_movement player;
    public Text healthText;
    private bool vivo = true; 

    void Start()
    {
        // Localiza o componente Player_movement na cena
        player = FindObjectOfType<Player_movement>();
    }

    void Update()
    {
        if(vivo) // Atualiza o texto da vida do jogador na HUD
        {
            healthText.text = "Vida: " + player.health_player.ToString();
        }
        else
        {
            healthText.text = "Vida: 0";
        }
        
        if(player.health_player <= 0) // Verifica se o jogador morreu
        {
            vivo = false;
        }
    }
}
