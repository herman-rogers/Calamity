﻿using UnityEngine;
using UnityEngine.Networking;

public class UnityObserver : MonoBehaviour, IObserver {
    //Don't Override Awake
    protected void Awake( ) {
        gameObject.tag = "UnityObserver";
        InitializeUnityObserver( );
    }

    public virtual void InitializeUnityObserver( ) { }

    public virtual void OnNotify( Object sender, EventArguments e ) { }
}