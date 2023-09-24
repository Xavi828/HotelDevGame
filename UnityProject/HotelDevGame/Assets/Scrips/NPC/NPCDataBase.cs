using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDataBase : MonoBehaviour
{

    public PlayerType playerType;

    public enum PlayerType
    {
        Customer,
        Janitor,
        CEO,
    }
}
