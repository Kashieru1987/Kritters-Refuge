

using Content.Shared.Chemistry;
using Content.Shared.Chemistry.Components;
using Content.Shared.Chemistry.EntitySystems;

namespace Content.Server.Chemistry.EntitySystems;

public sealed partial class ChemMasterSystem : SharedChemMasterSystem
{
    [Dependency] private SharedUserInterfaceSystem _userInterface = default!;
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
        if(_userInterface.TryGetOpenUi(uid, ChemMasterUiKey.Key, out var bui))
        {
            bui.Update();
        }
    }

}