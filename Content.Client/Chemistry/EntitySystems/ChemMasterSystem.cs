

using Content.Shared.Chemistry;
using Content.Shared.Chemistry.Components;
using Content.Shared.Chemistry.EntitySystems;
using Robust.Shared.Containers;

namespace Content.Client.Chemistry.EntitySystems;

public sealed partial class ChemMasterSystem : SharedChemMasterSystem
{
    [Dependency] private SharedUserInterfaceSystem _userInterfaceSystem = default!;
    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<ChemMasterComponent, AfterAutoHandleStateEvent>(OnAfterAutoHandleState);
    }

    private void OnAfterAutoHandleState(Entity<ChemMasterComponent> ent, ref AfterAutoHandleStateEvent args)
    {
        UpdateUi(ent);
    }


    public override void UpdateUi(EntityUid uid)
    {
        if (_userInterfaceSystem.TryGetOpenUi(uid, ChemMasterUiKey.Key, out var bui))
        {
            bui.Update();
        }
    }

}