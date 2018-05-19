using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        Transform player;               // Reference to the player's position.
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.

        Animator anim;
        Transform home;

        void Awake ()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();

            anim = GetComponent<Animator>();
            home = GameObject.FindGameObjectWithTag("Home").transform;
        }


        void Update ()
        {
            // If the enemy and the player have health left...
            if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                if (PlayerMovement.isSafe == true)
                {
                    nav.SetDestination(home.position);
                    anim.SetBool("Move", true);
                    nav.isStopped = false;
                    Debug.Log("DENTRO");
                }
                else
                {
                    //Debug.Log("Fuera");
                    // ... set the destination of the nav mesh agent to the player.
                    nav.SetDestination(player.position);
                    nav.isStopped = true;
                    anim.SetBool("Move", false);


                    if (nav.remainingDistance <= 10)
                    {
                        nav.isStopped = false;
                        anim.SetBool("Move", true);

                    }
                }
               

                
                
            }
            // Otherwise...
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }
    }
}