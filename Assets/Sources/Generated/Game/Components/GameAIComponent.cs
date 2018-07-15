//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AIComponent aI { get { return (AIComponent)GetComponent(GameComponentsLookup.AI); } }
    public bool hasAI { get { return HasComponent(GameComponentsLookup.AI); } }

    public void AddAI(string newValue) {
        var index = GameComponentsLookup.AI;
        var component = CreateComponent<AIComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAI(string newValue) {
        var index = GameComponentsLookup.AI;
        var component = CreateComponent<AIComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAI() {
        RemoveComponent(GameComponentsLookup.AI);
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

    static Entitas.IMatcher<GameEntity> _matcherAI;

    public static Entitas.IMatcher<GameEntity> AI {
        get {
            if (_matcherAI == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AI);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAI = matcher;
            }

            return _matcherAI;
        }
    }
}