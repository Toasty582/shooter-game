using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
    public int health;
    public float[] position;
    public int sceneIndex;

    public int strengthLVL;
    public float strengthXP;

    public int dexterityLVL;
    public float dexterityXP;

    public int constitutionLVL;
    public float constitutionXP;

    public int intelligenceLVL;
    public float intelligenceXP;

    public int charismaLVL;
    public float charismaXP;

    public PlayerData(Player player) {
        health = player.health;
        sceneIndex = player.sceneIndex;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        strengthLVL = player.strengthLVL;
        strengthXP = player.strengthXP;
        dexterityLVL = player.dexterityLVL;
        dexterityXP = player.dexterityXP;
        constitutionLVL = player.constitutionLVL;
        constitutionXP = player.constitutionXP;
        intelligenceLVL = player.intelligenceLVL;
        intelligenceXP = player.intelligenceXP;
        charismaLVL = player.charismaLVL;
        charismaXP = player.charismaXP;
    }
}
