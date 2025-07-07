using UnityEngine;

public class Pipe : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGameBegin()) return;

        transform.position = new Vector2(transform.position.x - (8 * Time.deltaTime), transform.position.y);
    }

    void Start()
    {
        Invoke("DestroyPipe", 10f);
    }

    void DestroyPipe()
    {
        GameManager.Instance.gameUI.pipe.RemovePlatform(gameObject);
        Destroy(this.gameObject);
    }
}
