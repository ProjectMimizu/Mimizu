
function Start() {

  for (var y = 0; y < 100; y++) {
          for (var x = 0; x < 100; x++) {
              var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
              //cube.transform.scale = Vector3 (x/2, y/2, 0.5);
              cube.transform.position = Vector3 (x, y, 0);
          }
      }
};

function Update() {



};
