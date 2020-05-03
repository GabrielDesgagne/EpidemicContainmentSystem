﻿using System;
using Unity.Entities;

[Serializable]
[GenerateAuthoringComponent]
public struct AttackRangeComponent : IComponentData
{
    //Act as the range to attack
    public float Value;

    public bool IsInRange;
}
