using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : ObjectHealth
{
    // Start is called before the first frame update
    private void OnCollisionStay2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    public override void HandleCollision(GameObject otherObject)
    {
        if (otherObject.CompareTag("Zombie"))
        {
            Zombie z = otherObject.GetComponent<Zombie>();
            SubtractHealth(z.Damage);
        }
    }

    public override void OnDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        base.OnDeath();
    }
}
