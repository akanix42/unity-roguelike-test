//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public FloorComponent floor { get { return (FloorComponent)GetComponent(GameComponentsLookup.Floor); } }
    public bool hasFloor { get { return HasComponent(GameComponentsLookup.Floor); } }

    public void AddFloor(string newValue) {
        var index = GameComponentsLookup.Floor;
        var component = CreateComponent<FloorComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFloor(string newValue) {
        var index = GameComponentsLookup.Floor;
        var component = CreateComponent<FloorComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFloor() {
        RemoveComponent(GameComponentsLookup.Floor);
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

    static Entitas.IMatcher<GameEntity> _matcherFloor;

    public static Entitas.IMatcher<GameEntity> Floor {
        get {
            if (_matcherFloor == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Floor);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFloor = matcher;
            }

            return _matcherFloor;
        }
    }
}
