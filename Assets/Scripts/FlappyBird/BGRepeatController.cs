using UnityEngine;

public class BGRepeatController : MonoBehaviour
{
    float m_width = 40;
    [SerializeField]float m_speed = 4.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGameBegin()) return;
        transform.position += Vector3.left * Time.deltaTime * m_speed;

        if (transform.position.x < -m_width)
            transform.position += new Vector3(m_width * 2, 0, 0);
    }
}
