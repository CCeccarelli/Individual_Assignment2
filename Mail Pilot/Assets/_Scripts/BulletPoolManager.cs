using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bulletObj;

    //TODO: create a structure to contain a collection of bullets
    public List<GameObject> bulletList;
    public int numBullets = 10;

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool
        for (int i = 0; i <= numBullets; i++)
        {
            bulletList.Add(Instantiate(bulletObj, new Vector3(0, 0, 0), Quaternion.identity));
            bulletList[i].GetComponent<BulletController>().bpm = this;
        }
        numBullets = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {
        if (numBullets > bulletList.Count - 2)
        {
            numBullets = 0;
        }
        else
        {
            numBullets++;
        }
        return bulletList[numBullets];
    }
    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.position = new Vector3(0, 0, 0);
    }
}
