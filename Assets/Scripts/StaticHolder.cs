using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticHolder : MonoBehaviour
{
    public static int SELECTEDCHAR;
    public static int GAMEMODE;
    public static int PONEWINS;
    public static int PTWOWINS;
    public static Vector3 UNSELECTEDCHAR_POS;
    public static Quaternion UNSELECTEDCHAR_ROT;
    
    //dont save these things
    public static GameObject SINGLEPLAYERCHAR;
}
