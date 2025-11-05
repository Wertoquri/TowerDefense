using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBuildSetting : MonoBehaviour
{
    private GameObject structure;

    public GameObject StructureInfo()
    {
        return structure;
    }

    public void StartBuild(GameObject[] structure, int structureIndex, float height, int cost)
    {
        if(this.structure == null && CoinController.SubtructCoin(cost)){
            Vector3 position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
            this.structure = Instantiate(structure[structureIndex], position, Quaternion.identity);
        }
    }
}