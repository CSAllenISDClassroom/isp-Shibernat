using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
 public void Interact()
 {
     //Message pops up when interacting
     Debug.Log("Interacting with NPC");
 }
}