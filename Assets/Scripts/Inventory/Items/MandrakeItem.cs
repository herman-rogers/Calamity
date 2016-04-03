﻿using UnityEngine;
using System.Collections;
using RAIN.Entities;

public class MandrakeItem : DefenseItem {

    EntityRig playerRig;

    public override void UseItem( GameObject player ) {
        if (currentItemState == ItemState.ITEM_IN_USE) {
            return;
        }
        playerRig = player.GetComponentInChildren<EntityRig>( );

        PlaceMandrakeInPlayerHands( player );
        SetMandrakeVisualAspect( );
        MakePlayerInvisible( player );

        defenseItemData.numberOfUses -= defenseItemData.CostOfUse;
        currentItemState = ItemState.ITEM_IN_USE;
        StartCoroutine( HideItemAfterUsePeriod( ) );
    }

    private void PlaceMandrakeInPlayerHands( GameObject player ) {
        GameObject playerHands = player.GetComponentInChildren<PlayerHands>( ).gameObject;
        gameObject.transform.position = playerHands.transform.position;
        gameObject.transform.parent = playerHands.transform;
    }

    private void SetMandrakeVisualAspect( ) {
        spawnVisual.SetActive( false );
        activeVisual.SetActive( true );
        GetComponent<Rigidbody>( ).isKinematic = true;
    }

    private void MakePlayerInvisible( GameObject player ) {
        playerRig.Entity.IsActive = false;
    }

    protected override IEnumerator HideItemAfterUsePeriod( ) {
        yield return new WaitForSeconds( defenseItemData.itemDuration );
        playerRig.Entity.IsActive = true;
        ResetItem( );
        ItemHasPerished( );
    }

}