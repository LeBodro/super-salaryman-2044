using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class GameDataTest
{

    [Test]
    public void IsInstantiable()
    {
        var json = new GameData();
        Assert.NotNull(json);
    }

    [Test]
    public void CanLoadGameData()
    {
        var json = new GameData();
        Assert.DoesNotThrow(() => json.LoadGameData("powers.json"));
    }

    [Test]
    public void ThrowsOnInvalidFileName()
    {
        var json = new GameData();
        Assert.Throws<System.ArgumentException>(() => json.LoadGameData("invalid name |!/"));
    }

    [Test]
    public void ReturnsAListOfPowers()
    {
        var json = new GameData();
        var list = json.LoadGameData("powers.json");

        Assert.IsInstanceOf<List<PowerData>>(list);
        Assert.GreaterOrEqual(list.Count, 2);
    }

    [Test]
    public void ReturnsAdequatePowers()
    {
        var json = new GameData();
        var list = json.LoadGameData("powers.json");

        Debug.Log(list[0].name);

        Assert.AreEqual("Super Force", list[0].name);
        Assert.AreEqual("force", list[0].key);
    }
}
