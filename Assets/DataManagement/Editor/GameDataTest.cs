using UnityEngine;
using NUnit.Framework;
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
        Assert.DoesNotThrow(() => json.LoadJobData());
    }

    [Test]
    public void ReturnsAListOfJobs()
    {
        var json = new GameData();
        var list = json.LoadJobData();

        Assert.IsInstanceOf<List<JobData>>(list);
        Assert.GreaterOrEqual(list.Count, 2);
    }

    [Test]
    public void ReturnsAdequateJobs()
    {
        var json = new GameData();
        var list = json.LoadJobData();

        Debug.Log(list[0].name);
        Debug.Log(list[0].acceptedPowers[0]);

        //Assert.AreEqual("Super Force", list[0].name);
        //Assert.AreEqual("force", list[0].key);
    }
}
