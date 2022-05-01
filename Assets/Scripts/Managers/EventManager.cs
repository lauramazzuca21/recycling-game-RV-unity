﻿using UnityEngine;

public class EventManager : MonoBehaviour
{
    //definisce la funzione che voglio (interfaccia funzione evento)
    public delegate void ReceivePoints(int pts);
    public static event ReceivePoints Points;

    public delegate void ReceiveSound(string objTag);
    public static event ReceiveSound Sound;

    public delegate void ReceivePlayerInteraction(GameObject gameObject);
    public static event ReceivePlayerInteraction PlayerInteraction;

    public delegate void ReceiveCorrectRecycling(RecyclableObject.ObjID ID);
    public static event ReceiveCorrectRecycling CorrectRecycling;

    public delegate void ReceiveWrongRecycling();
    public static event ReceiveWrongRecycling WrongRecycling;

    public delegate void ReceiveDisplayMessage(Classes.Message msg, int lastInSec);
    public static event ReceiveDisplayMessage DisplayMessage;


    internal static void FirePoints(int pts)
    {
        Points?.Invoke(pts);
    }

    internal static void FireSound(string objTag)
    {
        Sound?.Invoke(objTag);
    }

    internal static void FirePlayerInteraction(GameObject gameObject)
    {
        PlayerInteraction?.Invoke(gameObject);
    }

    internal static void FireCorrectRecycling(RecyclableObject.ObjID ID)
    {
        CorrectRecycling?.Invoke(ID);
    }

    internal static void FireWrongRecycling()
    {
        WrongRecycling?.Invoke();
    }

    public static void FireDisplayMessage(Classes.Message msg, int lastInSec)
    {
        DisplayMessage?.Invoke(msg, lastInSec);
    }
}
