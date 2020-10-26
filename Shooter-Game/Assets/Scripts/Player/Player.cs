using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI healthText;

    public int health = 100;
    public int sceneIndex = 0;

    public static Player player;
    private void Awake() {
        if (player != null && player != this) {
            Destroy(this.gameObject);
        } else {
            player = this;
        }
    }

    public void TakeDamage(int amount) {
        health -= amount;
        healthBar.value = health;
        healthText.text = health + " / 100";
    }

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();

        health = data.health;
        sceneIndex = data.sceneIndex;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
    }
}
