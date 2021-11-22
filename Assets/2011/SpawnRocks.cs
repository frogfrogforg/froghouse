using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour
{
    public List<GameObject> rockPrefabs;
    public Transform rockParent;

    public float interval = 3f;

    public float horizontalExtents = 3f;

    private float _spawnTime;

    public float t = 0.2f; // threshold for random rock chooser (see ChooseRock)

    private int _chooseIndex;

    public float minScale = 1f;
    public float maxScale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _chooseIndex = 0;
        _spawnTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _spawnTime) {

            //float r=  (Mathf.PerlinNoise(0f, Time.time)*2f - 1f;
            float r = Random.Range(-1f, 1f);
            GameObject prefab = ChooseRock();
            GameObject newRock = Instantiate(prefab);
            newRock.name = prefab.name; // Don't add "(Clone)" at the end: Gem must be called Gem
            newRock.transform.position = new Vector3(
                transform.position.x + horizontalExtents*r,
                newRock.transform.position.y,
                transform.position.z
            );
            newRock.transform.SetParent(rockParent);

            newRock.transform.eulerAngles = new Vector3(
                0f,
                Random.Range(-180f, 180f),
                0f
            );

            newRock.transform.localScale *= Random.Range(minScale, maxScale);

            _spawnTime = Time.time + interval; // TODO randomize interval?
        }
    }

    // Experimental alternative to shuffle bag
    GameObject ChooseRock() {
        while (Random.value > t) {
            _chooseIndex++;
        }
        _chooseIndex = _chooseIndex%rockPrefabs.Count;
        return rockPrefabs[_chooseIndex];
    }
}
