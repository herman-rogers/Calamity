﻿using UnityEngine;
using System.Collections;
using GameDataEditor;

public class DefenseItem : Item {

    [HideInInspector]
    public GDEDefenseItemData defenseItemData;
    private int cachedCostOfUse;

    private void Start( ) {
        GDEDataManager.Init( "gde_data" );
        gameObject.tag = "Item";
        currentItemState = ItemState.ITEM_AT_SPAWN_POINT;
        cachedCostOfUse = defenseItemData.CostOfUse;
        MoveItemToSpawnLocation( );
    }

    public override void OnNotify( Object sender, EventArguments e ) {
        switch ( e.eventMessage ) {
            case PlayerInventory.ADDED_ITEM_TO_INVENTORY:
                if (sender != this) {
                    break;
                }
                currentItemState = ItemState.ITEM_IN_PLAYER_INVENTORY;
                gameObject.SetActive( false );
                break;
            case PlayerInventory.REMOVED_ITEM_FROM_INVENTORY:
                currentItemState = ItemState.ITEM_AT_SPAWN_POINT;
                defenseItemData.CostOfUse = cachedCostOfUse;
                break;
        }
    }

    public override void UseItem( GameObject player ) {
        if (currentItemState == ItemState.ITEM_IN_USE) {
            return;
        }

        Vector3 playerPosition = player.transform.position;
        Vector3 fireFromPosition = new Vector3( playerPosition.x, 1.0f, playerPosition.z );
        gameObject.transform.position = fireFromPosition;
        gameObject.SetActive( true );

        GetComponent<Rigidbody>( ).velocity = (player.transform.forward * defenseItemData.projectileRange);
        defenseItemData.numberOfUses -= defenseItemData.CostOfUse;
        currentItemState = ItemState.ITEM_IN_USE;
        StartCoroutine( HideItemAfterUsePeriod( ) );
    }

    public override void RespawnItem( ) {
        gameObject.SetActive( true );
    }

    private void MoveItemToSpawnLocation( ) {
        transform.position = itemSpawnPoint.transform.position;
        transform.parent = itemSpawnPoint.transform;
    }

    private void ResetItem( ) {
        MoveItemToSpawnLocation( );
        gameObject.SetActive( false );
    }

    protected IEnumerator HideItemAfterUsePeriod( ) {
        yield return new WaitForSeconds( defenseItemData.itemDuration );
        ResetItem( );
        ItemHasPerished( );
    }

    protected override void ItemHasPerished( ) {
        if (defenseItemData.numberOfUses < 0) {
            currentItemState = ItemState.ITEM_INACTIVE;
        }
    }

}