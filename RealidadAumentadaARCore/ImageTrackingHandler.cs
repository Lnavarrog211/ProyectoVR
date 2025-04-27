using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ImageTrackingHandler : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    private Dictionary<string, GameObject> spawnedObjects = new Dictionary<string, GameObject>();

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var addedImage in args.added)
        {
            HandleTrackedImage(addedImage);
        }
        foreach (var updatedImage in args.updated)
        {
            HandleTrackedImage(updatedImage);
        }
        foreach (var removedImage in args.removed)
        {
            if (spawnedObjects.TryGetValue(removedImage.referenceImage.name, out var spawnedObject))
            {
                Destroy(spawnedObject);
                spawnedObjects.Remove(removedImage.referenceImage.name);
            }
        }
    }

    private void HandleTrackedImage(ARTrackedImage trackedImage)
    {
        Debug.Log(trackedImage.referenceImage.name);
        Vector3 newPosition = trackedImage.transform.position;
        newPosition.y += 0.05f;
        trackedImage.transform.position = newPosition;

        string imageName = trackedImage.referenceImage.name;
        if (spawnedObjects.ContainsKey(imageName))
        {
            GameObject existingObject = spawnedObjects[imageName];
            existingObject.transform.position = trackedImage.transform.position;
            existingObject.transform.rotation = trackedImage.transform.rotation;
        }
        else
        {
            GameObject newObject = null;
            Vector3 rota = new Vector3(0, 0, -90);
           
            if (imageName == "FranPerez")
            {                   
                newObject = Instantiate(prefab1, trackedImage.transform.position, Quaternion.Euler(rota));
                newObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.001f);
            }
            else if (imageName == "Mingueza")
            {
                newObject = Instantiate(prefab2, trackedImage.transform.position, Quaternion.Euler(rota));
                newObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.001f);
            }
            else if (imageName == "Villareal")
            {
                newObject = Instantiate(prefab3, trackedImage.transform.position, trackedImage.transform.rotation);
                newObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            }
            if (newObject != null)
            {
                newObject.transform.SetParent(trackedImage.transform, false);
                spawnedObjects[imageName] = newObject;
            }
        }
    }
}
