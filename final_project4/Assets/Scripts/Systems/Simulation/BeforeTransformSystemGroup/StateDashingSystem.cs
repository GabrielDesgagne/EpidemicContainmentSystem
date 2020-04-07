﻿using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

//TODO ADD TO GROUP SYSTEM
//[UpdateInGroup(typeof())]
public class StateDashingSystem : SystemBase
{
    protected override void OnCreate()
    {
        //Debug.Log("Created StateDashingSystem System...");
    }

    protected override void OnUpdate()
    {
        //Debug.Log("Updated StateDashingSystem System...");
        
        //Act on all entities with DashComponent, StateComponent and PhysicsVelocity
        Entities.ForEach((ref StateData state, ref DashComponent dash, ref Rotation rotation, ref PhysicsVelocity velocity) =>
        {
            if (state.Value == StateActions.DASHING)
            {
                //Make sure dash isnt in cooldown
                if (dash.Timer.Available)
                {
                    //Debug.Log("Dashed");
                    dash.Timer.Reset();
                    
                    //Get Forward vector
                    float3 forward = math.forward(rotation.Value);

                    velocity.Linear += forward * dash.Distance;
                }
            }
        }).ScheduleParallel();
    }
}
