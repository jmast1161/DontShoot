using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllySpawnBehavior : MonoBehaviour
{
    public GameObject ally;
    private float populatorTimer = 2.0f;

    private IList<Vector2> allyLocations = new List<Vector2>
    {
        new Vector2(-8, 4),
        new Vector2(-4, 4),
        new Vector2(-0, 4),
        new Vector2(4, 4),
        new Vector2(8, 4),
        new Vector2(-8, 2),
        new Vector2(-4, 2),
        new Vector2(-0, 2),
        new Vector2(4, 2),
        new Vector2(8, 2),
        new Vector2(-8, 0),
        new Vector2(-4, 0),
        new Vector2(-0, 0),
        new Vector2(4, 0),
        new Vector2(8, 0),
        new Vector2(-8, -2),
        new Vector2(-4, -2),
        new Vector2(-0, -2),
        new Vector2(4, -2),
        new Vector2(8, -2),
        new Vector2(-8, -4),
        new Vector2(-4, -4),
        new Vector2(-0, -4),
        new Vector2(4, -4),
        new Vector2(8, -4),
    };

    private void Update()
    {
        if (populatorTimer > 0 && !GameEventsBehavior.Current.GameOverShown)
        {
            populatorTimer -= Time.deltaTime;
        }
        else if (populatorTimer <= 0 && allyLocations.Any())
        {
            var allyLocationIndex = Random.Range(0, allyLocations.Count);
            var allyLocation = allyLocations[allyLocationIndex];
            allyLocation.x += Random.Range(-0.5f, 0.5f);
            allyLocation.y += Random.Range(-0.5f, 0.5f);

            Instantiate(ally, allyLocation, Quaternion.Euler(new Vector3(0, 0, 0)));           
            populatorTimer = 2.0f;
            allyLocations.RemoveAt(allyLocationIndex);
        }
    }
}
