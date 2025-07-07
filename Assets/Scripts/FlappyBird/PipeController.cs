using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] GameObject m_pipePrefabs;
    [SerializeField] List<GameObject> m_pipes;

    float m_minSpawnInterval = 2.4f;
    float m_maxSpawnInterval = 3.2f;
    float m_spawnDelay = 0f;
    void Start()
    {
    }
    public void Init()
    {
        m_spawnDelay = 0f;
        ClearPlatformList();
        SpawnPlatform();
    }
    void SpawnPlatform()
    {
        var platform = Instantiate(m_pipePrefabs, new Vector2(20.48f, (int)Random.Range(-3, 3)), Quaternion.identity, transform);
        m_pipes.Add(platform);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGameBegin()) return;

        m_spawnDelay += Time.deltaTime;
        float spawnInterval = Random.Range(m_minSpawnInterval, m_maxSpawnInterval);
        if (m_spawnDelay >= spawnInterval)
        {
            m_spawnDelay = 0f;
            SpawnPlatform();
        }
    }

    public void RemovePlatform(GameObject platform)
    {
        m_pipes.Remove(platform);
    }

    void ClearPlatformList()
    {
        foreach (var plat in m_pipes)
        {
            Destroy(plat.gameObject);
        }
        m_pipes.Clear();
    }
}
