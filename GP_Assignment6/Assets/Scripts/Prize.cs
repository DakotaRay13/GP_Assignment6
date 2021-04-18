using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prize : MonoBehaviour
{
    public int Value = 10;

    private void OnTriggerEnter(Collider col)
    {
        if(col.name == "Player")
        {
            FindObjectOfType<GameManager>().ClaimPrize(this);
            Destroy(this.gameObject);
        }
    }
}
