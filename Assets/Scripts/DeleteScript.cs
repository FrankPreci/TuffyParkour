using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DeleteScript : MonoBehaviour
{
    public GameManagerScript gm;
    private bool isDead = false;
    [SerializeField] string TagFilter;

    public void OnTriggerEnter2D(Collider2D other)
    {
         if (!other.CompareTag(TagFilter) )
         {
            Destroy(other.gameObject);
         }
         if(other.tag == "Player")
         {
            isDead = true;
            other.gameObject.SetActive(false);
            gm.GameOverUI();
            Debug.Log("Dead as Hell");
         }
    }
}
