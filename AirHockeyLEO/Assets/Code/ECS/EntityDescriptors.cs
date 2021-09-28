using AirHockey.ECS.Components;
using Millstones.LeoECSExtension;
using Millstones.LeoECSExtension.Components;

namespace AirHockey.ECS
{
    public class TableEntityDescriptor : EntityDescriptor<TableTag> { }
    public class GateUpEntityDescriptor : EntityDescriptor<GateTag, GateUpTag> { }
    public class GateDownEntityDescriptor : EntityDescriptor<GateTag, GateDownTag> { }
    public class PutterEntityDescriptor : EntityDescriptor<PutterTag, MoveViewComponent, FreezeAxisViewComponent> { }
    public class PuckEntityDescriptor : EntityDescriptor<PuckTag, MoveViewComponent, FreezeAxisViewComponent, ScoreComponent> { }
    public class HUDEntityDescriptor : EntityDescriptor<HUD, HUDViewComponent, ScoreComponent> { }
}