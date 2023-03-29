using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Unit : MonoBehaviour {


    //INHERITANCE

    protected NavMeshAgent unit;
    protected string collectibleTag;

    protected virtual void Start() {
        unit = GetComponent<NavMeshAgent>();
        unit.speed = 7;
        unit.acceleration = 999;
        unit.angularSpeed = 999;
    }

    private void Update() {
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag(collectibleTag);

        if (collectibles.Length > 0) {
            GameObject closestCollectible = GetClosestCollectible(collectibles);

            if (closestCollectible != null) {
                unit.SetDestination(closestCollectible.transform.position);
            }
        }
    }


    // Calculate closest Collectible
    protected GameObject GetClosestCollectible(GameObject[] collectibles) {
        GameObject closestCollectible = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject collectible in collectibles) {
            float distance = Vector3.Distance(transform.position, collectible.transform.position);

            if (distance < closestDistance) {
                closestCollectible = collectible;
                closestDistance = distance;
            }
        }
        return closestCollectible;
    }

    //When collides with object with collectible Tag it distroys it
    protected void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag(collectibleTag)) {
            Destroy(other.gameObject);
        }
    }
}



