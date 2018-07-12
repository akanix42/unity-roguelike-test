//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public KeysHeldComponent keysHeld { get { return (KeysHeldComponent)GetComponent(InputComponentsLookup.KeysHeld); } }
    public bool hasKeysHeld { get { return HasComponent(InputComponentsLookup.KeysHeld); } }

    public void AddKeysHeld(System.Collections.Generic.IEnumerable<GameKey> newKeys) {
        var index = InputComponentsLookup.KeysHeld;
        var component = CreateComponent<KeysHeldComponent>(index);
        component.keys = newKeys;
        AddComponent(index, component);
    }

    public void ReplaceKeysHeld(System.Collections.Generic.IEnumerable<GameKey> newKeys) {
        var index = InputComponentsLookup.KeysHeld;
        var component = CreateComponent<KeysHeldComponent>(index);
        component.keys = newKeys;
        ReplaceComponent(index, component);
    }

    public void RemoveKeysHeld() {
        RemoveComponent(InputComponentsLookup.KeysHeld);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherKeysHeld;

    public static Entitas.IMatcher<InputEntity> KeysHeld {
        get {
            if (_matcherKeysHeld == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.KeysHeld);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherKeysHeld = matcher;
            }

            return _matcherKeysHeld;
        }
    }
}
