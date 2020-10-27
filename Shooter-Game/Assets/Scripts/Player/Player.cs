using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI healthText;

    public int health = 100;
    public int sceneIndex = 0;

    public int strengthLVL = 1;
    public float strengthXP = 0;

    public int dexterityLVL = 1;
    public float dexterityXP = 0;

    public int constitutionLVL = 1;
    public float constitutionXP = 0;

    public int intelligenceLVL = 1;
    public float intelligenceXP = 0;

    public int charismaLVL = 1;
    public float charismaXP = 0;

    public static Player player;
    private void Awake() {
        if (player != null && player != this) {
            Destroy(this.gameObject);
        } else {
            player = this;
        }
    }

    public void LevelUp() {
        while (strengthXP >= (100 * Mathf.Pow(1.25f, strengthLVL))) {
            strengthXP -= 100 * Mathf.Pow(1.25f, strengthLVL);
            strengthLVL++;
        }

        while (dexterityXP >= (100 * Mathf.Pow(1.25f, dexterityLVL))) {
            dexterityXP -= 100 * Mathf.Pow(1.25f, dexterityLVL);
            dexterityLVL++;
        }

        while (constitutionXP >= (100 * Mathf.Pow(1.25f, constitutionLVL))) {
            constitutionXP -= 100 * Mathf.Pow(1.25f, constitutionLVL);
            constitutionLVL++;
        }

        while (intelligenceXP >= (100 * Mathf.Pow(1.25f, intelligenceLVL))) {
            intelligenceXP -= 100 * Mathf.Pow(1.25f, intelligenceLVL);
            intelligenceLVL++;
        }

        while (charismaXP >= (100 * Mathf.Pow(1.25f, charismaLVL))) {
            charismaXP -= 100 * Mathf.Pow(1.25f, charismaLVL);
            charismaLVL++;
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

        strengthLVL = data.strengthLVL;
        strengthXP = data.strengthXP;
        dexterityLVL = data.dexterityLVL;
        dexterityXP = data.dexterityXP;
        constitutionLVL = data.constitutionLVL;
        constitutionXP = data.constitutionXP;
        intelligenceLVL = data.intelligenceLVL;
        intelligenceXP = data.intelligenceXP;
        charismaLVL = data.charismaLVL;
        charismaXP = data.charismaXP;
    }
}
