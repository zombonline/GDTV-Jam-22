using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCColorPicker : MonoBehaviour
{
    [SerializeField] Color[] hairColors, pupilsColors, faceColors, torsoColors, legsColors, shoeColors;
    [SerializeField] SpriteRenderer hair, pupils, face, torso, legs, shoes;

    private void Awake()
    {
        hair.color = hairColors[Random.Range(0, hairColors.Length)];
        pupils.color = pupilsColors[Random.Range(0, pupilsColors.Length)];
        face.color = faceColors[Random.Range(0, faceColors.Length)];
        torso.color = torsoColors[Random.Range(0, torsoColors.Length)];
        legs.color = legsColors[Random.Range(0, legsColors.Length)];
        shoes.color = shoeColors[Random.Range(0, shoeColors.Length)];
    }
}
