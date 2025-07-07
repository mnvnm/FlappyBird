using UnityEngine;

public class GameUI : MonoBehaviour
{
    public PlayerController player;
    public PipeController pipe;

    public void Init()
    {
        player.Init();
        pipe.Init();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
