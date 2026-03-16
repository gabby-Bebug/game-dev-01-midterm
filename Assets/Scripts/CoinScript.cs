using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    //The player calls this function on the coin whenever they bump into it
    //You can change its contents if you want something different to happen on collection
    //For example, what if the coin teleported to a new location instead of being destroyed?
    public void GetBumped()
    {
        Vector3 pos = new Vector3();
        pos.x = Random.Range(-7, 7f);
        pos.y = Random.Range(-4, 4f);
    }
}
