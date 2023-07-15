using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private float attackCooldown;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private AudioClip swordSound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.L) && cooldownTimer > attackCooldown && playerMovement.canAttack())
           Attack();
        
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        
        SoundManager.instance.PlaySound(swordSound);
        anim.SetTrigger("attack2");
        cooldownTimer = 0;
        
    }
}
