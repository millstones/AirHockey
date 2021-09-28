namespace AirHockey.ECS.UnityComponents
{
    public interface IFreezeAxisViewComponent
    {
        public bool FreezeXPosition { get; set; }
        public bool FreezeYPosition { get; set; }
        public bool FreezeZPosition { get; set; }
        public bool FreezeXRotation { get; set; }
        public bool FreezeYRotation { get; set; }
        public bool FreezeZRotation { get; set; }
    }
}