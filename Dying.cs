using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class Dying : MonoBehaviour
{
   private void Update(){
    if(transform.position.y < -27f){
        Die();
    }
   }
   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }
    public void Die(){
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<script_mouvement>().enabled = true;
        Invoke(nameof(reloadLevel), 1.3f);
    }
    void reloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
