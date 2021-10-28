using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class size_variable_behaviour : MonoBehaviour {
    GameObject[] spheres;
    GameObject player;
    Vector3 scale;
    public float distance_threshold_spheres = 10f;
    public float distance_threshold_player = 10f;

    void Awake() {
        scale = transform.localScale;
        spheres = GameObject.FindGameObjectsWithTag("Sphere");
        player = GameObject.FindWithTag("Cube Player");
    }

    // Update is called once per frame
    void Update() {
        float sphere_distance = distance_threshold_spheres;
        if (spheres != null && spheres.Length != 0) {
            foreach (GameObject sphere in spheres) {
                float current_distance = Vector3.Distance(sphere.transform.position, transform.position);
                if (current_distance <= distance_threshold_spheres)
                    sphere_distance = Mathf.Min(sphere_distance, current_distance);
            }
        }
        float player_distance = Mathf.Min(Vector3.Distance(player.transform.position, transform.position), distance_threshold_player);
        sphere_distance /= distance_threshold_spheres;
        player_distance /= distance_threshold_player;
        float difference = Mathf.Abs(sphere_distance - player_distance);
        if (sphere_distance < player_distance) {
            transform.localScale = (1 + difference) * scale;
        } else {
            transform.localScale = (1 - difference) * scale;
        }
    }
}
