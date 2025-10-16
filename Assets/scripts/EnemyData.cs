using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float attackRange = 5f;
    public float health = 100f;
    public float speed = 5f;
    public int damage = 10;
    public string enemyName = "Zombie";
    public string attackAnimation = "Attack";
    public string deathAnimation = "Die";
    public string walkAnimation = "Walk";
    public string hitAnimation = "Hit";
    public string winAnimation = "Win";
}
