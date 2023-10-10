using NUnit.Framework;
using SmartDevice;
using System.Numerics;
using System;

public class DeviceTests
{
    [Test]
    public void TestTakePhoto_Success()
    {
        // Arrange
        Device device = new Device(100);
        int photoSize = 20;

        // Act
        bool result = device.TakePhoto(photoSize);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(1, device.Photos);
        Assert.AreEqual(80, device.AvailableMemory);
    }

    [Test]
    public void TestTakePhoto_Failure()
    {
        // Arrange
        Device device = new Device(50);
        int photoSize = 60;

        // Act
        bool result = device.TakePhoto(photoSize);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(0, device.Photos);
        Assert.AreEqual(50, device.AvailableMemory);
    }

    [Test]
    public void TestInstallApp_Success()
    {
        // Arrange
        Device device = new Device(100);
        int appSize = 30;

        // Act
        string result = device.InstallApp("App1", appSize);

        // Assert
        Assert.AreEqual("App1 is installed successfully. Run application?", result);
        Assert.AreEqual(70, device.AvailableMemory);
        Assert.IsTrue(device.Applications.Contains("App1"));
    }

    [Test]
    
    public void TestInstallApp_InsufficientMemory()
    {
        // Arrange
        Device device = new Device(50);
        int appSize = 60;

        // Act
        device.InstallApp("App2", appSize);
    }

    [Test]
    public void TestFormatDevice()
    {
        // Arrange
        Device device = new Device(100);
        device.TakePhoto(20);
        device.InstallApp("App1", 30);

        // Act
        device.FormatDevice();

        // Assert
        Assert.AreEqual(0, device.Photos);
        Assert.AreEqual(100, device.AvailableMemory);
        Assert.AreEqual(0, device.Applications.Count);
    }

    [Test]
    public void TestGetDeviceStatus()
    {
        // Arrange
        Device device = new Device(100);
        device.TakePhoto(20);
        device.InstallApp("App1", 30);

        // Act
        string status = device.GetDeviceStatus();

        // Assert
        StringAssert.Contains(status, "Memory Capacity: 100 MB, Available Memory: ");
        StringAssert.Contains(status, "Photos Count: 1");
        StringAssert.Contains(status, "Applications Installed: App1");
    }
}






