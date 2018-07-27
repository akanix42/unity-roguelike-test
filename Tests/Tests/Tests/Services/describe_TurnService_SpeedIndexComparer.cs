using System.Collections.Generic;
using FluentAssertions;
using NSpec;
using NSpec.Assertions;

class describe_TurnService_SpeedIndexComparer : nspec {
  void when_sorting() {
    it["sorts entities with higher speed above those with lower speed"] = () => {
      var entities = new List<TurnService.EntitySpeed> {
        new TurnService.EntitySpeed(1, 100),
        new TurnService.EntitySpeed(3, 50),
        new TurnService.EntitySpeed(0, 10),
        new TurnService.EntitySpeed(4, 21),
        new TurnService.EntitySpeed(2, 1),
      };

      var firstEntitySpeedToTest = new TurnService.EntitySpeed(5, 49);
      var secondEntitySpeedToTest = new TurnService.EntitySpeed(5, 0);
      var speedIndexComparer = new TurnService.SpeedIndexComparer();
      
      var firstIndex = ~entities.BinarySearch(firstEntitySpeedToTest, speedIndexComparer);
      var secondIndex = ~entities.BinarySearch(secondEntitySpeedToTest, speedIndexComparer);

      firstIndex.Should().Be(2);
      secondIndex.Should().Be(5);
    };
  }
}