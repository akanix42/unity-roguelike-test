//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ViewInventoryScreenSystemComponent viewInventoryScreenSystem { get { return (ViewInventoryScreenSystemComponent)GetComponent(GameComponentsLookup.ViewInventoryScreenSystem); } }
    public bool hasViewInventoryScreenSystem { get { return HasComponent(GameComponentsLookup.ViewInventoryScreenSystem); } }

    public void AddViewInventoryScreenSystem(ViewInventoryScreenSystem newValue) {
        var index = GameComponentsLookup.ViewInventoryScreenSystem;
        var component = CreateComponent<ViewInventoryScreenSystemComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceViewInventoryScreenSystem(ViewInventoryScreenSystem newValue) {
        var index = GameComponentsLookup.ViewInventoryScreenSystem;
        var component = CreateComponent<ViewInventoryScreenSystemComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveViewInventoryScreenSystem() {
        RemoveComponent(GameComponentsLookup.ViewInventoryScreenSystem);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherViewInventoryScreenSystem;

    public static Entitas.IMatcher<GameEntity> ViewInventoryScreenSystem {
        get {
            if (_matcherViewInventoryScreenSystem == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ViewInventoryScreenSystem);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherViewInventoryScreenSystem = matcher;
            }

            return _matcherViewInventoryScreenSystem;
        }
    }
}
