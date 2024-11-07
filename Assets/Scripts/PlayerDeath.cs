using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] AudioSource deathFallSound;
    [SerializeField] AudioSource deathKillSound;
    [SerializeField] UnityEngine.UI.Text gameover;
    private bool dead = false;
    private void Update()
    {
        if (transform.position.y < -1f && !dead)
        {
            deathFallSound.Play();
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerControl>().enabled = false;
            deathKillSound.Play();
            Die();
            gameover.text = "GAME OVER";
        }
    }

    void Die()
    {
        dead = true;
        Invoke(nameof(ReloadLife),3.3f);
    }

    void ReloadLife()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
