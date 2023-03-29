public class SilverSphere : Unit {

    protected override void Start() {
        base.Start();

        // Can collect only with this Tag
        collectibleTag = "SilverSweet";
    }
}


