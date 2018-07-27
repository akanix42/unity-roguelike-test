using System.Collections.Generic;
using FluentAssertions;
using NSpec;
using NSpec.Assertions;

class describe_TurnService_SpeedSortComparer : nspec {
  void when_sorting() {
    it["sorts entities with higher speed above those with lower speed"] = () => {
      var entities = new List<TurnService.EntitySpeed> {
        new TurnService.EntitySpeed(0, 10),
        new TurnService.EntitySpeed(1, 100),
        new TurnService.EntitySpeed(2, 1),
        new TurnService.EntitySpeed(3, 50),
        new TurnService.EntitySpeed(4, 21)
      };

      var speedSortComparer = new TurnService.SpeedSortComparer();

      entities.Sort(speedSortComparer);

      entities[0].entityId.Should().Be(1);
      entities[1].entityId.Should().Be(3);
      entities[2].entityId.Should().Be(4);
      entities[3].entityId.Should().Be(0);
      entities[4].entityId.Should().Be(2);
    };
  }
}