using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnBehavior : MonoBehaviour
{
    public GameObject enemy;
    
    private float populatorTimer = 0f;
    
    private IList<Vector2> enemyLocations = new List<Vector2>
    {
        new Vector2(-11, 4),
        new Vector2(-11, 2),
        new Vector2(-11, 0),
        new Vector2(-11, -2),
        new Vector2(-11, -4),        
        new Vector2(11, 4),        
        new Vector2(11, 2),
        new Vector2(11, 0),
        new Vector2(11, -2),
        new Vector2(11, -4),        
        new Vector2(6, -8),
        new Vector2(6, -4),
        new Vector2(6, 0),
        new Vector2(6, 4),
        new Vector2(6, 8),
        new Vector2(-6, -8),
        new Vector2(-6, -4),
        new Vector2(-6, 0),
        new Vector2(-6, 4),
        new Vector2(-6, 8)
    };

    private void Update()
    {
        if (populatorTimer > 0 && !GameEventsBehavior.Current.GameOverShown)
        {
            populatorTimer -= Time.deltaTime;
        }
        else if (populatorTimer <= 0)
        {
            var enemyLocationIndex = Random.Range(0, enemyLocations.Count);
            Instantiate(enemy, enemyLocations[enemyLocationIndex], Quaternion.Euler(new Vector3(0, 0, 0)));           
            populatorTimer = 2.0f;
        }
    }
}
