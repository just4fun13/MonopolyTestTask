using System;
using Xunit;
using static MonopolyTestTask.Program;

namespace MonopolyTestTask
{

    public class WarehouseTests
    {
        [Fact]
        public void Box_GetExpirationDate_ValidProductionDate_ReturnsCorrectExpirationDate()
        {
            // Arrange
            DateTime productionDate = new DateTime(2023, 6, 1);
            Box box = new Box("B1", 10, 10, 10, 10, productionDate);

            // Act
            DateTime expirationDate = box.GetExpirationDate();

            // Assert
            DateTime expectedExpirationDate = productionDate.AddDays(100);
            Assert.Equal(expectedExpirationDate, expirationDate);
        }

        [Fact]
        public void Pallet_GetExpirationDate_NoBoxes_ReturnsMinValue()
        {
            // Arrange
            Pallet pallet = new Pallet("P1", 100, 100, 100, 0);

            // Act
            DateTime expirationDate = pallet.GetExpirationDate();

            // Assert
            Assert.Equal(DateTime.MinValue, expirationDate);
        }

        [Fact]
        public void Pallet_GetExpirationDate_WithBoxes_ReturnsMinimumExpirationDate()
        {
            // Arrange
            DateTime productionDate1 = new DateTime(2023, 6, 1);
            DateTime productionDate2 = new DateTime(2023, 6, 2);
            Box box1 = new Box("B1", 10, 10, 10, 10, productionDate1);
            Box box2 = new Box("B2", 10, 10, 10, 10, productionDate2);
            Pallet pallet = new Pallet("P1", 100, 100, 100, 0);
            pallet.AddBox(box1);
            pallet.AddBox(box2);

            // Act
            DateTime expirationDate = pallet.GetExpirationDate();

            // Assert
            DateTime expectedExpirationDate = productionDate1.AddDays(100);
            Assert.Equal(expectedExpirationDate, expirationDate);
        }

        [Fact]
        public void Pallet_GetWeight_NoBoxes_ReturnsBaseWeight()
        {
            // Arrange
            Pallet pallet = new Pallet("P1", 100, 100, 100, 0);

            // Act
            int weight = pallet.GetWeight();

            // Assert
            Assert.Equal(30, weight);
        }

        [Fact]
        public void Pallet_GetWeight_WithBoxes_ReturnsTotalWeight()
        {
            // Arrange
            Box box1 = new Box("B1", 10, 10, 10, 15, DateTime.Now);
            Box box2 = new Box("B2", 20, 20, 20, 15, DateTime.Now);
            Pallet pallet = new Pallet("P1", 100, 100, 100, 0);
            pallet.AddBox(box1);
            pallet.AddBox(box2);

            // Act
            int weight = pallet.GetWeight();

            // Assert
            Assert.Equal(60, weight);
        }

        [Fact]
        public void Box_GetVolume_ReturnsCorrectVolume()
        {
            // Arrange
            Box box = new Box("B1", 10, 20, 30, 15, DateTime.Now);

            // Act
            int volume = box.GetVolume();

            // Assert
            Assert.Equal(6000, volume);
        }

        [Fact]
        public void Pallet_GetVolume_NoBoxes_ReturnsBaseVolume()
        {
            // Arrange
            Pallet pallet = new Pallet("P1", 100, 100, 100, 0);

            // Act
            int volume = pallet.GetVolume();

            // Assert
            Assert.Equal(100 * 100 * 100, volume);
        }

        [Fact]
        public void Pallet_GetVolume_WithBoxes_ReturnsTotalVolume()
        {
            // Arrange
            Box box1 = new Box("B1", 10, 10, 10, 15, DateTime.Now);
            Box box2 = new Box("B2", 20, 20, 20, 15, DateTime.Now);
            Pallet pallet = new Pallet("P1", 100, 100, 100, 0);
            pallet.AddBox(box1);
            pallet.AddBox(box2);

            // Act
            int volume = pallet.GetVolume();

            // Assert
            Assert.Equal((10 * 10 * 10) + (20 * 20 * 20) + (100 * 100 * 100), volume);
        }
    }
}