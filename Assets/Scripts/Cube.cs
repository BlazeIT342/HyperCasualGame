using TZ.Control;
using TZ.Ground;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] bool firstCube = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (firstCube)
            {
                FindObjectOfType<Menu>().GameOver();
                player.GetComponent<PlayerController>().GameOver();
                return;
            }
            player.GetComponentInChildren<CubeHolder>().RemoveCube(this);
            FindObjectOfType<GroundMoover>().RespawnGround();
        }
        if (collision.gameObject.CompareTag("CubePickup"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponentInChildren<CubeHolder>().AddCube();
            Destroy(collision.gameObject);
        }
    }
}