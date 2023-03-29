using UnityEngine;

public class SpawnManager : MonoBehaviour {
    // 
    [SerializeField] private GameObject[] sweet;

    // Spawn coordinates
    private float minX = 10;
    private float maxX = 20;
    private float Y = 0.5f;
    private float minZ = 0;
    private float maxZ = 10;

    // Other Variables
    public float Timer;

    private void Awake() {
        Timer = 2f;
    }

    private void Update() {
        Timer -= Time.deltaTime;
        if (Timer < 0) {
            Instantiate(sweet[GiveRandomInt(sweet.Length)], new Vector3(GiveRandomFloat(minX, maxX), Y, GiveRandomFloat(minZ, maxZ)), new Quaternion());
            Timer = 2f;
        }
    }


// Abstraction

    //Randomize functions 
    private int GiveRandomInt(int maxNumber) {
        return Random.Range(0, maxNumber);
    }

    private float GiveRandomFloat(float minNumber, float maxNumber) {
        return Random.Range(minNumber, maxNumber);
    }
}
