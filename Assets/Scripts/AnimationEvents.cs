using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public PlayerController playerc;
    void Start()
    {
        if(playerc==null)
        {
            playerc = GetComponentInParent<PlayerController>();
        }
    }
    // Start is called before the first frame update
    public void PlayerAttack()
    {
        Debug.Log("Attacking");
        playerc.DoAttack();
    }
    public void Hitting()
    {
        Debug.Log("Hit");
    }
}
