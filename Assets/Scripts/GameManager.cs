using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("#Game Control")]
    public float gameTime;
    public float maxGameTime = 2 * 10f;

    [Header("#Game Object")]
    public Player player;
    public PoolManager pool;

    [Header("# Player Info")]
    public int health;
    public int maxHealth;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = {3,5,10,100,150,210,280,360,450,600};
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
    public void GetExp()
    {
        exp ++;
        if(exp == nextExp[level])
        {
            level++;
            exp = 0;
        }
    }
}
