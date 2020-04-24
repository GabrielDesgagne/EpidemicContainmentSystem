﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;
public class UiAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public TextMeshProUGUI NbBulletInMagazine;
    public TextMeshProUGUI NbBulletOnPlayer;
    public TextMeshProUGUI GunName;
    public TextMeshProUGUI Life;
    public Image PistolImage;
    public Image ShotgunImage;

    public Image FadeImage;
    public float FadeSpeed;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        GameVariables.UI.NbBulletInMagazine = NbBulletInMagazine;
        GameVariables.UI.NbBulletOnPlayer = NbBulletOnPlayer;
        GameVariables.UI.GunName = GunName;
        GameVariables.UI.Life = Life;
        GameVariables.UI.PistolImage = PistolImage;
        GameVariables.UI.ShotgunImage = ShotgunImage;

        GameVariables.UI.FadeObject = new FadeObject
        {
            Image = FadeImage,
            Speed = FadeSpeed
        };
    }
}