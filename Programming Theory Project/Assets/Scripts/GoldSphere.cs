public class GoldSphere : Unit {

    protected override void Start() {
        base.Start();

        // Can collect only with this Tag -Polymorphysm
        collectibleTag = "GoldSweet";
    }
}