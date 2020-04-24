﻿using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using EventStruct;
using UnityEngine;
/// <summary>
/// Link one AudioClip with as many enums as u want.
/// </summary>


[CreateAssetMenu(menuName = "ScriptableObjects/Sounds/Sound Links", fileName = "new SoundLinks")]
public class SoundLinksScriptableObjects : ScriptableObject
{
    [Header("Clip")] 
    public AudioClip Clip;
    
    [Header("Types to link the sound too")]
    public List<WeaponLinks> Weapons;

    public List<BulletLinks> Bullets;
    
    [Serializable]
    public struct WeaponLinks
    {
        public WeaponType WeaponType;
        public WeaponInfo.WeaponEventType EventType;
    }
    [Serializable]
    public struct BulletLinks
    {
        public ProjectileType BulletType;
        public BulletInfo.BulletCollisionType CollisionType;
    }
}