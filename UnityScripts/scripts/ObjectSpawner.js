    var prefab : GameObject;
     
     
    function MakePrefab()
    {
    var myPrefab = Instantiate (prefab, Vector3(0,0,0), Quaternion.identity);
     
    //to access info about the prefab...scripts, postion, etc. use what ever you assign it to.. in this case "myPrefab"
    myPrefab.GetComponent("scriptName").SetMyValue(5);
    myPrefab.transform.position = Vector3(5,5,5);
    }