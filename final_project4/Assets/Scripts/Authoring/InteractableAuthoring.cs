﻿using Enums;
using Unity.Entities;
using UnityEngine;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class InteractableAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public InteractableType Type;
    public InteractableObjectType ObjectType;

    public MapType MapType;

    [Header("Portal")]
    public ushort PortalId;
    public Transform PlayerSpawnPosition;

    [Space(5)]
    public MapType MapTypeLeadingTo;
    public ushort PortalIdLeadingTo;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
#if UNITY_EDITOR
        dstManager.SetName(entity, "Interactable Object");
#endif

        dstManager.AddComponentData(entity, new InteractableComponent
        {
            Type = Type,
            ObjectType = ObjectType
        });

        //Add to Map portals
        if (ObjectType == InteractableObjectType.Portal)
        {
            //Create MapInfo for this MapType
            if (!MapHolder.MapsInfo.ContainsKey(MapType))
                MapHolder.MapsInfo.Add(MapType, new MapInfo());

            //Add info
            MapHolder.MapsInfo[MapType].Portals.Add(PortalId, new MapInfo.Portal
            {
                Id = PortalId,
                Position = PlayerSpawnPosition.position,
                Rotation = PlayerSpawnPosition.rotation,
                MapTypeLeadingTo = MapTypeLeadingTo,
                PortalIdLeadingTo = PortalIdLeadingTo
            });
            
            //Add Component to Entity
            dstManager.AddComponentData(entity, new PortalData
            {
                Value = PortalId
            });
        }
    }
}