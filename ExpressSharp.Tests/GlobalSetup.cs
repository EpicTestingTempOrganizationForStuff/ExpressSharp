﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ExpressSharp;
using System.Threading;
//No namespace makes it global

[SetUpFixture]
class GlobalSetup
{
    private Thread listenThread;

    [OneTimeSetUp]
    public void Setup()
    {
        Express server = new Express();

        server.GET("/PlainText", (req, res) =>
        {
            res.Status(200).Send("Hello, World!");
        });

        server.GET("/Json", (req, res) =>
        {
            res.Status(200).Json(new { Id = 300 });
        });

        listenThread = new Thread(() =>
        {
            server.Listen();
        });

        listenThread.Start();
    }

    [OneTimeTearDown]
    public void TearDown()
	{
	}
}